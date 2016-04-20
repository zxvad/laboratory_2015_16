namespace AirNavSystem
{
    partial class OffsetParamsForm
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
            this.LargeMedFilterUpDown = new System.Windows.Forms.NumericUpDown();
            this.SmallMedFilterUpDown = new System.Windows.Forms.NumericUpDown();
            this.OkButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LargeMedFilterUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmallMedFilterUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Размер малого медианного фильтра";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Размер большого медианного фильтра";
            // 
            // LargeMedFilterUpDown
            // 
            this.LargeMedFilterUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.LargeMedFilterUpDown.Location = new System.Drawing.Point(12, 64);
            this.LargeMedFilterUpDown.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.LargeMedFilterUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LargeMedFilterUpDown.Name = "LargeMedFilterUpDown";
            this.LargeMedFilterUpDown.Size = new System.Drawing.Size(120, 20);
            this.LargeMedFilterUpDown.TabIndex = 2;
            this.LargeMedFilterUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SmallMedFilterUpDown
            // 
            this.SmallMedFilterUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.SmallMedFilterUpDown.Location = new System.Drawing.Point(15, 25);
            this.SmallMedFilterUpDown.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.SmallMedFilterUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SmallMedFilterUpDown.Name = "SmallMedFilterUpDown";
            this.SmallMedFilterUpDown.Size = new System.Drawing.Size(120, 20);
            this.SmallMedFilterUpDown.TabIndex = 1;
            this.SmallMedFilterUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 119);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // OffsetParamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.SmallMedFilterUpDown);
            this.Controls.Add(this.LargeMedFilterUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OffsetParamsForm";
            this.Text = "Параметры определения смещения";
            ((System.ComponentModel.ISupportInitialize)(this.LargeMedFilterUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmallMedFilterUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown LargeMedFilterUpDown;
        private System.Windows.Forms.NumericUpDown SmallMedFilterUpDown;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button cancelButton;
    }
}