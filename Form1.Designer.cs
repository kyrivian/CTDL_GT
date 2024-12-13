namespace TowersWindows
{
    partial class Form1
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
            this.DiskCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnStartOver = new System.Windows.Forms.Button();
            this.listMoves = new System.Windows.Forms.ListBox();
            this.lblMoves = new System.Windows.Forms.Label();
            this.lblCounter = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DiskCount)).BeginInit();
            this.SuspendLayout();
            // 
            // DiskCount
            // 
            this.DiskCount.Location = new System.Drawing.Point(165, 18);
            this.DiskCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DiskCount.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.DiskCount.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.DiskCount.Name = "DiskCount";
            this.DiskCount.Size = new System.Drawing.Size(75, 26);
            this.DiskCount.TabIndex = 0;
            this.DiskCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.DiskCount.ValueChanged += new System.EventHandler(this.DiskCount_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số lượng đĩa";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(270, 15);
            this.btnSolve.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(150, 35);
            this.btnSolve.TabIndex = 2;
            this.btnSolve.Text = "Giải";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.BtnSolve_Click);
            // 
            // btnStartOver
            // 
            this.btnStartOver.Location = new System.Drawing.Point(450, 15);
            this.btnStartOver.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStartOver.Name = "btnStartOver";
            this.btnStartOver.Size = new System.Drawing.Size(150, 35);
            this.btnStartOver.TabIndex = 8;
            this.btnStartOver.Text = "Làm Lại";
            this.btnStartOver.UseVisualStyleBackColor = true;
            this.btnStartOver.Click += new System.EventHandler(this.BtnStartOver_Click);
            // 
            // listMoves
            // 
            this.listMoves.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listMoves.FormattingEnabled = true;
            this.listMoves.ItemHeight = 20;
            this.listMoves.Location = new System.Drawing.Point(1230, 62);
            this.listMoves.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listMoves.Name = "listMoves";
            this.listMoves.Size = new System.Drawing.Size(343, 604);
            this.listMoves.TabIndex = 4;
            // 
            // lblMoves
            // 
            this.lblMoves.AutoSize = true;
            this.lblMoves.Location = new System.Drawing.Point(1230, 22);
            this.lblMoves.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMoves.Name = "lblMoves";
            this.lblMoves.Size = new System.Drawing.Size(138, 20);
            this.lblMoves.TabIndex = 5;
            this.lblMoves.Text = "Các lượt di chuyển";
            this.lblMoves.Click += new System.EventHandler(this.lblMoves_Click);
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(630, 22);
            this.lblCounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(226, 20);
            this.lblCounter.TabIndex = 6;
            this.lblCounter.Text = "Info: Best solution in {7} moves";
            this.lblCounter.Click += new System.EventHandler(this.lblCounter_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(22, 62);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 615);
            this.panel1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1596, 694);
            this.Controls.Add(this.btnStartOver);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.lblMoves);
            this.Controls.Add(this.listMoves);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DiskCount);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Tower of Hanoi";
            ((System.ComponentModel.ISupportInitialize)(this.DiskCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown DiskCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnStartOver;
        private System.Windows.Forms.ListBox listMoves;
        private System.Windows.Forms.Label lblMoves;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Panel panel1;
    }
}
