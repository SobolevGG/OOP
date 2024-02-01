namespace View
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
            toolStrip1 = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            openToolStripMenuItem = new ToolStripMenuItem();
            файлToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveParamsHU = new ToolStripMenuItem();
            referenceButton = new ToolStripDropDownButton();
            openDoc = new ToolStripMenuItem();
            SupportToolStripMenu = new ToolStripMenuItem();
            tabControl = new TabControl();
            tabPage1 = new TabPage();
            dataGridView = new DataGridView();
            tabPage2 = new TabPage();
            powerDRGroupBox = new GroupBox();
            powerDRtableLayoutPanel = new TableLayoutPanel();
            toolStrip2 = new ToolStrip();
            saveButton = new ToolStripSplitButton();
            параметрыГАToolStripMenuItem = new ToolStripMenuItem();
            ограниченияToolStripMenuItem = new ToolStripMenuItem();
            характеристикиГАToolStripMenuItem = new ToolStripMenuItem();
            editingModeButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            authorizationButton = new ToolStripButton();
            importDBButton = new ToolStripSplitButton();
            currentCharacteristicsToolStripMenu = new ToolStripMenuItem();
            protocolToolStripMenu = new ToolStripMenuItem();
            exportDBButton = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            importBMPButton = new ToolStripButton();
            CalcButton = new Button();
            calcGroupBox = new GroupBox();
            tableLayoutPanel = new TableLayoutPanel();
            toolStrip1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            tabPage2.SuspendLayout();
            powerDRGroupBox.SuspendLayout();
            toolStrip2.SuspendLayout();
            calcGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, referenceButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(637, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(49, 22);
            toolStripDropDownButton1.Text = "Файл";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { файлToolStripMenuItem });
            openToolStripMenuItem.Image = (Image)resources.GetObject("openToolStripMenuItem.Image");
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(133, 22);
            openToolStripMenuItem.Text = "Открыть";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(103, 22);
            файлToolStripMenuItem.Text = "Файл";
            файлToolStripMenuItem.Click += файлToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveParamsHU });
            saveToolStripMenuItem.Image = (Image)resources.GetObject("saveToolStripMenuItem.Image");
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(133, 22);
            saveToolStripMenuItem.Text = "Сохранить";
            // 
            // saveParamsHU
            // 
            saveParamsHU.Name = "saveParamsHU";
            saveParamsHU.Size = new Size(155, 22);
            saveParamsHU.Text = "Параметры ГА";
            saveParamsHU.Click += btnSave_Click;
            // 
            // referenceButton
            // 
            referenceButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            referenceButton.DropDownItems.AddRange(new ToolStripItem[] { openDoc, SupportToolStripMenu });
            referenceButton.Image = (Image)resources.GetObject("referenceButton.Image");
            referenceButton.ImageTransparentColor = Color.Magenta;
            referenceButton.Name = "referenceButton";
            referenceButton.Size = new Size(66, 22);
            referenceButton.Text = "Справка";
            // 
            // openDoc
            // 
            openDoc.Image = (Image)resources.GetObject("openDoc.Image");
            openDoc.Name = "openDoc";
            openDoc.Size = new Size(206, 22);
            openDoc.Text = "Открыть";
            openDoc.Click += openDoc_Click;
            // 
            // SupportToolStripMenu
            // 
            SupportToolStripMenu.Image = (Image)resources.GetObject("SupportToolStripMenu.Image");
            SupportToolStripMenu.Name = "SupportToolStripMenu";
            SupportToolStripMenu.Size = new Size(206, 22);
            SupportToolStripMenu.Text = "Техническая поддержка";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            tabControl.Location = new Point(0, 53);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(251, 372);
            tabControl.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(243, 344);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Параметры ГА";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(3, 3);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersVisible = false;
            dataGridView.Size = new Size(237, 338);
            dataGridView.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(powerDRGroupBox);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(243, 344);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ограничения";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // powerDRGroupBox
            // 
            powerDRGroupBox.Controls.Add(powerDRtableLayoutPanel);
            powerDRGroupBox.Location = new Point(3, 3);
            powerDRGroupBox.Name = "powerDRGroupBox";
            powerDRGroupBox.Size = new Size(174, 82);
            powerDRGroupBox.TabIndex = 0;
            powerDRGroupBox.TabStop = false;
            powerDRGroupBox.Text = "Схема выдачи мощности";
            // 
            // powerDRtableLayoutPanel
            // 
            powerDRtableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            powerDRtableLayoutPanel.ColumnCount = 2;
            powerDRtableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            powerDRtableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            powerDRtableLayoutPanel.Location = new Point(6, 22);
            powerDRtableLayoutPanel.Name = "powerDRtableLayoutPanel";
            powerDRtableLayoutPanel.RowCount = 2;
            powerDRtableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 48.8372078F));
            powerDRtableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 51.1627922F));
            powerDRtableLayoutPanel.Size = new Size(162, 52);
            powerDRtableLayoutPanel.TabIndex = 0;
            // 
            // toolStrip2
            // 
            toolStrip2.Items.AddRange(new ToolStripItem[] { saveButton, editingModeButton, toolStripSeparator1, authorizationButton, importDBButton, exportDBButton, toolStripSeparator2, importBMPButton });
            toolStrip2.Location = new Point(0, 25);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(637, 25);
            toolStrip2.TabIndex = 3;
            toolStrip2.Text = "toolStrip2";
            // 
            // saveButton
            // 
            saveButton.DropDownItems.AddRange(new ToolStripItem[] { параметрыГАToolStripMenuItem, ограниченияToolStripMenuItem, характеристикиГАToolStripMenuItem });
            saveButton.Image = (Image)resources.GetObject("saveButton.Image");
            saveButton.ImageTransparentColor = Color.Magenta;
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(98, 22);
            saveButton.Text = "Сохранить";
            // 
            // параметрыГАToolStripMenuItem
            // 
            параметрыГАToolStripMenuItem.Image = (Image)resources.GetObject("параметрыГАToolStripMenuItem.Image");
            параметрыГАToolStripMenuItem.Name = "параметрыГАToolStripMenuItem";
            параметрыГАToolStripMenuItem.Size = new Size(179, 22);
            параметрыГАToolStripMenuItem.Text = "Параметры ГА";
            // 
            // ограниченияToolStripMenuItem
            // 
            ограниченияToolStripMenuItem.Image = (Image)resources.GetObject("ограниченияToolStripMenuItem.Image");
            ограниченияToolStripMenuItem.Name = "ограниченияToolStripMenuItem";
            ограниченияToolStripMenuItem.Size = new Size(179, 22);
            ограниченияToolStripMenuItem.Text = "Ограничения";
            // 
            // характеристикиГАToolStripMenuItem
            // 
            характеристикиГАToolStripMenuItem.Image = (Image)resources.GetObject("характеристикиГАToolStripMenuItem.Image");
            характеристикиГАToolStripMenuItem.Name = "характеристикиГАToolStripMenuItem";
            характеристикиГАToolStripMenuItem.Size = new Size(179, 22);
            характеристикиГАToolStripMenuItem.Text = "Характеристики ГА";
            // 
            // editingModeButton
            // 
            editingModeButton.Image = (Image)resources.GetObject("editingModeButton.Image");
            editingModeButton.ImageTransparentColor = Color.Magenta;
            editingModeButton.Name = "editingModeButton";
            editingModeButton.Size = new Size(107, 22);
            editingModeButton.Text = "Режим правки";
            editingModeButton.Click += editingModeButton_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // authorizationButton
            // 
            authorizationButton.Image = (Image)resources.GetObject("authorizationButton.Image");
            authorizationButton.ImageTransparentColor = Color.Magenta;
            authorizationButton.Name = "authorizationButton";
            authorizationButton.Size = new Size(98, 22);
            authorizationButton.Text = "Авторизация";
            authorizationButton.Click += authorizationButton_Click;
            // 
            // importDBButton
            // 
            importDBButton.DropDownItems.AddRange(new ToolStripItem[] { currentCharacteristicsToolStripMenu, protocolToolStripMenu });
            importDBButton.Image = (Image)resources.GetObject("importDBButton.Image");
            importDBButton.ImageTransparentColor = Color.Magenta;
            importDBButton.Name = "importDBButton";
            importDBButton.Size = new Size(116, 22);
            importDBButton.Text = "Импорт из БД";
            // 
            // currentCharacteristicsToolStripMenu
            // 
            currentCharacteristicsToolStripMenu.Image = (Image)resources.GetObject("currentCharacteristicsToolStripMenu.Image");
            currentCharacteristicsToolStripMenu.Name = "currentCharacteristicsToolStripMenu";
            currentCharacteristicsToolStripMenu.Size = new Size(230, 22);
            currentCharacteristicsToolStripMenu.Text = "Актуальные характеристики";
            currentCharacteristicsToolStripMenu.Click += currentCharacteristicsToolStripMenu_Click;
            // 
            // protocolToolStripMenu
            // 
            protocolToolStripMenu.Image = (Image)resources.GetObject("protocolToolStripMenu.Image");
            protocolToolStripMenu.Name = "protocolToolStripMenu";
            protocolToolStripMenu.Size = new Size(230, 22);
            protocolToolStripMenu.Text = "Протокол актуализации";
            protocolToolStripMenu.Click += protocolToolStripMenu_Click;
            // 
            // exportDBButton
            // 
            exportDBButton.Image = (Image)resources.GetObject("exportDBButton.Image");
            exportDBButton.ImageTransparentColor = Color.Magenta;
            exportDBButton.Name = "exportDBButton";
            exportDBButton.Size = new Size(99, 22);
            exportDBButton.Text = "Экспорт в БД";
            exportDBButton.ToolTipText = "Для экспорта в БД требуется авторизация";
            exportDBButton.Click += exportDBButton_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // importBMPButton
            // 
            importBMPButton.Image = (Image)resources.GetObject("importBMPButton.Image");
            importBMPButton.ImageTransparentColor = Color.Magenta;
            importBMPButton.Name = "importBMPButton";
            importBMPButton.Size = new Size(97, 20);
            importBMPButton.Text = "Импорт ПБР";
            // 
            // CalcButton
            // 
            CalcButton.Location = new Point(379, 173);
            CalcButton.Name = "CalcButton";
            CalcButton.Size = new Size(82, 23);
            CalcButton.TabIndex = 4;
            CalcButton.Text = "Расчёт РВР";
            CalcButton.UseVisualStyleBackColor = true;
            // 
            // calcGroupBox
            // 
            calcGroupBox.Controls.Add(tableLayoutPanel);
            calcGroupBox.Location = new Point(261, 67);
            calcGroupBox.Name = "calcGroupBox";
            calcGroupBox.Size = new Size(200, 100);
            calcGroupBox.TabIndex = 5;
            calcGroupBox.TabStop = false;
            calcGroupBox.Text = "Расчёт РВР";
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Location = new Point(6, 22);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Size = new Size(125, 52);
            tableLayoutPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(637, 450);
            Controls.Add(calcGroupBox);
            Controls.Add(CalcButton);
            Controls.Add(toolStrip2);
            Controls.Add(tabControl);
            Controls.Add(toolStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Расчёт РВР";
            Load += MainForm_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            tabPage2.ResumeLayout(false);
            powerDRGroupBox.ResumeLayout(false);
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            calcGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private TabControl tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dataGridView;
        private ToolStripMenuItem paramsHUToolStripMenuItem;
        private ToolStripMenuItem saveParamsHU;
        private ToolStrip toolStrip2;
        private ToolStripButton editingModeButton;
        private ToolStripButton authorizationButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton referenceButton;
        private ToolStripMenuItem openDoc;
        private ToolStripMenuItem SupportToolStripMenu;
        private Button CalcButton;
        private GroupBox calcGroupBox;
        private TableLayoutPanel tableLayoutPanel;
        private ToolStripButton exportDBButton;
        private ToolStripButton importBMPButton;
        private ToolStripSeparator toolStripSeparator2;
        private GroupBox powerDRGroupBox;
        private TableLayoutPanel powerDRtableLayoutPanel;
        private ToolStripSplitButton saveButton;
        private ToolStripMenuItem параметрыГАToolStripMenuItem;
        private ToolStripMenuItem ограниченияToolStripMenuItem;
        private ToolStripMenuItem характеристикиГАToolStripMenuItem;
        private ToolStripSplitButton importDBButton;
        private ToolStripMenuItem currentCharacteristicsToolStripMenu;
        private ToolStripMenuItem protocolToolStripMenu;
    }
}
