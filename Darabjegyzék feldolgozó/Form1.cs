using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.GUI;
using Darabjegyzék_feldolgozó.GUI.Compare;
using Darabjegyzék_feldolgozó.GUI.Simple.Drawers;

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

        public Form1()
        {
            InitializeComponent();
            databaseInterface = new DatabaseHandler();
            path = Application.StartupPath;
            dataadded += checkfirst;
            databaseInterface.Filtering.filteringevent += checkfirst;
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
                        dataadded?.Invoke(Controls[0], EventArgs.Empty);
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
                commonpanel = new BasePanel(new BomPrinterDraw(),databaseInterface);
                Controls.Add(commonpanel);
            }
            commonpanel.PrintIt(databaseInterface);
        }

        private void bOMGyakoriságToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(commonpanel))
            {
                bompanel = new BasePanel(new CommonPrinterDraw(), databaseInterface);
                Controls.Add(bompanel);
            }
            bompanel.PrintIt(databaseInterface);
        }

        private void szintKimutatásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(commonpanel))
            {
                levelpanel = new BasePanel(new LevelPrinterDraw(), databaseInterface);
                Controls.Add(levelpanel);
            }
            levelpanel.PrintIt(databaseInterface);
        }

        private void bOMÖsszehasonlításToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(compareprinter))
            {
                compareprinter = new CompareTreePrinter(databaseInterface);
                Controls.Add(compareprinter);
            }
            compareprinter.PrintIt(databaseInterface);
        }

        private void rawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(rawpanel))
            {
                rawpanel = new BasePanel(new RawPrinterDraw(), databaseInterface);
                Controls.Add(rawpanel);
            }
            rawpanel.PrintIt(databaseInterface);
        }
    }
}
