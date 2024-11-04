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
        private DatabaseInterface databaseInterface;

        public Form1()
        {
            InitializeComponent();
            databaseInterface = new DatabaseHandler();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                databaseInterface.addNew(textBox1.Text);
                MessageBox.Show("The file is successfully loaded.");
                dotheredraw(Controls[0].GetType());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_doubleclick(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        textBox1.Text = openFileDialog.FileName;
                        databaseInterface.addNew(openFileDialog.FileName);
                        MessageBox.Show("The file is successfully loaded.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dotheredraw(Controls[0].GetType());
        }

        private void dotheredraw(Type zero)
        {
            if(bomlister != null && zero == bomlister.GetType())
            {
                bomlister.Printthis(databaseInterface);
            }
            else if (levellister != null &&  zero == levellister.GetType())
            {
                levellister.Printthis(databaseInterface);
            }
            else if (commonlister != null && zero == commonlister.GetType())
            {
                commonlister.Printthis(databaseInterface);
            }
            else if (bomhandlermenu != null && zero == bomhandlermenu.GetType())
            {
                bomhandlermenu.Printthis(databaseInterface);
            }
        }

        private void on_Resize(object sender, EventArgs e)
        {
            panel1.Width = Width - 10;
            textBox1.Width = panel1.Width - 120;
            button1.Location = new Point(textBox1.Width + textBox1.Location.X + 10, button1.Location.Y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(bomlister))
            {
                bomlister = new BomTreePrinter();
                Controls.Add(bomlister);
                Resize += bomlister.Resizer;

            }
            bomlister.Printthis(databaseInterface);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(levellister))
            {
                levellister = new LevelTreePrinter();
                Controls.Add(levellister);
                Resize += levellister.Resizer;
            }
            levellister.Printthis(databaseInterface);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(commonlister))
            {
                commonlister = new CommonPrinter();
                Controls.Add(commonlister);
                Resize += commonlister.Resizer;
            }
            commonlister.Printthis(databaseInterface);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(bomhandlermenu))
            {
                bomhandlermenu = new BomHandlerMenu();
                Controls.Add(bomhandlermenu);
                Resize += bomhandlermenu.Resizer;
            }
            bomhandlermenu.Printthis(databaseInterface);
        }
    }
}
