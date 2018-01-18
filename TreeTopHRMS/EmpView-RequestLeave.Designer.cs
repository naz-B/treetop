namespace TreeTopHRMS
{
    partial class EmpView_RequestLeave
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.leaveType = new System.Windows.Forms.ComboBox();
            this.leaveFrom = new System.Windows.Forms.DateTimePicker();
            this.leaveTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.purpose = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(372, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Request Leave";
            // 
            // leaveType
            // 
            this.leaveType.FormattingEnabled = true;
            this.leaveType.Location = new System.Drawing.Point(374, 57);
            this.leaveType.Name = "leaveType";
            this.leaveType.Size = new System.Drawing.Size(203, 21);
            this.leaveType.TabIndex = 1;
            // 
            // leaveFrom
            // 
            this.leaveFrom.Location = new System.Drawing.Point(407, 105);
            this.leaveFrom.Name = "leaveFrom";
            this.leaveFrom.Size = new System.Drawing.Size(170, 20);
            this.leaveFrom.TabIndex = 2;
            this.leaveFrom.Tag = "";
            // 
            // leaveTo
            // 
            this.leaveTo.Location = new System.Drawing.Point(407, 145);
            this.leaveTo.Name = "leaveTo";
            this.leaveTo.Size = new System.Drawing.Size(169, 20);
            this.leaveTo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "To";
            // 
            // submit
            // 
            this.submit.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submit.Location = new System.Drawing.Point(375, 248);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 23);
            this.submit.TabIndex = 6;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = false;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // purpose
            // 
            this.purpose.Location = new System.Drawing.Point(377, 191);
            this.purpose.Name = "purpose";
            this.purpose.Size = new System.Drawing.Size(199, 20);
            this.purpose.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Reason For Leave";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Type of Leave";
            // 
            // EmpView_RequestLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(899, 425);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.purpose);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.leaveTo);
            this.Controls.Add(this.leaveFrom);
            this.Controls.Add(this.leaveType);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmpView_RequestLeave";
            this.Text = "EmpView_RequestLeave";
            this.Load += new System.EventHandler(this.EmpView_RequestLeave_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox leaveType;
        private System.Windows.Forms.DateTimePicker leaveFrom;
        private System.Windows.Forms.DateTimePicker leaveTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.TextBox purpose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}