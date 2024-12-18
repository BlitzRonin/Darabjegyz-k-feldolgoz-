namespace Darabjegyzék_feldolgozó.GUI.Other.Filters
{
    partial class FilterGUI
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
            checkedListBox1 = new CheckedListBox();
            Namelabel = new Label();
            Countlabel = new Label();
            RatioLabel = new Label();
            SuspendLayout();
            // 
            // checkedListBox1
            // 
            checkedListBox1.CheckOnClick = true;
            checkedListBox1.Dock = DockStyle.Bottom;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(0, 50);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(250, 364);
            checkedListBox1.TabIndex = 0;
            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;
            // 
            // Namelabel
            // 
            Namelabel.AutoSize = true;
            Namelabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            Namelabel.Location = new Point(4, 13);
            Namelabel.Name = "Namelabel";
            Namelabel.Size = new Size(60, 21);
            Namelabel.TabIndex = 1;
            Namelabel.Text = "Name:";
            // 
            // Countlabel
            // 
            Countlabel.AutoSize = true;
            Countlabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            Countlabel.Location = new Point(143, 4);
            Countlabel.Name = "Countlabel";
            Countlabel.Size = new Size(103, 21);
            Countlabel.TabIndex = 3;
            Countlabel.Text = "All/Selected";
            // 
            // RatioLabel
            // 
            RatioLabel.AutoSize = true;
            RatioLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            RatioLabel.Location = new Point(143, 25);
            RatioLabel.Name = "RatioLabel";
            RatioLabel.Size = new Size(103, 21);
            RatioLabel.TabIndex = 4;
            RatioLabel.Text = "All/Selected";
            // 
            // FilterGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(RatioLabel);
            Controls.Add(Countlabel);
            Controls.Add(Namelabel);
            Controls.Add(checkedListBox1);
            Location = new Point(100, 100);
            Name = "FilterGUI";
            Size = new Size(250, 414);
            Leave += FilterGUI_Leave;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox checkedListBox1;
        private Label Namelabel;
        private Label Countlabel;
        private Label RatioLabel;
    }
}
