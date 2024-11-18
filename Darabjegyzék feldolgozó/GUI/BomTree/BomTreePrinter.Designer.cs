namespace Darabjegyzék_feldolgozó.GUI
{
    partial class BomTreePrinter
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
            treeView1 = new TreeView();
            label1 = new Label();
            filterMenu1 = new Other.FilterMenu();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(3, 115);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(796, 459);
            treeView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(3, 89);
            label1.Name = "label1";
            label1.Size = new Size(116, 23);
            label1.TabIndex = 1;
            label1.Text = "Gépek listája";
            // 
            // filterMenu1
            // 
            filterMenu1.Location = new Point(3, 3);
            filterMenu1.Name = "filterMenu1";
            filterMenu1.Size = new Size(797, 83);
            filterMenu1.TabIndex = 2;
            // 
            // BomTreePrinter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(filterMenu1);
            Controls.Add(label1);
            Controls.Add(treeView1);
            Location = new Point(12, 27);
            Name = "BomTreePrinter";
            Size = new Size(802, 577);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeView1;
        private Label label1;
        private Other.FilterMenu filterMenu1;
    }
}
