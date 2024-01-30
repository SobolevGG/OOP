namespace WinFormsApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            создатьToolStripMenuItem = new ToolStripMenuItem();
            saveWaterFlow = new ToolStripMenuItem();
            ограниченияToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            openWaterFlow = new ToolStripMenuItem();
            openRestrictions = new ToolStripMenuItem();
            расчётToolStripMenuItem = new ToolStripMenuItem();
            расчётToolStripMenuItem1 = new ToolStripMenuItem();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            toolButtonAuthorization = new ToolStripButton();
            saveToolStripButton = new ToolStripButton();
            toolStripSeparator = new ToolStripSeparator();
            справкаToolStripButton = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            экспортВБДToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, расчётToolStripMenuItem, справкаToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { создатьToolStripMenuItem, открытьToolStripMenuItem, экспортВБДToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // создатьToolStripMenuItem
            // 
            создатьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveWaterFlow, ограниченияToolStripMenuItem });
            создатьToolStripMenuItem.Image = (Image)resources.GetObject("создатьToolStripMenuItem.Image");
            создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            создатьToolStripMenuItem.Size = new Size(180, 22);
            создатьToolStripMenuItem.Text = "Сохранить";
            // 
            // saveWaterFlow
            // 
            saveWaterFlow.Name = "saveWaterFlow";
            saveWaterFlow.Size = new Size(152, 22);
            saveWaterFlow.Text = "Расходы воды";
            saveWaterFlow.Click += saveWaterFlow_Click;
            // 
            // ограниченияToolStripMenuItem
            // 
            ограниченияToolStripMenuItem.Name = "ограниченияToolStripMenuItem";
            ограниченияToolStripMenuItem.Size = new Size(152, 22);
            ограниченияToolStripMenuItem.Text = "Ограничения";
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openWaterFlow, openRestrictions });
            открытьToolStripMenuItem.Image = (Image)resources.GetObject("открытьToolStripMenuItem.Image");
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(180, 22);
            открытьToolStripMenuItem.Text = "Открыть";
            // 
            // openWaterFlow
            // 
            openWaterFlow.Name = "openWaterFlow";
            openWaterFlow.Size = new Size(152, 22);
            openWaterFlow.Text = "Расходы воды";
            openWaterFlow.Click += openWaterFlow_Click;
            // 
            // openRestrictions
            // 
            openRestrictions.Name = "openRestrictions";
            openRestrictions.Size = new Size(152, 22);
            openRestrictions.Text = "Ограничения";
            // 
            // расчётToolStripMenuItem
            // 
            расчётToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { расчётToolStripMenuItem1 });
            расчётToolStripMenuItem.Name = "расчётToolStripMenuItem";
            расчётToolStripMenuItem.Size = new Size(56, 20);
            расчётToolStripMenuItem.Text = "Расчёт";
            // 
            // расчётToolStripMenuItem1
            // 
            расчётToolStripMenuItem1.Name = "расчётToolStripMenuItem1";
            расчётToolStripMenuItem1.Size = new Size(111, 22);
            расчётToolStripMenuItem1.Text = "Расчёт";
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(65, 20);
            справкаToolStripMenuItem.Text = "Справка";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { this.saveToolStripButton, toolStripSeparator, toolButtonAuthorization, toolStripButton1, toolStripSeparator1, справкаToolStripButton });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolButtonAuthorization
            // 
            toolButtonAuthorization.Image = (Image)resources.GetObject("toolButtonAuthorization.Image");
            toolButtonAuthorization.ImageTransparentColor = Color.Magenta;
            toolButtonAuthorization.Name = "toolButtonAuthorization";
            toolButtonAuthorization.Size = new Size(98, 22);
            toolButtonAuthorization.Text = "Авторизация";

            // 
            // saveToolStripButton
            // 
            saveToolStripButton.Image = (Image)resources.GetObject("saveToolStripButton.Image");
            saveToolStripButton.ImageTransparentColor = Color.Magenta;
            saveToolStripButton.Name = "saveToolStripButton";
            saveToolStripButton.Size = new Size(86, 22);
            saveToolStripButton.Text = "&Сохранить";
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(6, 25);
            // 
            // справкаToolStripButton
            // 
            справкаToolStripButton.Image = (Image)resources.GetObject("справкаToolStripButton.Image");
            справкаToolStripButton.ImageTransparentColor = Color.Magenta;
            справкаToolStripButton.Name = "справкаToolStripButton";
            справкаToolStripButton.Size = new Size(73, 22);
            справкаToolStripButton.Text = "С&правка";
            // 
            // toolStripButton1
            // 
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(86, 22);
            toolStripButton1.Text = "Сохранить";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // экспортВБДToolStripMenuItem
            // 
            экспортВБДToolStripMenuItem.Name = "экспортВБДToolStripMenuItem";
            экспортВБДToolStripMenuItem.Size = new Size(180, 22);
            экспортВБДToolStripMenuItem.Text = "Б";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem расчётToolStripMenuItem;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private ToolStripMenuItem создатьToolStripMenuItem;
        private ToolStripMenuItem saveWaterFlow;
        private ToolStripMenuItem ограниченияToolStripMenuItem;
        private ToolStripMenuItem расчётToolStripMenuItem1;
        private ToolStrip toolStrip1;
        private ToolStripButton toolButtonAuthorization;
        private ToolStripButton toolStripButton2;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem openWaterFlow;
        private ToolStripMenuItem openRestrictions;
        private ToolStripButton создатьToolStripButton;
        private ToolStripButton открытьToolStripButton;
        private ToolStripButton saveToolStripButton;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripButton справкаToolStripButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton1;
        private ToolStripMenuItem экспортВБДToolStripMenuItem;
        private DataGridView dataGridView;
    }
}
