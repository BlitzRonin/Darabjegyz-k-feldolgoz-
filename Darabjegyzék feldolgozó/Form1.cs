using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.GUI;
using System.Windows.Forms;

namespace Darabjegyzék_feldolgozó
{
    public partial class Form1 : Form
    {
        private BomLister lister;
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
                databaseInterface.fillthelist(textBox1.Text);
                MessageBox.Show("The file is successfully loaded.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_doubleclick(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = openFileDialog.FileName;
                    databaseInterface.fillthelist(openFileDialog.FileName);
                }
            }
        }

        private void on_Resize(object sender, EventArgs e)
        {
            panel1.Width = Width - 10;
            textBox1.Width = panel1.Width - 120;
            button1.Location = new Point(textBox1.Width + textBox1.Location.X + 10, button1.Location.Y);
            if(Controls.Contains(lister))
            {
                lister.Resizer(Height,Width);
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!Controls.Contains(lister))
            {
                lister = new BomLister(databaseInterface);
                Controls.Add(lister);
                lister.Location = new Point(96, 47);
            }
            lister.BringToFront();
        }
    }
}
