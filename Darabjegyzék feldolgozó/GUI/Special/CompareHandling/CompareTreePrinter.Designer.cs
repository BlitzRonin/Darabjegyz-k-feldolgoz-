namespace Darabjegyzék_feldolgozó.GUI.Compare
{
    partial class CompareTreePrinter
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompareTreePrinter));
            treeView2 = new TreeView();
            treeView1 = new TreeView();
            label1 = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            comboBox2 = new ComboBox();
            button1 = new Button();
            filtermenu = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            toolStripSeparator1 = new ToolStripSeparator();
            IDmenu = new ToolStripDropDownButton();
            Serialmenu = new ToolStripDropDownButton();
            Levelmenu = new ToolStripDropDownButton();
            Itemmenu = new ToolStripDropDownButton();
            Quantitymenu = new ToolStripDropDownButton();
            UMmenu = new ToolStripDropDownButton();
            Kindmenu = new ToolStripDropDownButton();
            PTYPmenu = new ToolStripDropDownButton();
            ValidFrommenu = new ToolStripDropDownButton();
            ValidTomenu = new ToolStripDropDownButton();
            toolStripSeparator2 = new ToolStripSeparator();
            Resebutton = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            filtermenu.SuspendLayout();
            SuspendLayout();
            // 
            // treeView2
            // 
            treeView2.Location = new Point(390, 86);
            treeView2.Name = "treeView2";
            treeView2.Size = new Size(409, 488);
            treeView2.TabIndex = 5;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(3, 86);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(381, 488);
            treeView1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(0, 25);
            label1.Name = "label1";
            label1.Size = new Size(174, 23);
            label1.TabIndex = 7;
            label1.Text = "Bom összehasonlítás";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(135, 57);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 60);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 9;
            label2.Text = "1.Bom";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(509, 60);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 10;
            label3.Text = "2.Bom";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(553, 57);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 11;
            // 
            // button1
            // 
            button1.Location = new Point(340, 57);
            button1.Name = "button1";
            button1.Size = new Size(97, 23);
            button1.TabIndex = 12;
            button1.Text = "Összehasonlít";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // filtermenu
            // 
            filtermenu.Items.AddRange(new ToolStripItem[] { toolStripLabel1, toolStripSeparator1, IDmenu, Serialmenu, Levelmenu, Itemmenu, Quantitymenu, UMmenu, Kindmenu, PTYPmenu, ValidFrommenu, ValidTomenu, toolStripSeparator2, Resebutton, toolStripSeparator3 });
            filtermenu.Location = new Point(0, 0);
            filtermenu.Name = "filtermenu";
            filtermenu.Size = new Size(802, 25);
            filtermenu.TabIndex = 15;
            filtermenu.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(33, 22);
            toolStripLabel1.Text = "Filter";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // IDmenu
            // 
            IDmenu.DisplayStyle = ToolStripItemDisplayStyle.Text;
            IDmenu.Image = (Image)resources.GetObject("IDmenu.Image");
            IDmenu.ImageTransparentColor = Color.Magenta;
            IDmenu.Name = "IDmenu";
            IDmenu.Size = new Size(31, 22);
            IDmenu.Text = "ID";
            // 
            // Serialmenu
            // 
            Serialmenu.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Serialmenu.Image = (Image)resources.GetObject("Serialmenu.Image");
            Serialmenu.ImageTransparentColor = Color.Magenta;
            Serialmenu.Name = "Serialmenu";
            Serialmenu.Size = new Size(48, 22);
            Serialmenu.Text = "Serial";
            // 
            // Levelmenu
            // 
            Levelmenu.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Levelmenu.Image = (Image)resources.GetObject("Levelmenu.Image");
            Levelmenu.ImageTransparentColor = Color.Magenta;
            Levelmenu.Name = "Levelmenu";
            Levelmenu.Size = new Size(47, 22);
            Levelmenu.Text = "Level";
            // 
            // Itemmenu
            // 
            Itemmenu.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Itemmenu.Image = (Image)resources.GetObject("Itemmenu.Image");
            Itemmenu.ImageTransparentColor = Color.Magenta;
            Itemmenu.Name = "Itemmenu";
            Itemmenu.Size = new Size(44, 22);
            Itemmenu.Text = "Item";
            // 
            // Quantitymenu
            // 
            Quantitymenu.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Quantitymenu.Image = (Image)resources.GetObject("Quantitymenu.Image");
            Quantitymenu.ImageTransparentColor = Color.Magenta;
            Quantitymenu.Name = "Quantitymenu";
            Quantitymenu.Size = new Size(66, 22);
            Quantitymenu.Text = "Quantity";
            // 
            // UMmenu
            // 
            UMmenu.DisplayStyle = ToolStripItemDisplayStyle.Text;
            UMmenu.Image = (Image)resources.GetObject("UMmenu.Image");
            UMmenu.ImageTransparentColor = Color.Magenta;
            UMmenu.Name = "UMmenu";
            UMmenu.Size = new Size(39, 22);
            UMmenu.Text = "UM";
            // 
            // Kindmenu
            // 
            Kindmenu.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Kindmenu.Image = (Image)resources.GetObject("Kindmenu.Image");
            Kindmenu.ImageTransparentColor = Color.Magenta;
            Kindmenu.Name = "Kindmenu";
            Kindmenu.Size = new Size(44, 22);
            Kindmenu.Text = "Kind";
            // 
            // PTYPmenu
            // 
            PTYPmenu.DisplayStyle = ToolStripItemDisplayStyle.Text;
            PTYPmenu.Image = (Image)resources.GetObject("PTYPmenu.Image");
            PTYPmenu.ImageTransparentColor = Color.Magenta;
            PTYPmenu.Name = "PTYPmenu";
            PTYPmenu.Size = new Size(47, 22);
            PTYPmenu.Text = "PTYP";
            // 
            // ValidFrommenu
            // 
            ValidFrommenu.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ValidFrommenu.Image = (Image)resources.GetObject("ValidFrommenu.Image");
            ValidFrommenu.ImageTransparentColor = Color.Magenta;
            ValidFrommenu.Name = "ValidFrommenu";
            ValidFrommenu.Size = new Size(76, 22);
            ValidFrommenu.Text = "Valid From";
            // 
            // ValidTomenu
            // 
            ValidTomenu.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ValidTomenu.Image = (Image)resources.GetObject("ValidTomenu.Image");
            ValidTomenu.ImageTransparentColor = Color.Magenta;
            ValidTomenu.Name = "ValidTomenu";
            ValidTomenu.Size = new Size(60, 22);
            ValidTomenu.Text = "Valid To";
            ValidTomenu.ToolTipText = "Valid To";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // Resebutton
            // 
            Resebutton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            Resebutton.Image = (Image)resources.GetObject("Resebutton.Image");
            Resebutton.ImageTransparentColor = Color.Magenta;
            Resebutton.Name = "Resebutton";
            Resebutton.Size = new Size(39, 22);
            Resebutton.Text = "Reset";
            Resebutton.Click += Resetbutton_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // CompareTreePrinter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(filtermenu);
            Controls.Add(button1);
            Controls.Add(comboBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(treeView1);
            Controls.Add(treeView2);
            Location = new Point(12, 27);
            Name = "CompareTreePrinter";
            Size = new Size(802, 577);
            filtermenu.ResumeLayout(false);
            filtermenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TreeView treeView2;
        private TreeView treeView1;
        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
        private Label label3;
        private ComboBox comboBox2;
        private Button button1;
        private ToolStrip filtermenu;
        private ToolStripLabel toolStripLabel1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton IDmenu;
        private ToolStripDropDownButton Serialmenu;
        private ToolStripDropDownButton Levelmenu;
        private ToolStripDropDownButton Itemmenu;
        private ToolStripDropDownButton Quantitymenu;
        private ToolStripDropDownButton UMmenu;
        private ToolStripDropDownButton Kindmenu;
        private ToolStripDropDownButton PTYPmenu;
        private ToolStripDropDownButton ValidFrommenu;
        private ToolStripDropDownButton ValidTomenu;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton Resebutton;
        private ToolStripSeparator toolStripSeparator3;
    }
}
