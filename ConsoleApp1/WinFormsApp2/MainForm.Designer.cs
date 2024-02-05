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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            toolStrip = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            openFile = new ToolStripMenuItem();
            OpenParamsHU = new ToolStripMenuItem();
            saveFile = new ToolStripMenuItem();
            saveParamsHU = new ToolStripMenuItem();
            saveMaxLoadRoughZone = new ToolStripMenuItem();
            saveMaxLoadPoughZone = new ToolStripMenuItem();
            referenceButton = new ToolStripDropDownButton();
            openGuide = new ToolStripMenuItem();
            tabControl = new TabControl();
            parametersHUTabPage = new TabPage();
            parametersHUGridView = new DataGridView();
            inputRestrictionsTabPage = new TabPage();
            groupBox2 = new GroupBox();
            cubic2Label = new Label();
            cubic1Label = new Label();
            URIndexLabel = new Label();
            LRIndexLabel = new Label();
            LRRestrictionsLabel = new Label();
            inequalitySignLRComboBox = new ComboBox();
            inequalitySignURComboBox = new ComboBox();
            LRRestrictionsTextBox = new TextBox();
            URRestrictionsTextBox = new TextBox();
            URRestrictionsLabel = new Label();
            unitsSec1Label = new Label();
            unitsSec2Label = new Label();
            groupBox1 = new GroupBox();
            powerDRGroupBox = new GroupBox();
            label8 = new Label();
            restrictions220IndexLabel = new Label();
            powerRestrictions500Label = new Label();
            powerRestrictions220Label = new Label();
            powerRestrictions500TextBox = new TextBox();
            powerRestrictions220TextBox = new TextBox();
            outputRestrictionsTabPage = new TabPage();
            maxLoadIndexLabel = new Label();
            unitsMaxLoadLabel = new Label();
            maxLoadLabel = new Label();
            roughZoneIndeSBLabel = new Label();
            unitsRoughZoneFBLabel = new Label();
            roughZoneIndeFBLabel = new Label();
            roughZoneFBLabel = new Label();
            unitsRoughZoneSBLabel = new Label();
            HULabel = new Label();
            roughZoneSBLabel = new Label();
            restrictionsHUGridView = new DataGridView();
            HU = new DataGridViewTextBoxColumn();
            RoughZoneFB = new DataGridViewTextBoxColumn();
            RoughZoneSB = new DataGridViewTextBoxColumn();
            MaxLoad = new DataGridViewTextBoxColumn();
            toolBar = new ToolStrip();
            saveButton = new ToolStripSplitButton();
            параметрыГАToolStripMenuItem = new ToolStripMenuItem();
            ограниченияToolStripMenuItem = new ToolStripMenuItem();
            характеристикиГАToolStripMenuItem = new ToolStripMenuItem();
            editingModeButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            importBMPButton = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            importDBButton = new ToolStripSplitButton();
            currentCharacteristicsToolStripMenu = new ToolStripMenuItem();
            protocolToolStripMenu = new ToolStripMenuItem();
            authorizationButton = new ToolStripButton();
            exportDBButton = new ToolStripButton();
            CalcButton = new Button();
            ULRGroupBox = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            LRTextBox = new TextBox();
            URTextBox = new TextBox();
            LRLabel = new Label();
            URLabel = new Label();
            calcGroupBox = new GroupBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            calcHeadButton = new Button();
            groupBox4 = new GroupBox();
            label9 = new Label();
            label7 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            openMaxLoadPoughZone = new ToolStripMenuItem();
            toolStrip.SuspendLayout();
            tabControl.SuspendLayout();
            parametersHUTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)parametersHUGridView).BeginInit();
            inputRestrictionsTabPage.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            powerDRGroupBox.SuspendLayout();
            outputRestrictionsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)restrictionsHUGridView).BeginInit();
            toolBar.SuspendLayout();
            ULRGroupBox.SuspendLayout();
            calcGroupBox.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, referenceButton });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(457, 25);
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
            openFile.DropDownItems.AddRange(new ToolStripItem[] { OpenParamsHU, openMaxLoadPoughZone });
            openFile.Image = (Image)resources.GetObject("openFile.Image");
            openFile.Name = "openFile";
            openFile.Size = new Size(180, 22);
            openFile.Text = "Открыть";
            // 
            // OpenParamsHU
            // 
            OpenParamsHU.Image = (Image)resources.GetObject("OpenParamsHU.Image");
            OpenParamsHU.Name = "OpenParamsHU";
            OpenParamsHU.Size = new Size(211, 22);
            OpenParamsHU.Text = "Параметры ГА";
            OpenParamsHU.Click += OpenParamsHU_Click;
            // 
            // saveFile
            // 
            saveFile.DropDownItems.AddRange(new ToolStripItem[] { saveParamsHU, saveMaxLoadRoughZone, saveMaxLoadPoughZone });
            saveFile.Image = (Image)resources.GetObject("saveFile.Image");
            saveFile.Name = "saveFile";
            saveFile.Size = new Size(180, 22);
            saveFile.Text = "Сохранить";
            // 
            // saveParamsHU
            // 
            saveParamsHU.Name = "saveParamsHU";
            saveParamsHU.Size = new Size(215, 22);
            saveParamsHU.Text = "Параметры ГА";
            saveParamsHU.Click += Save_Click;
            // 
            // saveMaxLoadRoughZone
            // 
            saveMaxLoadRoughZone.Name = "saveMaxLoadRoughZone";
            saveMaxLoadRoughZone.Size = new Size(215, 22);
            saveMaxLoadRoughZone.Text = "Ограничения СВМ и БВУ";
            // 
            // saveMaxLoadPoughZone
            // 
            saveMaxLoadPoughZone.Name = "saveMaxLoadPoughZone";
            saveMaxLoadPoughZone.Size = new Size(215, 22);
            saveMaxLoadPoughZone.Text = "Ограничения ЛОМ и ЗНР";
            saveMaxLoadPoughZone.Click += saveMaxLoadPoughZone_Click;
            // 
            // referenceButton
            // 
            referenceButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            referenceButton.DropDownItems.AddRange(new ToolStripItem[] { openGuide });
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
            openGuide.Size = new Size(121, 22);
            openGuide.Text = "Открыть";
            openGuide.Click += OpenGuide_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(parametersHUTabPage);
            tabControl.Controls.Add(inputRestrictionsTabPage);
            tabControl.Controls.Add(outputRestrictionsTabPage);
            tabControl.Location = new Point(0, 53);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(251, 372);
            tabControl.TabIndex = 2;
            // 
            // parametersHUTabPage
            // 
            parametersHUTabPage.Controls.Add(parametersHUGridView);
            parametersHUTabPage.Location = new Point(4, 24);
            parametersHUTabPage.Name = "parametersHUTabPage";
            parametersHUTabPage.Padding = new Padding(3);
            parametersHUTabPage.Size = new Size(243, 344);
            parametersHUTabPage.TabIndex = 0;
            parametersHUTabPage.Text = "Параметры ГА";
            parametersHUTabPage.UseVisualStyleBackColor = true;
            // 
            // parametersHUGridView
            // 
            parametersHUGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            parametersHUGridView.Location = new Point(3, 3);
            parametersHUGridView.Name = "parametersHUGridView";
            parametersHUGridView.RowHeadersVisible = false;
            parametersHUGridView.Size = new Size(237, 338);
            parametersHUGridView.TabIndex = 0;
            // 
            // inputRestrictionsTabPage
            // 
            inputRestrictionsTabPage.Controls.Add(groupBox2);
            inputRestrictionsTabPage.Controls.Add(groupBox1);
            inputRestrictionsTabPage.Location = new Point(4, 24);
            inputRestrictionsTabPage.Name = "inputRestrictionsTabPage";
            inputRestrictionsTabPage.Padding = new Padding(3);
            inputRestrictionsTabPage.Size = new Size(243, 344);
            inputRestrictionsTabPage.TabIndex = 1;
            inputRestrictionsTabPage.Text = "СВМ и БВУ";
            inputRestrictionsTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cubic2Label);
            groupBox2.Controls.Add(cubic1Label);
            groupBox2.Controls.Add(URIndexLabel);
            groupBox2.Controls.Add(LRIndexLabel);
            groupBox2.Controls.Add(LRRestrictionsLabel);
            groupBox2.Controls.Add(inequalitySignLRComboBox);
            groupBox2.Controls.Add(inequalitySignURComboBox);
            groupBox2.Controls.Add(LRRestrictionsTextBox);
            groupBox2.Controls.Add(URRestrictionsTextBox);
            groupBox2.Controls.Add(URRestrictionsLabel);
            groupBox2.Controls.Add(unitsSec1Label);
            groupBox2.Controls.Add(unitsSec2Label);
            groupBox2.Location = new Point(20, 111);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(205, 82);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Бассейновое водное управление";
            // 
            // cubic2Label
            // 
            cubic2Label.AutoSize = true;
            cubic2Label.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cubic2Label.Location = new Point(51, 50);
            cubic2Label.Name = "cubic2Label";
            cubic2Label.Size = new Size(10, 12);
            cubic2Label.TabIndex = 18;
            cubic2Label.Text = "3";
            cubic2Label.TextAlign = ContentAlignment.BottomLeft;
            // 
            // cubic1Label
            // 
            cubic1Label.AutoSize = true;
            cubic1Label.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cubic1Label.Location = new Point(51, 22);
            cubic1Label.Name = "cubic1Label";
            cubic1Label.Size = new Size(10, 12);
            cubic1Label.TabIndex = 17;
            cubic1Label.Text = "3";
            cubic1Label.TextAlign = ContentAlignment.BottomLeft;
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
            LRRestrictionsTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // URRestrictionsTextBox
            // 
            URRestrictionsTextBox.Location = new Point(123, 22);
            URRestrictionsTextBox.Name = "URRestrictionsTextBox";
            URRestrictionsTextBox.Size = new Size(66, 23);
            URRestrictionsTextBox.TabIndex = 2;
            URRestrictionsTextBox.TextAlign = HorizontalAlignment.Center;
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
            // unitsSec1Label
            // 
            unitsSec1Label.AutoSize = true;
            unitsSec1Label.Location = new Point(56, 26);
            unitsSec1Label.Name = "unitsSec1Label";
            unitsSec1Label.Size = new Size(21, 15);
            unitsSec1Label.TabIndex = 19;
            unitsSec1Label.Text = "/с:";
            unitsSec1Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // unitsSec2Label
            // 
            unitsSec2Label.AutoSize = true;
            unitsSec2Label.Location = new Point(56, 54);
            unitsSec2Label.Name = "unitsSec2Label";
            unitsSec2Label.Size = new Size(21, 15);
            unitsSec2Label.TabIndex = 20;
            unitsSec2Label.Text = "/с:";
            unitsSec2Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(powerDRGroupBox);
            groupBox1.Location = new Point(8, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(229, 198);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Задаются";
            // 
            // powerDRGroupBox
            // 
            powerDRGroupBox.Controls.Add(label8);
            powerDRGroupBox.Controls.Add(restrictions220IndexLabel);
            powerDRGroupBox.Controls.Add(powerRestrictions500Label);
            powerDRGroupBox.Controls.Add(powerRestrictions220Label);
            powerDRGroupBox.Controls.Add(powerRestrictions500TextBox);
            powerDRGroupBox.Controls.Add(powerRestrictions220TextBox);
            powerDRGroupBox.Location = new Point(12, 19);
            powerDRGroupBox.Name = "powerDRGroupBox";
            powerDRGroupBox.Size = new Size(205, 82);
            powerDRGroupBox.TabIndex = 0;
            powerDRGroupBox.TabStop = false;
            powerDRGroupBox.Text = "Схема выдачи мощности";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label8.Location = new Point(19, 62);
            label8.Name = "label8";
            label8.Size = new Size(39, 12);
            label8.TabIndex = 7;
            label8.Text = "СВМ500";
            // 
            // restrictions220IndexLabel
            // 
            restrictions220IndexLabel.AutoSize = true;
            restrictions220IndexLabel.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            restrictions220IndexLabel.Location = new Point(19, 33);
            restrictions220IndexLabel.Name = "restrictions220IndexLabel";
            restrictions220IndexLabel.Size = new Size(39, 12);
            restrictions220IndexLabel.TabIndex = 6;
            restrictions220IndexLabel.Text = "СВМ220";
            // 
            // powerRestrictions500Label
            // 
            powerRestrictions500Label.AutoSize = true;
            powerRestrictions500Label.Location = new Point(10, 55);
            powerRestrictions500Label.Name = "powerRestrictions500Label";
            powerRestrictions500Label.Size = new Size(85, 15);
            powerRestrictions500Label.TabIndex = 5;
            powerRestrictions500Label.Text = "P             , МВт:";
            // 
            // powerRestrictions220Label
            // 
            powerRestrictions220Label.AutoSize = true;
            powerRestrictions220Label.Location = new Point(10, 26);
            powerRestrictions220Label.Name = "powerRestrictions220Label";
            powerRestrictions220Label.Size = new Size(85, 15);
            powerRestrictions220Label.TabIndex = 4;
            powerRestrictions220Label.Text = "P             , МВт:";
            // 
            // powerRestrictions500TextBox
            // 
            powerRestrictions500TextBox.Location = new Point(123, 51);
            powerRestrictions500TextBox.Name = "powerRestrictions500TextBox";
            powerRestrictions500TextBox.Size = new Size(66, 23);
            powerRestrictions500TextBox.TabIndex = 3;
            powerRestrictions500TextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // powerRestrictions220TextBox
            // 
            powerRestrictions220TextBox.Location = new Point(123, 22);
            powerRestrictions220TextBox.Name = "powerRestrictions220TextBox";
            powerRestrictions220TextBox.Size = new Size(66, 23);
            powerRestrictions220TextBox.TabIndex = 2;
            powerRestrictions220TextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // outputRestrictionsTabPage
            // 
            outputRestrictionsTabPage.Controls.Add(maxLoadIndexLabel);
            outputRestrictionsTabPage.Controls.Add(unitsMaxLoadLabel);
            outputRestrictionsTabPage.Controls.Add(maxLoadLabel);
            outputRestrictionsTabPage.Controls.Add(roughZoneIndeSBLabel);
            outputRestrictionsTabPage.Controls.Add(unitsRoughZoneFBLabel);
            outputRestrictionsTabPage.Controls.Add(roughZoneIndeFBLabel);
            outputRestrictionsTabPage.Controls.Add(roughZoneFBLabel);
            outputRestrictionsTabPage.Controls.Add(unitsRoughZoneSBLabel);
            outputRestrictionsTabPage.Controls.Add(HULabel);
            outputRestrictionsTabPage.Controls.Add(roughZoneSBLabel);
            outputRestrictionsTabPage.Controls.Add(restrictionsHUGridView);
            outputRestrictionsTabPage.Location = new Point(4, 24);
            outputRestrictionsTabPage.Name = "outputRestrictionsTabPage";
            outputRestrictionsTabPage.Size = new Size(243, 344);
            outputRestrictionsTabPage.TabIndex = 2;
            outputRestrictionsTabPage.Text = "ЛОМ и ЗНР";
            outputRestrictionsTabPage.UseVisualStyleBackColor = true;
            // 
            // maxLoadIndexLabel
            // 
            maxLoadIndexLabel.AutoSize = true;
            maxLoadIndexLabel.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            maxLoadIndexLabel.Location = new Point(195, 14);
            maxLoadIndexLabel.Name = "maxLoadIndexLabel";
            maxLoadIndexLabel.Size = new Size(26, 12);
            maxLoadIndexLabel.TabIndex = 27;
            maxLoadIndexLabel.Text = "ЛОМ";
            // 
            // unitsMaxLoadLabel
            // 
            unitsMaxLoadLabel.AutoSize = true;
            unitsMaxLoadLabel.Location = new Point(194, 25);
            unitsMaxLoadLabel.Name = "unitsMaxLoadLabel";
            unitsMaxLoadLabel.Size = new Size(30, 15);
            unitsMaxLoadLabel.TabIndex = 29;
            unitsMaxLoadLabel.Text = "МВт";
            unitsMaxLoadLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // maxLoadLabel
            // 
            maxLoadLabel.AutoSize = true;
            maxLoadLabel.Location = new Point(187, 6);
            maxLoadLabel.Name = "maxLoadLabel";
            maxLoadLabel.Size = new Size(41, 15);
            maxLoadLabel.TabIndex = 28;
            maxLoadLabel.Text = "P        ,";
            maxLoadLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // roughZoneIndeSBLabel
            // 
            roughZoneIndeSBLabel.AutoSize = true;
            roughZoneIndeSBLabel.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            roughZoneIndeSBLabel.Location = new Point(131, 14);
            roughZoneIndeSBLabel.Name = "roughZoneIndeSBLabel";
            roughZoneIndeSBLabel.Size = new Size(26, 12);
            roughZoneIndeSBLabel.TabIndex = 14;
            roughZoneIndeSBLabel.Text = "ЗНР2";
            // 
            // unitsRoughZoneFBLabel
            // 
            unitsRoughZoneFBLabel.AutoSize = true;
            unitsRoughZoneFBLabel.Location = new Point(130, 25);
            unitsRoughZoneFBLabel.Name = "unitsRoughZoneFBLabel";
            unitsRoughZoneFBLabel.Size = new Size(30, 15);
            unitsRoughZoneFBLabel.TabIndex = 26;
            unitsRoughZoneFBLabel.Text = "МВт";
            unitsRoughZoneFBLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // roughZoneIndeFBLabel
            // 
            roughZoneIndeFBLabel.AutoSize = true;
            roughZoneIndeFBLabel.Font = new Font("Segoe UI", 6.75F);
            roughZoneIndeFBLabel.Location = new Point(68, 14);
            roughZoneIndeFBLabel.Name = "roughZoneIndeFBLabel";
            roughZoneIndeFBLabel.Size = new Size(26, 12);
            roughZoneIndeFBLabel.TabIndex = 16;
            roughZoneIndeFBLabel.Text = "ЗНР1";
            // 
            // roughZoneFBLabel
            // 
            roughZoneFBLabel.AutoSize = true;
            roughZoneFBLabel.Location = new Point(61, 6);
            roughZoneFBLabel.Name = "roughZoneFBLabel";
            roughZoneFBLabel.Size = new Size(41, 15);
            roughZoneFBLabel.TabIndex = 17;
            roughZoneFBLabel.Text = "P        ,";
            roughZoneFBLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // unitsRoughZoneSBLabel
            // 
            unitsRoughZoneSBLabel.AutoSize = true;
            unitsRoughZoneSBLabel.Location = new Point(66, 25);
            unitsRoughZoneSBLabel.Name = "unitsRoughZoneSBLabel";
            unitsRoughZoneSBLabel.Size = new Size(30, 15);
            unitsRoughZoneSBLabel.TabIndex = 25;
            unitsRoughZoneSBLabel.Text = "МВт";
            unitsRoughZoneSBLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // HULabel
            // 
            HULabel.AutoSize = true;
            HULabel.Location = new Point(16, 16);
            HULabel.Name = "HULabel";
            HULabel.Size = new Size(21, 15);
            HULabel.TabIndex = 18;
            HULabel.Text = "ГА";
            HULabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // roughZoneSBLabel
            // 
            roughZoneSBLabel.AutoSize = true;
            roughZoneSBLabel.Location = new Point(123, 6);
            roughZoneSBLabel.Name = "roughZoneSBLabel";
            roughZoneSBLabel.Size = new Size(41, 15);
            roughZoneSBLabel.TabIndex = 15;
            roughZoneSBLabel.Text = "P        ,";
            roughZoneSBLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // restrictionsHUGridView
            // 
            restrictionsHUGridView.AllowUserToAddRows = false;
            restrictionsHUGridView.AllowUserToDeleteRows = false;
            restrictionsHUGridView.ColumnHeadersHeight = 38;
            restrictionsHUGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            restrictionsHUGridView.Columns.AddRange(new DataGridViewColumn[] { HU, RoughZoneFB, RoughZoneSB, MaxLoad });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            restrictionsHUGridView.DefaultCellStyle = dataGridViewCellStyle4;
            restrictionsHUGridView.Location = new Point(3, 2);
            restrictionsHUGridView.Name = "restrictionsHUGridView";
            restrictionsHUGridView.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            restrictionsHUGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            restrictionsHUGridView.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            restrictionsHUGridView.RowsDefaultCellStyle = dataGridViewCellStyle6;
            restrictionsHUGridView.Size = new Size(237, 338);
            restrictionsHUGridView.TabIndex = 0;
            // 
            // HU
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            HU.DefaultCellStyle = dataGridViewCellStyle1;
            HU.HeaderText = "        ";
            HU.Name = "HU";
            HU.ReadOnly = true;
            HU.Resizable = DataGridViewTriState.False;
            HU.SortMode = DataGridViewColumnSortMode.NotSortable;
            HU.ToolTipText = "Это поле только для чтения.";
            HU.Width = 44;
            // 
            // RoughZoneFB
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            RoughZoneFB.DefaultCellStyle = dataGridViewCellStyle2;
            RoughZoneFB.HeaderText = "";
            RoughZoneFB.Name = "RoughZoneFB";
            RoughZoneFB.ReadOnly = true;
            RoughZoneFB.Resizable = DataGridViewTriState.False;
            RoughZoneFB.SortMode = DataGridViewColumnSortMode.NotSortable;
            RoughZoneFB.ToolTipText = "Это поле только для чтения.";
            RoughZoneFB.Width = 63;
            // 
            // RoughZoneSB
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            RoughZoneSB.DefaultCellStyle = dataGridViewCellStyle3;
            RoughZoneSB.HeaderText = "";
            RoughZoneSB.Name = "RoughZoneSB";
            RoughZoneSB.ReadOnly = true;
            RoughZoneSB.Resizable = DataGridViewTriState.False;
            RoughZoneSB.SortMode = DataGridViewColumnSortMode.NotSortable;
            RoughZoneSB.ToolTipText = "Это поле только для чтения.";
            RoughZoneSB.Width = 64;
            // 
            // MaxLoad
            // 
            MaxLoad.HeaderText = "";
            MaxLoad.Name = "MaxLoad";
            MaxLoad.ReadOnly = true;
            MaxLoad.Resizable = DataGridViewTriState.False;
            MaxLoad.SortMode = DataGridViewColumnSortMode.NotSortable;
            MaxLoad.ToolTipText = "Это поле только для чтения.";
            MaxLoad.Width = 63;
            // 
            // toolBar
            // 
            toolBar.Items.AddRange(new ToolStripItem[] { saveButton, editingModeButton, toolStripSeparator1, importBMPButton, toolStripSeparator2, importDBButton, authorizationButton, exportDBButton });
            toolBar.Location = new Point(0, 25);
            toolBar.Name = "toolBar";
            toolBar.Size = new Size(457, 25);
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
            // importBMPButton
            // 
            importBMPButton.Image = (Image)resources.GetObject("importBMPButton.Image");
            importBMPButton.ImageTransparentColor = Color.Magenta;
            importBMPButton.Name = "importBMPButton";
            importBMPButton.Size = new Size(97, 22);
            importBMPButton.Text = "Импорт ПБР";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
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
            protocolToolStripMenu.Click += ProtocolToolStripMenu_Click;
            // 
            // authorizationButton
            // 
            authorizationButton.Image = (Image)resources.GetObject("authorizationButton.Image");
            authorizationButton.ImageTransparentColor = Color.Magenta;
            authorizationButton.Name = "authorizationButton";
            authorizationButton.Size = new Size(98, 20);
            authorizationButton.Text = "Авторизация";
            authorizationButton.Click += AuthorizationButton_Click;
            // 
            // exportDBButton
            // 
            exportDBButton.Image = (Image)resources.GetObject("exportDBButton.Image");
            exportDBButton.ImageTransparentColor = Color.Magenta;
            exportDBButton.Name = "exportDBButton";
            exportDBButton.Size = new Size(99, 20);
            exportDBButton.Text = "Экспорт в БД";
            exportDBButton.ToolTipText = "Для экспорта в БД требуется авторизация";
            exportDBButton.Click += ExportDBButton_Click;
            // 
            // CalcButton
            // 
            CalcButton.Location = new Point(297, 294);
            CalcButton.Name = "CalcButton";
            CalcButton.Size = new Size(111, 23);
            CalcButton.TabIndex = 4;
            CalcButton.Text = "Расчёт РВР";
            CalcButton.UseVisualStyleBackColor = true;
            // 
            // ULRGroupBox
            // 
            ULRGroupBox.Controls.Add(label2);
            ULRGroupBox.Controls.Add(label1);
            ULRGroupBox.Controls.Add(LRTextBox);
            ULRGroupBox.Controls.Add(URTextBox);
            ULRGroupBox.Controls.Add(LRLabel);
            ULRGroupBox.Controls.Add(URLabel);
            ULRGroupBox.Location = new Point(269, 67);
            ULRGroupBox.Name = "ULRGroupBox";
            ULRGroupBox.Size = new Size(167, 83);
            ULRGroupBox.TabIndex = 5;
            ULRGroupBox.TabStop = false;
            ULRGroupBox.Text = "Уровни бьефов";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(20, 64);
            label2.Name = "label2";
            label2.Size = new Size(16, 12);
            label2.TabIndex = 5;
            label2.Text = "НБ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(19, 35);
            label1.Name = "label1";
            label1.Size = new Size(17, 12);
            label1.TabIndex = 4;
            label1.Text = "ВБ:";
            // 
            // LRTextBox
            // 
            LRTextBox.Location = new Point(87, 52);
            LRTextBox.Name = "LRTextBox";
            LRTextBox.Size = new Size(66, 23);
            LRTextBox.TabIndex = 3;
            LRTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // URTextBox
            // 
            URTextBox.Location = new Point(87, 23);
            URTextBox.Name = "URTextBox";
            URTextBox.Size = new Size(66, 23);
            URTextBox.TabIndex = 2;
            URTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // LRLabel
            // 
            LRLabel.AutoSize = true;
            LRLabel.Location = new Point(9, 56);
            LRLabel.Name = "LRLabel";
            LRLabel.Size = new Size(50, 15);
            LRLabel.TabIndex = 1;
            LRLabel.Text = "Z      , м:";
            // 
            // URLabel
            // 
            URLabel.AutoSize = true;
            URLabel.Location = new Point(9, 27);
            URLabel.Name = "URLabel";
            URLabel.Size = new Size(50, 15);
            URLabel.TabIndex = 0;
            URLabel.Text = "Z      , м:";
            // 
            // calcGroupBox
            // 
            calcGroupBox.Controls.Add(textBox2);
            calcGroupBox.Controls.Add(textBox1);
            calcGroupBox.Controls.Add(label6);
            calcGroupBox.Controls.Add(label5);
            calcGroupBox.Location = new Point(269, 198);
            calcGroupBox.Name = "calcGroupBox";
            calcGroupBox.Size = new Size(167, 83);
            calcGroupBox.TabIndex = 6;
            calcGroupBox.TabStop = false;
            calcGroupBox.Text = "НПРЧ и ОГ";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(87, 49);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(66, 23);
            textBox2.TabIndex = 3;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(87, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(66, 23);
            textBox1.TabIndex = 2;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 52);
            label6.Name = "label6";
            label6.Size = new Size(54, 15);
            label6.TabIndex = 1;
            label6.Text = "ОГ, МВт:";
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
            // calcHeadButton
            // 
            calcHeadButton.Location = new Point(297, 163);
            calcHeadButton.Name = "calcHeadButton";
            calcHeadButton.Size = new Size(111, 23);
            calcHeadButton.TabIndex = 7;
            calcHeadButton.Text = "Расчёт напора";
            calcHeadButton.UseVisualStyleBackColor = true;
            calcHeadButton.Click += CalcHeadButton_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(textBox3);
            groupBox4.Controls.Add(textBox4);
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(label4);
            groupBox4.Location = new Point(269, 329);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(167, 83);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "Результаты расчёта РВР";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label9.Location = new Point(18, 59);
            label9.Name = "label9";
            label9.Size = new Size(20, 12);
            label9.TabIndex = 5;
            label9.Text = "min";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label7.Location = new Point(18, 33);
            label7.Name = "label7";
            label7.Size = new Size(22, 12);
            label7.TabIndex = 4;
            label7.Text = "max";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(87, 49);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(66, 23);
            textBox3.TabIndex = 3;
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(87, 23);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(66, 23);
            textBox4.TabIndex = 2;
            textBox4.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 52);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 1;
            label3.Text = "P       , МВт:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 26);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 0;
            label4.Text = "P       , МВт:";
            // 
            // openMaxLoadPoughZone
            // 
            openMaxLoadPoughZone.Name = "openMaxLoadPoughZone";
            openMaxLoadPoughZone.Size = new Size(211, 22);
            openMaxLoadPoughZone.Text = "Ограничения СВМ и БВУ";
            openMaxLoadPoughZone.Click += openMaxLoadPoughZone_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 424);
            Controls.Add(groupBox4);
            Controls.Add(calcHeadButton);
            Controls.Add(calcGroupBox);
            Controls.Add(ULRGroupBox);
            Controls.Add(CalcButton);
            Controls.Add(toolBar);
            Controls.Add(tabControl);
            Controls.Add(toolStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Расчёт РВР";
            Load += MainForm_Load;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            tabControl.ResumeLayout(false);
            parametersHUTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)parametersHUGridView).EndInit();
            inputRestrictionsTabPage.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            powerDRGroupBox.ResumeLayout(false);
            powerDRGroupBox.PerformLayout();
            outputRestrictionsTabPage.ResumeLayout(false);
            outputRestrictionsTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)restrictionsHUGridView).EndInit();
            toolBar.ResumeLayout(false);
            toolBar.PerformLayout();
            ULRGroupBox.ResumeLayout(false);
            ULRGroupBox.PerformLayout();
            calcGroupBox.ResumeLayout(false);
            calcGroupBox.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
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
        private TabPage parametersHUTabPage;
        private TabPage inputRestrictionsTabPage;
        private DataGridView parametersHUGridView;
        private ToolStripMenuItem saveParamsHU;
        private ToolStrip toolBar;
        private ToolStripButton editingModeButton;
        private ToolStripButton authorizationButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton referenceButton;
        private ToolStripMenuItem openGuide;
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
        private Label powerRestrictions220Label;
        private Label URIndexLabel;
        private Label label6;
        private Label LRIndexLabel;
        private Label restrictions220IndexLabel;
        private Label URRestrictionsLabel;
        private Label powerRestrictions500Label;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label5;
        private Label label8;
        private Label cubic1Label;
        private Label cubic2Label;
        private Label unitsSec1Label;
        private Label unitsSec2Label;
        private Label label2;
        private Label label1;
        private GroupBox groupBox1;
        private Button calcHeadButton;
        private GroupBox groupBox4;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label3;
        private Label label4;
        private Label label7;
        private Label label9;
        private TabPage outputRestrictionsTabPage;
        private DataGridView restrictionsHUGridView;
        private Label roughZoneIndeFBLabel;
        private Label roughZoneFBLabel;
        private Label roughZoneIndeSBLabel;
        private Label roughZoneSBLabel;
        private Label HULabel;
        private Label unitsRoughZoneSBLabel;
        private Label unitsRoughZoneFBLabel;
        private Label maxLoadIndexLabel;
        private Label unitsMaxLoadLabel;
        private Label maxLoadLabel;
        private ToolStripMenuItem saveMaxLoadRoughZone;
        private ToolStripMenuItem saveMaxLoadPoughZone;
        private DataGridViewTextBoxColumn HU;
        private DataGridViewTextBoxColumn RoughZoneFB;
        private DataGridViewTextBoxColumn RoughZoneSB;
        private DataGridViewTextBoxColumn MaxLoad;
        private ToolStripMenuItem openMaxLoadPoughZone;
    }
}
