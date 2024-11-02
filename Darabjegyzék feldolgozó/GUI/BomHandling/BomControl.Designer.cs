namespace Darabjegyzék_feldolgozó.GUI.BomHandling
{
    partial class BomControl
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
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(32, 11);
            label1.Name = "label1";
            label1.Size = new Size(34, 17);
            label1.TabIndex = 0;
            label1.Text = "Név";
            // 
            // button1
            // 
            button1.BackColor = Color.LightGreen;
            button1.Dock = DockStyle.Right;
            button1.Location = new Point(413, 0);
            button1.Name = "button1";
            button1.Size = new Size(72, 40);
            button1.TabIndex = 1;
            button1.Text = "Aktív";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.Control;
            button2.Dock = DockStyle.Right;
            button2.Location = new Point(338, 0);
            button2.Name = "button2";
            button2.Size = new Size(75, 40);
            button2.TabIndex = 2;
            button2.Text = "Törlés";
            button2.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label2.Location = new Point(171, 11);
            label2.Name = "label2";
            label2.Size = new Size(46, 17);
            label2.TabIndex = 3;
            label2.Text = "Méret";
            // 
            // BomControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "BomControl";
            Size = new Size(485, 40);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Label label2;
    }
}
