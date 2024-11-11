using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.Factories.Statistics.Counter.Linear;
using Darabjegyzék_feldolgozó.GUI;
using Darabjegyzék_feldolgozó.GUI.CommonListing;
using System.Windows.Forms;

namespace Darabjegyzék_feldolgozó
{
    public partial class Form1 : Form
    {
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
                bomlister.Printthis(databaseInterface, Size);
            }
            else if (zero == typeof(LevelTreePrinter))
            {
                levellister.Printthis(databaseInterface, Size);
            }
            else if (zero == typeof(CommonPrinter))
            {
                commonlister.Printthis(databaseInterface, Size);
            }
            else if (zero == typeof(BomHandlerMenu))
            {
                bomhandlermenu.Printthis(databaseInterface, Size);
            }
            else if (zero == typeof(RawPrinter))
            {
                rawlister.Printthis(databaseInterface, Size);
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
                Resize += bomhandlermenu.Resizer;
            }
            bomhandlermenu.Printthis(databaseInterface, Size);
        }

        private void treeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(bomlister))
            {
                bomlister = new BomTreePrinter();
                Controls.Add(bomlister);
                Resize += bomlister.Resizer;

            }
            bomlister.Printthis(databaseInterface, Size);
        }

        private void bOMGyakoriságToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(commonlister))
            {
                commonlister = new CommonPrinter();
                Controls.Add(commonlister);
                Resize += commonlister.Resizer;
            }
            commonlister.Printthis(databaseInterface, Size);
        }

        private void szintKimutatásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(levellister))
            {
                levellister = new LevelTreePrinter();
                Controls.Add(levellister);
                Resize += levellister.Resizer;
            }
            levellister.Printthis(databaseInterface, Size);
        }

        private void bOMÖsszehasonlításToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(rawlister))
            {
                rawlister = new RawPrinter();
                Controls.Add(rawlister);
                Resize += rawlister.Resizer;
            }
            rawlister.Printthis(databaseInterface, Size);
        }
    }
}
