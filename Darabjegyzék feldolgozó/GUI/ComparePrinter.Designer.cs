namespace Darabjegyzék_feldolgozó.GUI.Compare
{
    partial class ComparePrinter
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
            filterMenu1 = new Other.FilterMenu();
            treeView2 = new TreeView();
            treeView1 = new TreeView();
            label1 = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            comboBox2 = new ComboBox();
            SuspendLayout();
            // 
            // filterMenu1
            // 
            filterMenu1.Location = new Point(3, 3);
            filterMenu1.Name = "filterMenu1";
            filterMenu1.Size = new Size(797, 83);
            filterMenu1.TabIndex = 0;
            // 
            // treeView2
            // 
            treeView2.Location = new Point(390, 145);
            treeView2.Name = "treeView2";
            treeView2.Size = new Size(409, 429);
            treeView2.TabIndex = 5;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(3, 145);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(381, 429);
            treeView1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(3, 87);
            label1.Name = "label1";
            label1.Size = new Size(174, 23);
            label1.TabIndex = 7;
            label1.Text = "Bom összehasonlítás";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(136, 116);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(92, 119);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 9;
            label2.Text = "1.Bom";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(510, 119);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 10;
            label3.Text = "2.Bom";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(554, 116);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 11;
            // 
            // ComparePrinter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(comboBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(treeView1);
            Controls.Add(treeView2);
            Controls.Add(filterMenu1);
            Location = new Point(12, 27);
            Name = "ComparePrinter";
            Size = new Size(802, 577);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Other.FilterMenu filterMenu1;
        private TreeView treeView2;
        private TreeView treeView1;
        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
        private Label label3;
        private ComboBox comboBox2;
    }
}
