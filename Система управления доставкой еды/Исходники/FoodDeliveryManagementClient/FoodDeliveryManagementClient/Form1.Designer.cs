namespace FoodDeliveryManagementClient
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.ClientPage = new System.Windows.Forms.TabPage();
            this.OrderPage = new System.Windows.Forms.TabPage();
            this.MenuPage = new System.Windows.Forms.TabPage();
            this.StaffPage = new System.Windows.Forms.TabPage();
            this.CatalogPage = new System.Windows.Forms.TabPage();
            this.TabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.ClientPage);
            this.TabControl.Controls.Add(this.OrderPage);
            this.TabControl.Controls.Add(this.MenuPage);
            this.TabControl.Controls.Add(this.StaffPage);
            this.TabControl.Controls.Add(this.CatalogPage);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(554, 337);
            this.TabControl.TabIndex = 0;
            // 
            // ClientPage
            // 
            this.ClientPage.Location = new System.Drawing.Point(4, 22);
            this.ClientPage.Name = "ClientPage";
            this.ClientPage.Padding = new System.Windows.Forms.Padding(3);
            this.ClientPage.Size = new System.Drawing.Size(546, 311);
            this.ClientPage.TabIndex = 0;
            this.ClientPage.Text = "Клиенты";
            this.ClientPage.UseVisualStyleBackColor = true;
            // 
            // OrderPage
            // 
            this.OrderPage.Location = new System.Drawing.Point(4, 22);
            this.OrderPage.Name = "OrderPage";
            this.OrderPage.Padding = new System.Windows.Forms.Padding(3);
            this.OrderPage.Size = new System.Drawing.Size(276, 236);
            this.OrderPage.TabIndex = 1;
            this.OrderPage.Text = "Заказы";
            this.OrderPage.UseVisualStyleBackColor = true;
            // 
            // MenuPage
            // 
            this.MenuPage.Location = new System.Drawing.Point(4, 22);
            this.MenuPage.Name = "MenuPage";
            this.MenuPage.Size = new System.Drawing.Size(276, 236);
            this.MenuPage.TabIndex = 2;
            this.MenuPage.Text = "Меню";
            this.MenuPage.UseVisualStyleBackColor = true;
            // 
            // StaffPage
            // 
            this.StaffPage.Location = new System.Drawing.Point(4, 22);
            this.StaffPage.Name = "StaffPage";
            this.StaffPage.Size = new System.Drawing.Size(276, 236);
            this.StaffPage.TabIndex = 3;
            this.StaffPage.Text = "Сотрудники";
            this.StaffPage.UseVisualStyleBackColor = true;
            // 
            // CatalogPage
            // 
            this.CatalogPage.Location = new System.Drawing.Point(4, 22);
            this.CatalogPage.Name = "CatalogPage";
            this.CatalogPage.Size = new System.Drawing.Size(276, 236);
            this.CatalogPage.TabIndex = 4;
            this.CatalogPage.Text = "Справочники";
            this.CatalogPage.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 337);
            this.Controls.Add(this.TabControl);
            this.MinimumSize = new System.Drawing.Size(570, 375);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "FoodDeliveryManagement";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage ClientPage;
        private System.Windows.Forms.TabPage OrderPage;
        private System.Windows.Forms.TabPage MenuPage;
        private System.Windows.Forms.TabPage StaffPage;
        private System.Windows.Forms.TabPage CatalogPage;
    }
}

