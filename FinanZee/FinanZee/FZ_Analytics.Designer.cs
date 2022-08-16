namespace FinanZee
{
    partial class FZ_Analytics
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
            this.cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            this.motionCanvas1 = new LiveChartsCore.SkiaSharpView.WinForms.MotionCanvas();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(289, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Placeholder";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(39, 118);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(659, 266);
            this.cartesianChart1.TabIndex = 1;
            this.cartesianChart1.Load += new System.EventHandler(this.cartesianChart1_Load);
            // 
            // motionCanvas1
            // 
            this.motionCanvas1.Location = new System.Drawing.Point(592, 229);
            this.motionCanvas1.MaxFps = 65D;
            this.motionCanvas1.Name = "motionCanvas1";
            this.motionCanvas1.Size = new System.Drawing.Size(129, 130);
            this.motionCanvas1.TabIndex = 2;
            this.motionCanvas1.Load += new System.EventHandler(this.motionCanvas1_Load);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(151)))), ((int)(((byte)(176)))));
            this.label8.Location = new System.Drawing.Point(22, 418);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "Detalles del último mes";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // FZ_Analytics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(733, 477);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.motionCanvas1);
            this.Controls.Add(this.cartesianChart1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FZ_Analytics";
            this.Text = "FZ_Analytics";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        private LiveChartsCore.SkiaSharpView.WinForms.MotionCanvas motionCanvas1;
        private System.Windows.Forms.Label label8;
    }
}