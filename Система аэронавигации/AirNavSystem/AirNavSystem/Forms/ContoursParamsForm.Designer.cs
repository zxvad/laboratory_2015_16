namespace AirNavSystem
{
    partial class ContoursParamsForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.MedFilterUpDown = new System.Windows.Forms.NumericUpDown();
            this.ContoursThresholdUpDown = new System.Windows.Forms.NumericUpDown();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MedFilterUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContoursThresholdUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Размер окна медтанного фильтра";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Порог выделения контуров";
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(12, 90);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 3;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // MedFilterUpDown
            // 
            this.MedFilterUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.MedFilterUpDown.Location = new System.Drawing.Point(15, 25);
            this.MedFilterUpDown.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.MedFilterUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MedFilterUpDown.Name = "MedFilterUpDown";
            this.MedFilterUpDown.Size = new System.Drawing.Size(120, 20);
            this.MedFilterUpDown.TabIndex = 1;
            this.MedFilterUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ContoursThresholdUpDown
            // 
            this.ContoursThresholdUpDown.Location = new System.Drawing.Point(15, 64);
            this.ContoursThresholdUpDown.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.ContoursThresholdUpDown.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.ContoursThresholdUpDown.Name = "ContoursThresholdUpDown";
            this.ContoursThresholdUpDown.Size = new System.Drawing.Size(120, 20);
            this.ContoursThresholdUpDown.TabIndex = 2;
            this.ContoursThresholdUpDown.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(12, 119);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // ContoursParamsForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.ContoursThresholdUpDown);
            this.Controls.Add(this.MedFilterUpDown);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ContoursParamsForm";
            this.Text = "Пареметры контурного детектора";
            ((System.ComponentModel.ISupportInitialize)(this.MedFilterUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContoursThresholdUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.NumericUpDown MedFilterUpDown;
        private System.Windows.Forms.NumericUpDown ContoursThresholdUpDown;
        private System.Windows.Forms.Button cancelButton;
    }
}