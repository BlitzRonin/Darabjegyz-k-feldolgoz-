using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.GUI;
using Darabjegyzék_feldolgozó.GUI.Compare;
using Darabjegyzék_feldolgozó.GUI.Other.Filters;
using Darabjegyzék_feldolgozó.GUI.Simple.Drawers;
using System.Reflection.PortableExecutable;

namespace Darabjegyzék_feldolgozó
{
    public partial class Form1 : Form
    {
        private DatabaseInterface databaseInterface;
        private string path;
        private event EventHandler dataadded;
        private CompareTreePrinter compareprinter;
        private BomHandlerMenu bomhandlermenu;
        private BasePanel rawpanel;
        private BasePanel bompanel;
        private BasePanel commonpanel;
        private BasePanel levelpanel;
        private FilterGUIHandler handler;

        public Form1()
        {
            InitializeComponent();
            databaseInterface = new DatabaseHandler();
            path = Application.StartupPath;
            dataadded += checkfirst;
            databaseInterface.Filtering.filteringevent += checkfirst;
            fixhandler();
            setfilter();
        }

        private void fixhandler()
        {
            handler = new FilterGUIHandler(databaseInterface.Filtering);
            Controls.Add(handler["Level"]);
            Controls.Add(handler["Item"]);
            Controls.Add(handler["Quantitity"]);
            Controls.Add(handler["UM"]);
            Controls.Add(handler["Id"]);
            Controls.Add(handler["Kind"]);
            Controls.Add(handler["PTYP"]);
            Controls.Add(handler["Validfrom"]);
            Controls.Add(handler["Validto"]);
            Controls.Add(handler["Serial"]);
        }

        private void checkfirst(object sender, EventArgs e)
        {
            if (typeof(IPrinter).IsAssignableFrom(sender.GetType()))
            {
                ((IPrinter)sender).PrintIt(databaseInterface);
            }
        }

        private async void newBomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = path;
                    openFileDialog.Multiselect = true;
                    openFileDialog.Filter = "Comma-separated values (*.csv)|*.csv|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        await multiselectfiles(openFileDialog.FileNames);
                        adddata();
                    }
                    else
                    {
                        path = Application.StartupPath;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void adddata()
        {
            if (!typeof(FilterGUI).IsAssignableFrom(Controls[0].GetType()))
            {
                dataadded?.Invoke(Controls[0], EventArgs.Empty);
            }
            else
            {
                dataadded?.Invoke(Controls[1], EventArgs.Empty);
            }
        }

        private async Task multiselectfiles(string[] paths)
        {
            string res = "";
            await Task.Run(() => res = databaseInterface.addNews(paths));
            path = paths[0];
            MessageBox.Show(res);
        }

        private void manageBomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(bomhandlermenu))
            {
                bomhandlermenu = new BomHandlerMenu();
                Controls.Add(bomhandlermenu);
            }
            bomhandlermenu.PrintIt(databaseInterface);
        }

        private void treeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(commonpanel))
            {
                commonpanel = new BasePanel(new BomPrinterDraw(), handler);
                Controls.Add(commonpanel);
            }
            commonpanel.PrintIt(databaseInterface);
        }

        private void bOMGyakoriságToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(bompanel))
            {
                bompanel = new BasePanel(new CommonPrinterDraw(), handler);
                Controls.Add(bompanel);
            }
            bompanel.PrintIt(databaseInterface);
        }

        private void szintKimutatásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(levelpanel))
            {
                levelpanel = new BasePanel(new LevelPrinterDraw(), handler);
                Controls.Add(levelpanel);
            }
            levelpanel.PrintIt(databaseInterface);
        }

        private void bOMÖsszehasonlításToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(compareprinter))
            {
                compareprinter = new CompareTreePrinter(databaseInterface, handler);
                Controls.Add(compareprinter);
            }
            compareprinter.PrintIt(databaseInterface);
        }

        private void rawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(rawpanel))
            {
                rawpanel = new BasePanel(new RawPrinterDraw(), handler);
                Controls.Add(rawpanel);
            }
            rawpanel.PrintIt(databaseInterface);
        }

        private void CloseFilter(object sender, EventArgs e)
        {
            if (typeof(FilterGUI).IsAssignableFrom(Controls[0].GetType()))
            {
                ((FilterGUI)Controls[0]).FilterGUI_Leave(this, EventArgs.Empty);
            }
        }

        private void setfilter()
        {
            Click += CloseFilter;
            menuStrip1.Click += CloseFilter;
            statisticsToolStripMenuItem.Click += CloseFilter;
            dataToolStripMenuItem.Click += CloseFilter;
            fToolStripMenuItem.Click += CloseFilter;
        }
    }
}
