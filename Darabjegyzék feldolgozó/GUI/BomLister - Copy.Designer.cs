﻿namespace Darabjegyzék_feldolgozó.GUI
{
    partial class BomLister
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
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(3, 36);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(686, 456);
            treeView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(3, 10);
            label1.Name = "label1";
            label1.Size = new Size(116, 23);
            label1.TabIndex = 1;
            label1.Text = "Gépek listája";
            // 
            // BomLister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(treeView1);
            Name = "BomLister";
            Size = new Size(692, 495);
            Load += BomLister_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeView1;
        private Label label1;
    }
}
