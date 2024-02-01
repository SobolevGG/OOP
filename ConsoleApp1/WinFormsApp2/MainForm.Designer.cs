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
            openFile = new ToolStripMenuItem();
            OpenParamsHU = new ToolStripMenuItem();
            saveFile = new ToolStripMenuItem();
            saveParamsHU = new ToolStripMenuItem();
            referenceButton = new ToolStripDropDownButton();
            openGuide = new ToolStripMenuItem();
            SupportToolStripMenu = new ToolStripMenuItem();
            tabControl = new TabControl();
            tabPage1 = new TabPage();
            dataGridView = new DataGridView();
            tabPage2 = new TabPage();
            groupBox3 = new GroupBox();
            this.roughZone2IndexLabel = new Label();
            this.roughZone2Label = new Label();
            this.roughZone1IndexLabel = new Label();
            this.roughZone2TextBox = new TextBox();
            this.roughZone1TextBox = new TextBox();
            textBox10 = new TextBox();
            groupBox2 = new GroupBox();
            LRRestrictionsLabel = new Label();
            inequalitySignLRComboBox = new ComboBox();
            inequalitySignURComboBox = new ComboBox();
            LRRestrictionsTextBox = new TextBox();
            URRestrictionsTextBox = new TextBox();
            powerDRGroupBox = new GroupBox();
            powerRestrictions500TextBox = new TextBox();
            powerRestrictions220TextBox = new TextBox();
            powerRestrictions500Label = new TextBox();
            powerRestrictions220Label = new TextBox();
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
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            URRestrictionsLabel = new Label();
            this.URIndexLabel = new Label();
            LRIndexLabel = new Label();
            toolStrip1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            tabPage2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            powerDRGroupBox.SuspendLayout();
            toolStrip2.SuspendLayout();
            calcGroupBox.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, referenceButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(469, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { openFile, saveFile });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(49, 22);
            toolStripDropDownButton1.Text = "Файл";
            // 
            // openFile
            // 
            openFile.DropDownItems.AddRange(new ToolStripItem[] { OpenParamsHU });
            openFile.Image = (Image)resources.GetObject("openFile.Image");
            openFile.Name = "openFile";
            openFile.Size = new Size(133, 22);
            openFile.Text = "Открыть";
            // 
            // OpenParamsHU
            // 
            OpenParamsHU.Name = "OpenParamsHU";
            OpenParamsHU.Size = new Size(155, 22);
            OpenParamsHU.Text = "Параметры ГА";
            OpenParamsHU.Click += OpenParamsHU_Click;
            // 
            // saveFile
            // 
            saveFile.DropDownItems.AddRange(new ToolStripItem[] { saveParamsHU });
            saveFile.Image = (Image)resources.GetObject("saveFile.Image");
            saveFile.Name = "saveFile";
            saveFile.Size = new Size(133, 22);
            saveFile.Text = "Сохранить";
            // 
            // saveParamsHU
            // 
            saveParamsHU.Name = "saveParamsHU";
            saveParamsHU.Size = new Size(155, 22);
            saveParamsHU.Text = "Параметры ГА";
            saveParamsHU.Click += Save_Click;
            // 
            // referenceButton
            // 
            referenceButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            referenceButton.DropDownItems.AddRange(new ToolStripItem[] { openGuide, SupportToolStripMenu });
            referenceButton.Image = (Image)resources.GetObject("referenceButton.Image");
            referenceButton.ImageTransparentColor = Color.Magenta;
            referenceButton.Name = "referenceButton";
            referenceButton.Size = new Size(66, 22);
            referenceButton.Text = "Справка";
            // 
            // openGuide
            // 
            openGuide.Image = (Image)resources.GetObject("openGuide.Image");
            openGuide.Name = "openGuide";
            openGuide.Size = new Size(206, 22);
            openGuide.Text = "Открыть";
            openGuide.Click += OpenGuide_Click;
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
            tabPage2.Controls.Add(groupBox3);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(powerDRGroupBox);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(243, 344);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ограничения";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(this.roughZone2IndexLabel);
            groupBox3.Controls.Add(this.roughZone2Label);
            groupBox3.Controls.Add(this.roughZone1IndexLabel);
            groupBox3.Controls.Add(this.roughZone2TextBox);
            groupBox3.Controls.Add(this.roughZone1TextBox);
            groupBox3.Controls.Add(textBox10);
            groupBox3.Location = new Point(34, 216);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(174, 82);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Водное управление";
            // 
            // roughZone2IndexLabel
            // 
            this.roughZone2IndexLabel.AutoSize = true;
            this.roughZone2IndexLabel.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            this.roughZone2IndexLabel.Location = new Point(25, 62);
            this.roughZone2IndexLabel.Name = "roughZone2IndexLabel";
            this.roughZone2IndexLabel.Size = new Size(26, 12);
            this.roughZone2IndexLabel.TabIndex = 7;
            this.roughZone2IndexLabel.Text = "ЗНР2";
            // 
            // roughZone2Label
            // 
            this.roughZone2Label.AutoSize = true;
            this.roughZone2Label.Location = new Point(13, 55);
            this.roughZone2Label.Name = "roughZone2Label";
            this.roughZone2Label.Size = new Size(16, 15);
            this.roughZone2Label.TabIndex = 6;
            this.roughZone2Label.Text = "Q";
            // 
            // roughZone1IndexLabel
            // 
            this.roughZone1IndexLabel.AutoSize = true;
            this.roughZone1IndexLabel.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            this.roughZone1IndexLabel.Location = new Point(25, 33);
            this.roughZone1IndexLabel.Name = "roughZone1IndexLabel";
            this.roughZone1IndexLabel.Size = new Size(26, 12);
            this.roughZone1IndexLabel.TabIndex = 5;
            this.roughZone1IndexLabel.Text = "ЗНР1";
            // 
            // roughZone2TextBox
            // 
            this.roughZone2TextBox.Location = new Point(87, 51);
            this.roughZone2TextBox.Name = "roughZone2TextBox";
            this.roughZone2TextBox.Size = new Size(66, 23);
            this.roughZone2TextBox.TabIndex = 3;
            // 
            // roughZone1TextBox
            // 
            this.roughZone1TextBox.Location = new Point(87, 22);
            this.roughZone1TextBox.Name = "roughZone1TextBox";
            this.roughZone1TextBox.Size = new Size(66, 23);
            this.roughZone1TextBox.TabIndex = 2;
            // 
            // textBox10
            // 
            textBox10.BorderStyle = BorderStyle.None;
            textBox10.Location = new Point(6, 25);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(30, 16);
            textBox10.TabIndex = 0;
            textBox10.Text = "Q";
            textBox10.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(LRIndexLabel);
            groupBox2.Controls.Add(this.URIndexLabel);
            groupBox2.Controls.Add(URRestrictionsLabel);
            groupBox2.Controls.Add(LRRestrictionsLabel);
            groupBox2.Controls.Add(inequalitySignLRComboBox);
            groupBox2.Controls.Add(inequalitySignURComboBox);
            groupBox2.Controls.Add(LRRestrictionsTextBox);
            groupBox2.Controls.Add(URRestrictionsTextBox);
            groupBox2.Location = new Point(34, 114);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(174, 82);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Водное управление";
            // 
            // LRRestrictionsLabel
            // 
            LRRestrictionsLabel.AutoSize = true;
            LRRestrictionsLabel.Location = new Point(13, 54);
            LRRestrictionsLabel.Name = "LRRestrictionsLabel";
            LRRestrictionsLabel.Size = new Size(14, 15);
            LRRestrictionsLabel.TabIndex = 7;
            LRRestrictionsLabel.Text = "Z";
            // 
            // inequalitySignLRComboBox
            // 
            inequalitySignLRComboBox.FormattingEnabled = true;
            inequalitySignLRComboBox.Items.AddRange(new object[] { ">=", "<=" });
            inequalitySignLRComboBox.Location = new Point(42, 51);
            inequalitySignLRComboBox.Name = "inequalitySignLRComboBox";
            inequalitySignLRComboBox.Size = new Size(39, 23);
            inequalitySignLRComboBox.TabIndex = 5;
            // 
            // inequalitySignURComboBox
            // 
            inequalitySignURComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            inequalitySignURComboBox.FormattingEnabled = true;
            inequalitySignURComboBox.Items.AddRange(new object[] { ">=", "<=" });
            inequalitySignURComboBox.Location = new Point(42, 22);
            inequalitySignURComboBox.Name = "inequalitySignURComboBox";
            inequalitySignURComboBox.Size = new Size(39, 23);
            inequalitySignURComboBox.TabIndex = 4;
            // 
            // LRRestrictionsTextBox
            // 
            LRRestrictionsTextBox.Location = new Point(87, 51);
            LRRestrictionsTextBox.Name = "LRRestrictionsTextBox";
            LRRestrictionsTextBox.Size = new Size(66, 23);
            LRRestrictionsTextBox.TabIndex = 3;
            // 
            // URRestrictionsTextBox
            // 
            URRestrictionsTextBox.Location = new Point(87, 22);
            URRestrictionsTextBox.Name = "URRestrictionsTextBox";
            URRestrictionsTextBox.Size = new Size(66, 23);
            URRestrictionsTextBox.TabIndex = 2;
            // 
            // powerDRGroupBox
            // 
            powerDRGroupBox.Controls.Add(powerRestrictions500TextBox);
            powerDRGroupBox.Controls.Add(powerRestrictions220TextBox);
            powerDRGroupBox.Controls.Add(powerRestrictions500Label);
            powerDRGroupBox.Controls.Add(powerRestrictions220Label);
            powerDRGroupBox.Location = new Point(34, 26);
            powerDRGroupBox.Name = "powerDRGroupBox";
            powerDRGroupBox.Size = new Size(174, 82);
            powerDRGroupBox.TabIndex = 0;
            powerDRGroupBox.TabStop = false;
            powerDRGroupBox.Text = "Схема выдачи мощности";
            // 
            // powerRestrictions500TextBox
            // 
            powerRestrictions500TextBox.Location = new Point(87, 51);
            powerRestrictions500TextBox.Name = "powerRestrictions500TextBox";
            powerRestrictions500TextBox.Size = new Size(66, 23);
            powerRestrictions500TextBox.TabIndex = 3;
            // 
            // powerRestrictions220TextBox
            // 
            powerRestrictions220TextBox.Location = new Point(87, 22);
            powerRestrictions220TextBox.Name = "powerRestrictions220TextBox";
            powerRestrictions220TextBox.Size = new Size(66, 23);
            powerRestrictions220TextBox.TabIndex = 2;
            // 
            // powerRestrictions500Label
            // 
            powerRestrictions500Label.BorderStyle = BorderStyle.None;
            powerRestrictions500Label.Location = new Point(6, 54);
            powerRestrictions500Label.Name = "powerRestrictions500Label";
            powerRestrictions500Label.Size = new Size(75, 16);
            powerRestrictions500Label.TabIndex = 1;
            powerRestrictions500Label.Text = "СВМ 500 кВ";
            powerRestrictions500Label.TextAlign = HorizontalAlignment.Center;
            // 
            // powerRestrictions220Label
            // 
            powerRestrictions220Label.BorderStyle = BorderStyle.None;
            powerRestrictions220Label.Location = new Point(6, 25);
            powerRestrictions220Label.Name = "powerRestrictions220Label";
            powerRestrictions220Label.Size = new Size(75, 16);
            powerRestrictions220Label.TabIndex = 0;
            powerRestrictions220Label.Text = "СВМ 220 кВ";
            powerRestrictions220Label.TextAlign = HorizontalAlignment.Center;
            // 
            // toolStrip2
            // 
            toolStrip2.Items.AddRange(new ToolStripItem[] { saveButton, editingModeButton, toolStripSeparator1, authorizationButton, importDBButton, exportDBButton, toolStripSeparator2, importBMPButton });
            toolStrip2.Location = new Point(0, 25);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(469, 25);
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
            editingModeButton.Click += EditingModeButton_Click;
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
            authorizationButton.Click += AuthorizationButton_Click;
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
            currentCharacteristicsToolStripMenu.Click += CurrentCharacteristicsToolStripMenu_Click;
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
            exportDBButton.Size = new Size(99, 20);
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
            CalcButton.Location = new Point(379, 279);
            CalcButton.Name = "CalcButton";
            CalcButton.Size = new Size(82, 23);
            CalcButton.TabIndex = 4;
            CalcButton.Text = "Расчёт РВР";
            CalcButton.UseVisualStyleBackColor = true;
            // 
            // calcGroupBox
            // 
            calcGroupBox.Controls.Add(textBox6);
            calcGroupBox.Controls.Add(textBox5);
            calcGroupBox.Controls.Add(label2);
            calcGroupBox.Controls.Add(label1);
            calcGroupBox.Location = new Point(261, 67);
            calcGroupBox.Name = "calcGroupBox";
            calcGroupBox.Size = new Size(200, 100);
            calcGroupBox.TabIndex = 5;
            calcGroupBox.TabStop = false;
            calcGroupBox.Text = "Уровни бьефов, м";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(36, 52);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(66, 23);
            textBox6.TabIndex = 3;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(36, 23);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(66, 23);
            textBox5.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 54);
            label2.Name = "label2";
            label2.Size = new Size(23, 15);
            label2.TabIndex = 1;
            label2.Text = "НБ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 26);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 0;
            label1.Text = "ВБ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Location = new Point(261, 173);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 100);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Расчёт РВР, МВт";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(textBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(textBox2, 0, 1);
            tableLayoutPanel1.Controls.Add(textBox3, 1, 0);
            tableLayoutPanel1.Controls.Add(textBox4, 1, 1);
            tableLayoutPanel1.Location = new Point(6, 22);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(125, 52);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Menu;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(3, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(56, 16);
            textBox1.TabIndex = 0;
            textBox1.Text = "НПРЧ";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Menu;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Location = new Point(3, 29);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(56, 16);
            textBox2.TabIndex = 1;
            textBox2.Text = "ОГ";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(65, 3);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(57, 23);
            textBox3.TabIndex = 2;
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(65, 29);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(57, 23);
            textBox4.TabIndex = 3;
            textBox4.TextAlign = HorizontalAlignment.Center;
            // 
            // URRestrictionsLabel
            // 
            URRestrictionsLabel.AutoSize = true;
            URRestrictionsLabel.Location = new Point(14, 26);
            URRestrictionsLabel.Name = "URRestrictionsLabel";
            URRestrictionsLabel.Size = new Size(14, 15);
            URRestrictionsLabel.TabIndex = 8;
            URRestrictionsLabel.Text = "Z";
            // 
            // URIndexLabel
            // 
            this.URIndexLabel.AutoSize = true;
            this.URIndexLabel.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            this.URIndexLabel.Location = new Point(23, 35);
            this.URIndexLabel.Name = "URIndexLabel";
            this.URIndexLabel.Size = new Size(15, 12);
            this.URIndexLabel.TabIndex = 9;
            this.URIndexLabel.Text = "ВБ";
            // 
            // LRIndexLabel
            // 
            LRIndexLabel.AutoSize = true;
            LRIndexLabel.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            LRIndexLabel.Location = new Point(23, 62);
            LRIndexLabel.Name = "LRIndexLabel";
            LRIndexLabel.Size = new Size(16, 12);
            LRIndexLabel.TabIndex = 10;
            LRIndexLabel.Text = "НБ";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(469, 424);
            Controls.Add(groupBox1);
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
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            powerDRGroupBox.ResumeLayout(false);
            powerDRGroupBox.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            calcGroupBox.ResumeLayout(false);
            calcGroupBox.PerformLayout();
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem openFile;
        private ToolStripMenuItem OpenParamsHU;
        private ToolStripMenuItem saveFile;
        private TabControl tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dataGridView;
        private ToolStripMenuItem saveParamsHU;
        private ToolStrip toolStrip2;
        private ToolStripButton editingModeButton;
        private ToolStripButton authorizationButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton referenceButton;
        private ToolStripMenuItem openGuide;
        private ToolStripMenuItem SupportToolStripMenu;
        private Button CalcButton;
        private GroupBox calcGroupBox;
        private ToolStripButton exportDBButton;
        private ToolStripButton importBMPButton;
        private ToolStripSeparator toolStripSeparator2;
        private GroupBox powerDRGroupBox;
        private ToolStripSplitButton saveButton;
        private ToolStripMenuItem параметрыГАToolStripMenuItem;
        private ToolStripMenuItem ограниченияToolStripMenuItem;
        private ToolStripMenuItem характеристикиГАToolStripMenuItem;
        private ToolStripSplitButton importDBButton;
        private ToolStripMenuItem currentCharacteristicsToolStripMenu;
        private ToolStripMenuItem protocolToolStripMenu;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox powerRestrictions220Label;
        private TextBox powerRestrictions220TextBox;
        private TextBox powerRestrictions500Label;
        private TextBox powerRestrictions500TextBox;
        private GroupBox groupBox2;
        private TextBox LRRestrictionsTextBox;
        private TextBox URRestrictionsTextBox;
        private TextBox LRRestrictionsLabel;
        private ComboBox inequalitySignURComboBox;
        private ComboBox inequalitySignLRComboBox;
        private Label label2;
        private Label label1;
        private TextBox textBox6;
        private TextBox textBox5;
        private GroupBox groupBox3;
        private Label label3;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox10;
        private Label label5;
        private Label label4;
        private Label label6;
        private Label LRIndexLabel;
        private Label label8;
        private Label URRestrictionsLabel;
    }
}
