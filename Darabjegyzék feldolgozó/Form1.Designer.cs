namespace Darabjegyzék_feldolgozó
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fToolStripMenuItem = new ToolStripMenuItem();
            newBomToolStripMenuItem = new ToolStripMenuItem();
            manageBomToolStripMenuItem = new ToolStripMenuItem();
            dataToolStripMenuItem = new ToolStripMenuItem();
            rawToolStripMenuItem = new ToolStripMenuItem();
            treeToolStripMenuItem = new ToolStripMenuItem();
            statisticsToolStripMenuItem = new ToolStripMenuItem();
            bOMGyakoriságToolStripMenuItem = new ToolStripMenuItem();
            szintKimutatásToolStripMenuItem = new ToolStripMenuItem();
            bOMÖsszehasonlításToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fToolStripMenuItem, dataToolStripMenuItem, statisticsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // fToolStripMenuItem
            // 
            fToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newBomToolStripMenuItem, manageBomToolStripMenuItem });
            fToolStripMenuItem.Name = "fToolStripMenuItem";
            fToolStripMenuItem.Size = new Size(37, 20);
            fToolStripMenuItem.Text = "File";
            // 
            // newBomToolStripMenuItem
            // 
            newBomToolStripMenuItem.Name = "newBomToolStripMenuItem";
            newBomToolStripMenuItem.Size = new Size(145, 22);
            newBomToolStripMenuItem.Text = "New Bom";
            newBomToolStripMenuItem.Click += newBomToolStripMenuItem_Click;
            // 
            // manageBomToolStripMenuItem
            // 
            manageBomToolStripMenuItem.Name = "manageBomToolStripMenuItem";
            manageBomToolStripMenuItem.Size = new Size(145, 22);
            manageBomToolStripMenuItem.Text = "Manage Bom";
            manageBomToolStripMenuItem.Click += manageBomToolStripMenuItem_Click;
            // 
            // dataToolStripMenuItem
            // 
            dataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rawToolStripMenuItem, treeToolStripMenuItem });
            dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            dataToolStripMenuItem.Size = new Size(43, 20);
            dataToolStripMenuItem.Text = "Data";
            // 
            // rawToolStripMenuItem
            // 
            rawToolStripMenuItem.Name = "rawToolStripMenuItem";
            rawToolStripMenuItem.Size = new Size(180, 22);
            rawToolStripMenuItem.Text = "Raw";
            rawToolStripMenuItem.Click += rawToolStripMenuItem_Click;
            // 
            // treeToolStripMenuItem
            // 
            treeToolStripMenuItem.Name = "treeToolStripMenuItem";
            treeToolStripMenuItem.Size = new Size(180, 22);
            treeToolStripMenuItem.Text = "Tree";
            treeToolStripMenuItem.Click += treeToolStripMenuItem_Click;
            // 
            // statisticsToolStripMenuItem
            // 
            statisticsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { bOMGyakoriságToolStripMenuItem, szintKimutatásToolStripMenuItem, bOMÖsszehasonlításToolStripMenuItem });
            statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            statisticsToolStripMenuItem.Size = new Size(65, 20);
            statisticsToolStripMenuItem.Text = "Statistics";
            // 
            // bOMGyakoriságToolStripMenuItem
            // 
            bOMGyakoriságToolStripMenuItem.Name = "bOMGyakoriságToolStripMenuItem";
            bOMGyakoriságToolStripMenuItem.Size = new Size(187, 22);
            bOMGyakoriságToolStripMenuItem.Text = "BOM Gyakoriság";
            bOMGyakoriságToolStripMenuItem.Click += bOMGyakoriságToolStripMenuItem_Click;
            // 
            // szintKimutatásToolStripMenuItem
            // 
            szintKimutatásToolStripMenuItem.Name = "szintKimutatásToolStripMenuItem";
            szintKimutatásToolStripMenuItem.Size = new Size(187, 22);
            szintKimutatásToolStripMenuItem.Text = "Szint Kimutatás";
            szintKimutatásToolStripMenuItem.Click += szintKimutatásToolStripMenuItem_Click;
            // 
            // bOMÖsszehasonlításToolStripMenuItem
            // 
            bOMÖsszehasonlításToolStripMenuItem.Name = "bOMÖsszehasonlításToolStripMenuItem";
            bOMÖsszehasonlításToolStripMenuItem.Size = new Size(187, 22);
            bOMÖsszehasonlításToolStripMenuItem.Text = "BOM Összehasonlítás";
            bOMÖsszehasonlításToolStripMenuItem.Click += bOMÖsszehasonlításToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 548);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(473, 452);
            Name = "Form1";
            Text = "Darabjegyzék feldolgozása";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fToolStripMenuItem;
        private ToolStripMenuItem newBomToolStripMenuItem;
        private ToolStripMenuItem manageBomToolStripMenuItem;
        private ToolStripMenuItem dataToolStripMenuItem;
        private ToolStripMenuItem rawToolStripMenuItem;
        private ToolStripMenuItem treeToolStripMenuItem;
        private ToolStripMenuItem statisticsToolStripMenuItem;
        private ToolStripMenuItem bOMGyakoriságToolStripMenuItem;
        private ToolStripMenuItem szintKimutatásToolStripMenuItem;
        private ToolStripMenuItem bOMÖsszehasonlításToolStripMenuItem;
    }
}
