namespace AirNavSystem
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.ContoursDetectionTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.DeleteContoursParamsButton = new System.Windows.Forms.Button();
            this.ContoursParamsListBox = new System.Windows.Forms.CheckedListBox();
            this.AddContoursParamsButton = new System.Windows.Forms.Button();
            this.CourseCorrectionTab = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.DeleteOffsetParamsButton = new System.Windows.Forms.Button();
            this.OffsetParamsListBox = new System.Windows.Forms.CheckedListBox();
            this.AddOffsetParamsButton = new System.Windows.Forms.Button();
            this.OpenImagesDialog = new System.Windows.Forms.OpenFileDialog();
            this.OpenImagesButton = new System.Windows.Forms.Button();
            this.ImagesListBox = new System.Windows.Forms.CheckedListBox();
            this.SelectAllImagesButton = new System.Windows.Forms.Button();
            this.UnselectAllImagesButton = new System.Windows.Forms.Button();
            this.InvertSelectedImagesButton = new System.Windows.Forms.Button();
            this.DeleteSelectedImagesButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tabControl.SuspendLayout();
            this.ContoursDetectionTab.SuspendLayout();
            this.CourseCorrectionTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.ContoursDetectionTab);
            this.tabControl.Controls.Add(this.CourseCorrectionTab);
            this.tabControl.Location = new System.Drawing.Point(224, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(220, 657);
            this.tabControl.TabIndex = 0;
            // 
            // ContoursDetectionTab
            // 
            this.ContoursDetectionTab.Controls.Add(this.label1);
            this.ContoursDetectionTab.Controls.Add(this.radioButton4);
            this.ContoursDetectionTab.Controls.Add(this.radioButton3);
            this.ContoursDetectionTab.Controls.Add(this.radioButton2);
            this.ContoursDetectionTab.Controls.Add(this.radioButton1);
            this.ContoursDetectionTab.Controls.Add(this.button1);
            this.ContoursDetectionTab.Controls.Add(this.DeleteContoursParamsButton);
            this.ContoursDetectionTab.Controls.Add(this.ContoursParamsListBox);
            this.ContoursDetectionTab.Controls.Add(this.AddContoursParamsButton);
            this.ContoursDetectionTab.Location = new System.Drawing.Point(4, 22);
            this.ContoursDetectionTab.Name = "ContoursDetectionTab";
            this.ContoursDetectionTab.Padding = new System.Windows.Forms.Padding(3);
            this.ContoursDetectionTab.Size = new System.Drawing.Size(212, 631);
            this.ContoursDetectionTab.TabIndex = 0;
            this.ContoursDetectionTab.Text = "Выделение контуров";
            this.ContoursDetectionTab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 523);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Режим отображения";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 608);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(139, 17);
            this.radioButton4.TabIndex = 13;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Контуры изображений";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 585);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(151, 17);
            this.radioButton3.TabIndex = 12;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Градиенты изображений";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 562);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(190, 17);
            this.radioButton2.TabIndex = 11;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Отфильтрованные изображения";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 539);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(171, 17);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Оригинальные изображения";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 497);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Выполнить выделение контуров";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DeleteContoursParamsButton
            // 
            this.DeleteContoursParamsButton.Location = new System.Drawing.Point(6, 345);
            this.DeleteContoursParamsButton.Name = "DeleteContoursParamsButton";
            this.DeleteContoursParamsButton.Size = new System.Drawing.Size(129, 23);
            this.DeleteContoursParamsButton.TabIndex = 8;
            this.DeleteContoursParamsButton.Text = "Удалить выделенное";
            this.DeleteContoursParamsButton.UseVisualStyleBackColor = true;
            this.DeleteContoursParamsButton.Click += new System.EventHandler(this.DeleteContoursParamsButton_Click);
            // 
            // ContoursParamsListBox
            // 
            this.ContoursParamsListBox.FormattingEnabled = true;
            this.ContoursParamsListBox.Location = new System.Drawing.Point(6, 35);
            this.ContoursParamsListBox.Name = "ContoursParamsListBox";
            this.ContoursParamsListBox.Size = new System.Drawing.Size(200, 304);
            this.ContoursParamsListBox.TabIndex = 1;
            // 
            // AddContoursParamsButton
            // 
            this.AddContoursParamsButton.Location = new System.Drawing.Point(6, 6);
            this.AddContoursParamsButton.Name = "AddContoursParamsButton";
            this.AddContoursParamsButton.Size = new System.Drawing.Size(155, 23);
            this.AddContoursParamsButton.TabIndex = 0;
            this.AddContoursParamsButton.Text = "Новый список параметров";
            this.AddContoursParamsButton.UseVisualStyleBackColor = true;
            this.AddContoursParamsButton.Click += new System.EventHandler(this.AddContoursParamsButton_Click);
            // 
            // CourseCorrectionTab
            // 
            this.CourseCorrectionTab.Controls.Add(this.label2);
            this.CourseCorrectionTab.Controls.Add(this.button2);
            this.CourseCorrectionTab.Controls.Add(this.DeleteOffsetParamsButton);
            this.CourseCorrectionTab.Controls.Add(this.OffsetParamsListBox);
            this.CourseCorrectionTab.Controls.Add(this.AddOffsetParamsButton);
            this.CourseCorrectionTab.Location = new System.Drawing.Point(4, 22);
            this.CourseCorrectionTab.Name = "CourseCorrectionTab";
            this.CourseCorrectionTab.Padding = new System.Windows.Forms.Padding(3);
            this.CourseCorrectionTab.Size = new System.Drawing.Size(212, 631);
            this.CourseCorrectionTab.TabIndex = 1;
            this.CourseCorrectionTab.Text = "Коррекция курса";
            this.CourseCorrectionTab.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 501);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Режим отображения";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 475);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Выполнить определение смещения";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // DeleteOffsetParamsButton
            // 
            this.DeleteOffsetParamsButton.Location = new System.Drawing.Point(6, 345);
            this.DeleteOffsetParamsButton.Name = "DeleteOffsetParamsButton";
            this.DeleteOffsetParamsButton.Size = new System.Drawing.Size(129, 23);
            this.DeleteOffsetParamsButton.TabIndex = 17;
            this.DeleteOffsetParamsButton.Text = "Удалить выделенное";
            this.DeleteOffsetParamsButton.UseVisualStyleBackColor = true;
            this.DeleteOffsetParamsButton.Click += new System.EventHandler(this.DeleteOffsetParamsButton_Click);
            // 
            // OffsetParamsListBox
            // 
            this.OffsetParamsListBox.FormattingEnabled = true;
            this.OffsetParamsListBox.Location = new System.Drawing.Point(6, 35);
            this.OffsetParamsListBox.Name = "OffsetParamsListBox";
            this.OffsetParamsListBox.Size = new System.Drawing.Size(200, 304);
            this.OffsetParamsListBox.TabIndex = 16;
            // 
            // AddOffsetParamsButton
            // 
            this.AddOffsetParamsButton.Location = new System.Drawing.Point(6, 6);
            this.AddOffsetParamsButton.Name = "AddOffsetParamsButton";
            this.AddOffsetParamsButton.Size = new System.Drawing.Size(155, 23);
            this.AddOffsetParamsButton.TabIndex = 15;
            this.AddOffsetParamsButton.Text = "Новый список параметров";
            this.AddOffsetParamsButton.UseVisualStyleBackColor = true;
            this.AddOffsetParamsButton.Click += new System.EventHandler(this.AddOffsetParamsButton_Click);
            // 
            // OpenImagesDialog
            // 
            this.OpenImagesDialog.Filter = "Изображения|*.bmp";
            this.OpenImagesDialog.Multiselect = true;
            this.OpenImagesDialog.SupportMultiDottedExtensions = true;
            this.OpenImagesDialog.Title = "Выбор Изображений";
            // 
            // OpenImagesButton
            // 
            this.OpenImagesButton.Location = new System.Drawing.Point(12, 12);
            this.OpenImagesButton.Name = "OpenImagesButton";
            this.OpenImagesButton.Size = new System.Drawing.Size(206, 23);
            this.OpenImagesButton.TabIndex = 1;
            this.OpenImagesButton.Text = "Выбрать изображения";
            this.OpenImagesButton.UseVisualStyleBackColor = true;
            this.OpenImagesButton.Click += new System.EventHandler(this.OpenImagesButton_Click);
            // 
            // ImagesListBox
            // 
            this.ImagesListBox.FormattingEnabled = true;
            this.ImagesListBox.Location = new System.Drawing.Point(12, 41);
            this.ImagesListBox.Name = "ImagesListBox";
            this.ImagesListBox.Size = new System.Drawing.Size(206, 514);
            this.ImagesListBox.TabIndex = 3;
            // 
            // SelectAllImagesButton
            // 
            this.SelectAllImagesButton.Location = new System.Drawing.Point(12, 559);
            this.SelectAllImagesButton.Name = "SelectAllImagesButton";
            this.SelectAllImagesButton.Size = new System.Drawing.Size(129, 23);
            this.SelectAllImagesButton.TabIndex = 4;
            this.SelectAllImagesButton.Text = "Выделить все";
            this.SelectAllImagesButton.UseVisualStyleBackColor = true;
            this.SelectAllImagesButton.Click += new System.EventHandler(this.SelectAllImagesButton_Click);
            // 
            // UnselectAllImagesButton
            // 
            this.UnselectAllImagesButton.Location = new System.Drawing.Point(12, 588);
            this.UnselectAllImagesButton.Name = "UnselectAllImagesButton";
            this.UnselectAllImagesButton.Size = new System.Drawing.Size(129, 23);
            this.UnselectAllImagesButton.TabIndex = 5;
            this.UnselectAllImagesButton.Text = "Снять выделение";
            this.UnselectAllImagesButton.UseVisualStyleBackColor = true;
            this.UnselectAllImagesButton.Click += new System.EventHandler(this.UnselectAllImagesButton_Click);
            // 
            // InvertSelectedImagesButton
            // 
            this.InvertSelectedImagesButton.Location = new System.Drawing.Point(12, 617);
            this.InvertSelectedImagesButton.Name = "InvertSelectedImagesButton";
            this.InvertSelectedImagesButton.Size = new System.Drawing.Size(129, 23);
            this.InvertSelectedImagesButton.TabIndex = 6;
            this.InvertSelectedImagesButton.Text = "Обратить выделение";
            this.InvertSelectedImagesButton.UseVisualStyleBackColor = true;
            this.InvertSelectedImagesButton.Click += new System.EventHandler(this.InvertSelectedImagesButton_Click);
            // 
            // DeleteSelectedImagesButton
            // 
            this.DeleteSelectedImagesButton.Location = new System.Drawing.Point(12, 646);
            this.DeleteSelectedImagesButton.Name = "DeleteSelectedImagesButton";
            this.DeleteSelectedImagesButton.Size = new System.Drawing.Size(129, 23);
            this.DeleteSelectedImagesButton.TabIndex = 7;
            this.DeleteSelectedImagesButton.Text = "Удалить выделенное";
            this.DeleteSelectedImagesButton.UseVisualStyleBackColor = true;
            this.DeleteSelectedImagesButton.Click += new System.EventHandler(this.DeleteSelectedImagesButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(450, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(802, 653);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 8;
            this.pictureBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.DeleteSelectedImagesButton);
            this.Controls.Add(this.InvertSelectedImagesButton);
            this.Controls.Add(this.UnselectAllImagesButton);
            this.Controls.Add(this.SelectAllImagesButton);
            this.Controls.Add(this.ImagesListBox);
            this.Controls.Add(this.OpenImagesButton);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Система аэронавигации";
            this.tabControl.ResumeLayout(false);
            this.ContoursDetectionTab.ResumeLayout(false);
            this.ContoursDetectionTab.PerformLayout();
            this.CourseCorrectionTab.ResumeLayout(false);
            this.CourseCorrectionTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage ContoursDetectionTab;
        private System.Windows.Forms.TabPage CourseCorrectionTab;
        private System.Windows.Forms.OpenFileDialog OpenImagesDialog;
        private System.Windows.Forms.Button OpenImagesButton;
        private System.Windows.Forms.CheckedListBox ImagesListBox;
        private System.Windows.Forms.Button SelectAllImagesButton;
        private System.Windows.Forms.Button UnselectAllImagesButton;
        private System.Windows.Forms.Button InvertSelectedImagesButton;
        private System.Windows.Forms.Button DeleteSelectedImagesButton;
        private System.Windows.Forms.Button AddContoursParamsButton;
        private System.Windows.Forms.Button DeleteContoursParamsButton;
        private System.Windows.Forms.CheckedListBox ContoursParamsListBox;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button DeleteOffsetParamsButton;
        private System.Windows.Forms.CheckedListBox OffsetParamsListBox;
        private System.Windows.Forms.Button AddOffsetParamsButton;
    }
}

