namespace Darabjegyzék_feldolgozó.GUI
{
    partial class LevelTreePrinter
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
            label1 = new Label();
            treeView1 = new TreeView();
            treeView2 = new TreeView();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(3, 10);
            label1.Name = "label1";
            label1.Size = new Size(126, 23);
            label1.TabIndex = 2;
            label1.Text = "Szintek listája";
            // 
            // treeView1
            // 
            treeView1.Location = new Point(3, 36);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(222, 456);
            treeView1.TabIndex = 3;
            // 
            // treeView2
            // 
            treeView2.Location = new Point(231, 36);
            treeView2.Name = "treeView2";
            treeView2.Size = new Size(458, 456);
            treeView2.TabIndex = 4;
            // 
            // LevelTreePrinter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(treeView2);
            Controls.Add(treeView1);
            Controls.Add(label1);
            Location = new Point(96, 47);
            Name = "LevelTreePrinter";
            Size = new Size(692, 495);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TreeView treeView1;
        private TreeView treeView2;
    }
}
