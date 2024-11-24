using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.Factories.Statistics.Counter.Linear;
using Darabjegyzék_feldolgozó.GUI;
using Darabjegyzék_feldolgozó.GUI.CommonListing;
using Darabjegyzék_feldolgozó.GUI.Compare;
using System.Windows.Forms;

namespace Darabjegyzék_feldolgozó
{
    public partial class Form1 : Form
    {
        private CompareTreePrinter compareprinter;
        private BomTreePrinter bomlister;
        private LevelTreePrinter levellister;
        private CommonPrinter commonlister;
        private BomHandlerMenu bomhandlermenu;
        private RawPrinter rawlister;
        private DatabaseInterface databaseInterface;
        private string path;

        public Form1()
        {
            InitializeComponent();
            databaseInterface = new DatabaseHandler();
            path = Application.StartupPath;
        }

        private void dotheredraw(Type zero)
        {
            if (zero == typeof(BomTreePrinter))
            {
                bomlister.Printthis(databaseInterface);
            }
            else if (zero == typeof(LevelTreePrinter))
            {
                levellister.Printthis(databaseInterface);
            }
            else if (zero == typeof(CommonPrinter))
            {
                commonlister.Printthis(databaseInterface);
            }
            else if (zero == typeof(BomHandlerMenu))
            {
                bomhandlermenu.Printthis(databaseInterface);
            }
            else if (zero == typeof(RawPrinter))
            {
                rawlister.Printthis(databaseInterface);
            }
        }

        private void newBomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = path;
                    openFileDialog.Multiselect = true;
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        multiselectfiles(openFileDialog.FileNames);
                        MessageBox.Show("The file is successfully loaded.");
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
            dotheredraw(Controls[0].GetType());
        }

        private void multiselectfiles(string[] paths)       
        {
            for (int i = 0;i < paths.Length ; i++)
            {
                databaseInterface.addNew(paths[i]);
            }
            path = paths[0];
        }

        private void manageBomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(bomhandlermenu))
            {
                bomhandlermenu = new BomHandlerMenu();
                Controls.Add(bomhandlermenu);
            }
            bomhandlermenu.Printthis(databaseInterface);
        }

        private void treeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(bomlister))
            {
                bomlister = new BomTreePrinter(databaseInterface);
                Controls.Add(bomlister);

            }
            bomlister.Printthis(databaseInterface);
        }

        private void bOMGyakoriságToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(commonlister))
            {
                commonlister = new CommonPrinter(databaseInterface);
                Controls.Add(commonlister);
            }
            commonlister.Printthis(databaseInterface);
        }

        private void szintKimutatásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(levellister))
            {
                levellister = new LevelTreePrinter(databaseInterface);
                Controls.Add(levellister);
            }
            levellister.Printthis(databaseInterface);
        }

        private void bOMÖsszehasonlításToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(compareprinter))
            {
                compareprinter = new CompareTreePrinter(databaseInterface);
                Controls.Add(compareprinter);
            }
            compareprinter.Printthis(databaseInterface);
        }

        private void rawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(rawlister))
            {
                rawlister = new RawPrinter(databaseInterface);
                Controls.Add(rawlister);
            }
            rawlister.Printthis(databaseInterface);
        }
    }
}
