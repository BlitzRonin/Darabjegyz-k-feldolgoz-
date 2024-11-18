namespace Darabjegyzék_feldolgozó.GUI.Other
{
    partial class FilterMenu
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
            label2 = new Label();
            groupBox1 = new GroupBox();
            MinDay = new DomainUpDown();
            MinMonth = new DomainUpDown();
            MinYear = new DomainUpDown();
            label3 = new Label();
            groupBox2 = new GroupBox();
            MaxDay = new DomainUpDown();
            MaxMonth = new DomainUpDown();
            MaxYear = new DomainUpDown();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            button1 = new Button();
            button2 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(22, 17);
            label1.TabIndex = 2;
            label1.Text = "Év";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label2.Location = new Point(116, 19);
            label2.Name = "label2";
            label2.Size = new Size(49, 17);
            label2.TabIndex = 3;
            label2.Text = "Hónap";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(MinDay);
            groupBox1.Controls.Add(MinMonth);
            groupBox1.Controls.Add(MinYear);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(14, 13);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(325, 55);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Min Dátum";
            // 
            // MinDay
            // 
            MinDay.Location = new Point(257, 19);
            MinDay.Name = "MinDay";
            MinDay.Size = new Size(41, 23);
            MinDay.TabIndex = 10;
            MinDay.Text = "1";
            // 
            // MinMonth
            // 
            MinMonth.Items.Add("12");
            MinMonth.Items.Add("11");
            MinMonth.Items.Add("10");
            MinMonth.Items.Add("9");
            MinMonth.Items.Add("8");
            MinMonth.Items.Add("7");
            MinMonth.Items.Add("6");
            MinMonth.Items.Add("5");
            MinMonth.Items.Add("4");
            MinMonth.Items.Add("3");
            MinMonth.Items.Add("2");
            MinMonth.Items.Add("1");
            MinMonth.Location = new Point(171, 19);
            MinMonth.Name = "MinMonth";
            MinMonth.Size = new Size(41, 23);
            MinMonth.TabIndex = 9;
            MinMonth.Text = "1";
            // 
            // MinYear
            // 
            MinYear.Location = new Point(34, 19);
            MinYear.Name = "MinYear";
            MinYear.Size = new Size(76, 23);
            MinYear.TabIndex = 8;
            MinYear.Text = "2000";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label3.Location = new Point(218, 19);
            label3.Name = "label3";
            label3.Size = new Size(33, 17);
            label3.TabIndex = 6;
            label3.Text = "Nap";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(MaxDay);
            groupBox2.Controls.Add(MaxMonth);
            groupBox2.Controls.Add(MaxYear);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label9);
            groupBox2.Location = new Point(345, 13);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(325, 55);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Max Dátum";
            // 
            // MaxDay
            // 
            MaxDay.Location = new Point(257, 19);
            MaxDay.Name = "MaxDay";
            MaxDay.Size = new Size(41, 23);
            MaxDay.TabIndex = 10;
            MaxDay.Text = "30";
            // 
            // MaxMonth
            // 
            MaxMonth.Items.Add("12");
            MaxMonth.Items.Add("11");
            MaxMonth.Items.Add("10");
            MaxMonth.Items.Add("9");
            MaxMonth.Items.Add("8");
            MaxMonth.Items.Add("7");
            MaxMonth.Items.Add("6");
            MaxMonth.Items.Add("5");
            MaxMonth.Items.Add("4");
            MaxMonth.Items.Add("3");
            MaxMonth.Items.Add("2");
            MaxMonth.Items.Add("1");
            MaxMonth.Location = new Point(171, 19);
            MaxMonth.Name = "MaxMonth";
            MaxMonth.Size = new Size(41, 23);
            MaxMonth.TabIndex = 9;
            MaxMonth.Text = "12";
            // 
            // MaxYear
            // 
            MaxYear.Location = new Point(34, 19);
            MaxYear.Name = "MaxYear";
            MaxYear.Size = new Size(76, 23);
            MaxYear.TabIndex = 8;
            MaxYear.Text = "2024";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label7.Location = new Point(218, 19);
            label7.Name = "label7";
            label7.Size = new Size(33, 17);
            label7.TabIndex = 6;
            label7.Text = "Nap";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label8.Location = new Point(6, 19);
            label8.Name = "label8";
            label8.Size = new Size(22, 17);
            label8.TabIndex = 2;
            label8.Text = "Év";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label9.Location = new Point(116, 19);
            label9.Name = "label9";
            label9.Size = new Size(49, 17);
            label9.TabIndex = 3;
            label9.Text = "Hónap";
            // 
            // button1
            // 
            button1.Location = new Point(703, 13);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 12;
            button1.Text = "Filter";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(703, 45);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 13;
            button2.Text = "Visszaállít";
            button2.UseVisualStyleBackColor = true;
            button2.Click += this.button2_Click;
            // 
            // FilterMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FilterMenu";
            Size = new Size(797, 83);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private Label label3;
        private DomainUpDown MinYear;
        private DomainUpDown MinDay;
        private DomainUpDown MinMonth;
        private GroupBox groupBox2;
        private DomainUpDown MaxDay;
        private DomainUpDown MaxMonth;
        private DomainUpDown MaxYear;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button button1;
        private Button button2;
    }
}
