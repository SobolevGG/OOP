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
            toolStrip = new ToolStrip();
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
            label4 = new Label();
            label2 = new Label();
            label7 = new Label();
            label3 = new Label();
            roughZone2Label = new Label();
            label1 = new Label();
            roughZone1Label = new Label();
            textBox8 = new TextBox();
            textBox7 = new TextBox();
            secondLabel = new Label();
            groupBox2 = new GroupBox();
            URRestrictionsLabel = new Label();
            URIndexLabel = new Label();
            LRIndexLabel = new Label();
            LRRestrictionsLabel = new Label();
            inequalitySignLRComboBox = new ComboBox();
            inequalitySignURComboBox = new ComboBox();
            LRRestrictionsTextBox = new TextBox();
            URRestrictionsTextBox = new TextBox();
            powerDRGroupBox = new GroupBox();
            powerRestrictions500Label = new Label();
            powerRestrictions220Label = new Label();
            powerRestrictions500TextBox = new TextBox();
            powerRestrictions220TextBox = new TextBox();
            toolBar = new ToolStrip();
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
            ULRGroupBox = new GroupBox();
            LRTextBox = new TextBox();
            URTextBox = new TextBox();
            LRLabel = new Label();
            URLabel = new Label();
            calcGroupBox = new GroupBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            restrictions220IndexLabel = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            toolStrip.SuspendLayout();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            tabPage2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            powerDRGroupBox.SuspendLayout();
            toolBar.SuspendLayout();
            ULRGroupBox.SuspendLayout();
            calcGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, referenceButton });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(469, 25);
            toolStrip.TabIndex = 0;
            toolStrip.Text = "toolStrip1";
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
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(roughZone2Label);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(roughZone1Label);
            groupBox3.Controls.Add(textBox8);
            groupBox3.Controls.Add(textBox7);
            groupBox3.Controls.Add(secondLabel);
            groupBox3.Location = new Point(3, 202);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(205, 82);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "groupBox3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(63, 47);
            label4.Name = "label4";
            label4.Size = new Size(10, 12);
            label4.TabIndex = 19;
            label4.Text = "3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 51);
            label2.Name = "label2";
            label2.Size = new Size(21, 15);
            label2.TabIndex = 18;
            label2.Text = "/с:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label7.Location = new Point(63, 21);
            label7.Name = "label7";
            label7.Size = new Size(10, 12);
            label7.TabIndex = 16;
            label7.Text = "3";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(22, 59);
            label3.Name = "label3";
            label3.Size = new Size(26, 12);
            label3.TabIndex = 14;
            label3.Text = "ЗНР2";
            // 
            // roughZone2Label
            // 
            roughZone2Label.AutoSize = true;
            roughZone2Label.Location = new Point(10, 51);
            roughZone2Label.Name = "roughZone2Label";
            roughZone2Label.Size = new Size(61, 15);
            roughZone2Label.TabIndex = 15;
            roughZone2Label.Text = "Q         , м ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(22, 33);
            label1.Name = "label1";
            label1.Size = new Size(26, 12);
            label1.TabIndex = 12;
            label1.Text = "ЗНР1";
            // 
            // roughZone1Label
            // 
            roughZone1Label.AutoSize = true;
            roughZone1Label.Location = new Point(10, 25);
            roughZone1Label.Name = "roughZone1Label";
            roughZone1Label.Size = new Size(61, 15);
            roughZone1Label.TabIndex = 13;
            roughZone1Label.Text = "Q         , м ";
            roughZone1Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(110, 51);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(66, 23);
            textBox8.TabIndex = 3;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(110, 22);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(66, 23);
            textBox7.TabIndex = 2;
            // 
            // secondLabel
            // 
            secondLabel.AutoSize = true;
            secondLabel.Location = new Point(68, 25);
            secondLabel.Name = "secondLabel";
            secondLabel.Size = new Size(21, 15);
            secondLabel.TabIndex = 17;
            secondLabel.Text = "/с:";
            secondLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(URIndexLabel);
            groupBox2.Controls.Add(LRIndexLabel);
            groupBox2.Controls.Add(LRRestrictionsLabel);
            groupBox2.Controls.Add(inequalitySignLRComboBox);
            groupBox2.Controls.Add(inequalitySignURComboBox);
            groupBox2.Controls.Add(LRRestrictionsTextBox);
            groupBox2.Controls.Add(URRestrictionsTextBox);
            groupBox2.Controls.Add(URRestrictionsLabel);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label12);
            groupBox2.Location = new Point(3, 114);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(205, 82);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Водное управление";
            // 
            // URRestrictionsLabel
            // 
            URRestrictionsLabel.AutoSize = true;
            URRestrictionsLabel.Location = new Point(10, 26);
            URRestrictionsLabel.Name = "URRestrictionsLabel";
            URRestrictionsLabel.Size = new Size(46, 15);
            URRestrictionsLabel.TabIndex = 8;
            URRestrictionsLabel.Text = "Q     , м";
            // 
            // URIndexLabel
            // 
            URIndexLabel.AutoSize = true;
            URIndexLabel.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            URIndexLabel.Location = new Point(22, 35);
            URIndexLabel.Name = "URIndexLabel";
            URIndexLabel.Size = new Size(15, 12);
            URIndexLabel.TabIndex = 12;
            URIndexLabel.Text = "ВБ";
            // 
            // LRIndexLabel
            // 
            LRIndexLabel.AutoSize = true;
            LRIndexLabel.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            LRIndexLabel.Location = new Point(22, 63);
            LRIndexLabel.Name = "LRIndexLabel";
            LRIndexLabel.Size = new Size(16, 12);
            LRIndexLabel.TabIndex = 10;
            LRIndexLabel.Text = "НБ";
            // 
            // LRRestrictionsLabel
            // 
            LRRestrictionsLabel.AutoSize = true;
            LRRestrictionsLabel.Location = new Point(10, 54);
            LRRestrictionsLabel.Name = "LRRestrictionsLabel";
            LRRestrictionsLabel.Size = new Size(46, 15);
            LRRestrictionsLabel.TabIndex = 11;
            LRRestrictionsLabel.Text = "Q     , м";
            // 
            // inequalitySignLRComboBox
            // 
            inequalitySignLRComboBox.FormattingEnabled = true;
            inequalitySignLRComboBox.Items.AddRange(new object[] { ">=", "<=" });
            inequalitySignLRComboBox.Location = new Point(78, 51);
            inequalitySignLRComboBox.Name = "inequalitySignLRComboBox";
            inequalitySignLRComboBox.Size = new Size(39, 23);
            inequalitySignLRComboBox.TabIndex = 5;
            // 
            // inequalitySignURComboBox
            // 
            inequalitySignURComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            inequalitySignURComboBox.FormattingEnabled = true;
            inequalitySignURComboBox.Items.AddRange(new object[] { ">=", "<=" });
            inequalitySignURComboBox.Location = new Point(78, 22);
            inequalitySignURComboBox.Name = "inequalitySignURComboBox";
            inequalitySignURComboBox.Size = new Size(39, 23);
            inequalitySignURComboBox.TabIndex = 4;
            // 
            // LRRestrictionsTextBox
            // 
            LRRestrictionsTextBox.Location = new Point(123, 51);
            LRRestrictionsTextBox.Name = "LRRestrictionsTextBox";
            LRRestrictionsTextBox.Size = new Size(66, 23);
            LRRestrictionsTextBox.TabIndex = 3;
            // 
            // URRestrictionsTextBox
            // 
            URRestrictionsTextBox.Location = new Point(123, 22);
            URRestrictionsTextBox.Name = "URRestrictionsTextBox";
            URRestrictionsTextBox.Size = new Size(66, 23);
            URRestrictionsTextBox.TabIndex = 2;
            // 
            // powerDRGroupBox
            // 
            powerDRGroupBox.Controls.Add(label8);
            powerDRGroupBox.Controls.Add(restrictions220IndexLabel);
            powerDRGroupBox.Controls.Add(powerRestrictions500Label);
            powerDRGroupBox.Controls.Add(powerRestrictions220Label);
            powerDRGroupBox.Controls.Add(powerRestrictions500TextBox);
            powerDRGroupBox.Controls.Add(powerRestrictions220TextBox);
            powerDRGroupBox.Location = new Point(3, 26);
            powerDRGroupBox.Name = "powerDRGroupBox";
            powerDRGroupBox.Size = new Size(205, 82);
            powerDRGroupBox.TabIndex = 0;
            powerDRGroupBox.TabStop = false;
            powerDRGroupBox.Text = "Схема выдачи мощности";
            // 
            // powerRestrictions500Label
            // 
            powerRestrictions500Label.AutoSize = true;
            powerRestrictions500Label.Location = new Point(10, 55);
            powerRestrictions500Label.Name = "powerRestrictions500Label";
            powerRestrictions500Label.Size = new Size(97, 15);
            powerRestrictions500Label.TabIndex = 5;
            powerRestrictions500Label.Text = "P                 , МВт:";
            // 
            // powerRestrictions220Label
            // 
            powerRestrictions220Label.AutoSize = true;
            powerRestrictions220Label.Location = new Point(10, 26);
            powerRestrictions220Label.Name = "powerRestrictions220Label";
            powerRestrictions220Label.Size = new Size(97, 15);
            powerRestrictions220Label.TabIndex = 4;
            powerRestrictions220Label.Text = "P                 , МВт:";
            // 
            // powerRestrictions500TextBox
            // 
            powerRestrictions500TextBox.Location = new Point(110, 51);
            powerRestrictions500TextBox.Name = "powerRestrictions500TextBox";
            powerRestrictions500TextBox.Size = new Size(66, 23);
            powerRestrictions500TextBox.TabIndex = 3;
            // 
            // powerRestrictions220TextBox
            // 
            powerRestrictions220TextBox.Location = new Point(110, 22);
            powerRestrictions220TextBox.Name = "powerRestrictions220TextBox";
            powerRestrictions220TextBox.Size = new Size(66, 23);
            powerRestrictions220TextBox.TabIndex = 2;
            // 
            // toolBar
            // 
            toolBar.Items.AddRange(new ToolStripItem[] { saveButton, editingModeButton, toolStripSeparator1, authorizationButton, importDBButton, exportDBButton, toolStripSeparator2, importBMPButton });
            toolBar.Location = new Point(0, 25);
            toolBar.Name = "toolBar";
            toolBar.Size = new Size(469, 25);
            toolBar.TabIndex = 3;
            toolBar.Text = "toolStrip2";
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
            // ULRGroupBox
            // 
            ULRGroupBox.Controls.Add(LRTextBox);
            ULRGroupBox.Controls.Add(URTextBox);
            ULRGroupBox.Controls.Add(LRLabel);
            ULRGroupBox.Controls.Add(URLabel);
            ULRGroupBox.Location = new Point(261, 67);
            ULRGroupBox.Name = "ULRGroupBox";
            ULRGroupBox.Size = new Size(200, 100);
            ULRGroupBox.TabIndex = 5;
            ULRGroupBox.TabStop = false;
            ULRGroupBox.Text = "Уровни бьефов, м";
            // 
            // LRTextBox
            // 
            LRTextBox.Location = new Point(87, 52);
            LRTextBox.Name = "LRTextBox";
            LRTextBox.Size = new Size(66, 23);
            LRTextBox.TabIndex = 3;
            // 
            // URTextBox
            // 
            URTextBox.Location = new Point(87, 23);
            URTextBox.Name = "URTextBox";
            URTextBox.Size = new Size(66, 23);
            URTextBox.TabIndex = 2;
            // 
            // LRLabel
            // 
            LRLabel.AutoSize = true;
            LRLabel.Location = new Point(9, 56);
            LRLabel.Name = "LRLabel";
            LRLabel.Size = new Size(26, 15);
            LRLabel.TabIndex = 1;
            LRLabel.Text = "НБ:";
            // 
            // URLabel
            // 
            URLabel.AutoSize = true;
            URLabel.Location = new Point(9, 27);
            URLabel.Name = "URLabel";
            URLabel.Size = new Size(24, 15);
            URLabel.TabIndex = 0;
            URLabel.Text = "ВБ:";
            // 
            // calcGroupBox
            // 
            calcGroupBox.Controls.Add(textBox2);
            calcGroupBox.Controls.Add(textBox1);
            calcGroupBox.Controls.Add(label6);
            calcGroupBox.Controls.Add(label5);
            calcGroupBox.Location = new Point(261, 173);
            calcGroupBox.Name = "calcGroupBox";
            calcGroupBox.Size = new Size(200, 100);
            calcGroupBox.TabIndex = 6;
            calcGroupBox.TabStop = false;
            calcGroupBox.Text = "Расчёт РВР, МВт";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(87, 49);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(66, 23);
            textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(87, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(66, 23);
            textBox1.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 52);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 1;
            label6.Text = "ПА, МВт:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 26);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 0;
            label5.Text = "НПРЧ, МВт:";
            // 
            // restrictions220IndexLabel
            // 
            restrictions220IndexLabel.AutoSize = true;
            restrictions220IndexLabel.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            restrictions220IndexLabel.Location = new Point(19, 33);
            restrictions220IndexLabel.Name = "restrictions220IndexLabel";
            restrictions220IndexLabel.Size = new Size(52, 12);
            restrictions220IndexLabel.TabIndex = 6;
            restrictions220IndexLabel.Text = "СВМ 220 кВ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label8.Location = new Point(19, 62);
            label8.Name = "label8";
            label8.Size = new Size(52, 12);
            label8.TabIndex = 7;
            label8.Text = "СВМ 500 кВ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label9.Location = new Point(51, 22);
            label9.Name = "label9";
            label9.Size = new Size(10, 12);
            label9.TabIndex = 17;
            label9.Text = "3";
            label9.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label10.Location = new Point(51, 50);
            label10.Name = "label10";
            label10.Size = new Size(10, 12);
            label10.TabIndex = 18;
            label10.Text = "3";
            label10.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(56, 26);
            label11.Name = "label11";
            label11.Size = new Size(21, 15);
            label11.TabIndex = 19;
            label11.Text = "/с:";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(56, 54);
            label12.Name = "label12";
            label12.Size = new Size(21, 15);
            label12.TabIndex = 20;
            label12.Text = "/с:";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(469, 424);
            Controls.Add(calcGroupBox);
            Controls.Add(ULRGroupBox);
            Controls.Add(CalcButton);
            Controls.Add(toolBar);
            Controls.Add(tabControl);
            Controls.Add(toolStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Расчёт РВР";
            Load += MainForm_Load;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
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
            toolBar.ResumeLayout(false);
            toolBar.PerformLayout();
            ULRGroupBox.ResumeLayout(false);
            ULRGroupBox.PerformLayout();
            calcGroupBox.ResumeLayout(false);
            calcGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem openFile;
        private ToolStripMenuItem OpenParamsHU;
        private ToolStripMenuItem saveFile;
        private TabControl tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dataGridView;
        private ToolStripMenuItem saveParamsHU;
        private ToolStrip toolBar;
        private ToolStripButton editingModeButton;
        private ToolStripButton authorizationButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton referenceButton;
        private ToolStripMenuItem openGuide;
        private ToolStripMenuItem SupportToolStripMenu;
        private Button CalcButton;
        private GroupBox ULRGroupBox;
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
        private GroupBox calcGroupBox;
        private TextBox powerRestrictions220TextBox;
        private TextBox powerRestrictions500TextBox;
        private GroupBox groupBox2;
        private TextBox LRRestrictionsTextBox;
        private TextBox URRestrictionsTextBox;
        private ComboBox inequalitySignURComboBox;
        private ComboBox inequalitySignLRComboBox;
        private Label LRLabel;
        private Label URLabel;
        private TextBox LRTextBox;
        private TextBox URTextBox;
        private Label LRRestrictionsLabel;
        private TextBox textBox7;
        private TextBox textBox8;
        private Label powerRestrictions220Label;
        private Label URIndexLabel;
        private Label label6;
        private Label LRIndexLabel;
        private Label restrictions220IndexLabel;
        private Label URRestrictionsLabel;
        private GroupBox groupBox3;
        private Label powerRestrictions500Label;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label5;
        private Label label3;
        private Label roughZone2Label;
        private Label label1;
        private Label roughZone1Label;
        private Label label7;
        private Label secondLabel;
        private Label label4;
        private Label label2;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
    }
}
