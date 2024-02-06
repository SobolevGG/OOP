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
            openMaxLoadPoughZone = new ToolStripMenuItem();
            saveFile = new ToolStripMenuItem();
            saveParamsHU = new ToolStripMenuItem();
            saveMaxLoadPoughZone = new ToolStripMenuItem();
            referenceButton = new ToolStripDropDownButton();
            openGuide = new ToolStripMenuItem();
            tabControl = new TabControl();
            parametersHUTabPage = new TabPage();
            parametersHUGridView = new DataGridView();
            inputRestrictionsTabPage = new TabPage();
            groupBox3 = new GroupBox();
            groupBox5 = new GroupBox();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            lowerCalcRestrictionsTextBox = new TextBox();
            upperCalcRestrictionsTextBox = new TextBox();
            label16 = new Label();
            label17 = new Label();
            groupBox2 = new GroupBox();
            cubic2Label = new Label();
            unitsSec2Label = new Label();
            cubic1Label = new Label();
            upperIndexLabel = new Label();
            lowerIndexLabel = new Label();
            lowerRestrictionsLabel = new Label();
            lowerRestrictionsTextBox = new TextBox();
            upperRestrictionsTextBox = new TextBox();
            unitsSec1Label = new Label();
            upperRestrictionsLabel = new Label();
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
            paramsHUToolStripMenu = new ToolStripMenuItem();
            maxLoadPoughZoneToolStripMenu = new ToolStripMenuItem();
            editingModeButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            importBMPButton = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            importDBButton = new ToolStripSplitButton();
            currentCharacteristicsToolStripMenu = new ToolStripMenuItem();
            protocolToolStripMenu = new ToolStripMenuItem();
            authorizationButton = new ToolStripButton();
            exportDBButton = new ToolStripButton();
            calcButton = new Button();
            ULRGroupBox = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            LRTextBox = new TextBox();
            URTextBox = new TextBox();
            calcHeadButton = new Button();
            LRLabel = new Label();
            URLabel = new Label();
            calcGroupBox = new GroupBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            groupBox4 = new GroupBox();
            label9 = new Label();
            label7 = new Label();
            textBox3 = new TextBox();
            loadMaxTextBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            checkoutHourTextBox = new TextBox();
            loadDataButton = new Button();
            checkoutHourGroupBox = new GroupBox();
            toolStrip.SuspendLayout();
            tabControl.SuspendLayout();
            parametersHUTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)parametersHUGridView).BeginInit();
            inputRestrictionsTabPage.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            powerDRGroupBox.SuspendLayout();
            outputRestrictionsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)restrictionsHUGridView).BeginInit();
            toolBar.SuspendLayout();
            ULRGroupBox.SuspendLayout();
            calcGroupBox.SuspendLayout();
            groupBox4.SuspendLayout();
            checkoutHourGroupBox.SuspendLayout();
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
            openFile.Size = new Size(133, 22);
            openFile.Text = "Открыть";
            // 
            // OpenParamsHU
            // 
            OpenParamsHU.Image = (Image)resources.GetObject("OpenParamsHU.Image");
            OpenParamsHU.Name = "OpenParamsHU";
            OpenParamsHU.Size = new Size(215, 22);
            OpenParamsHU.Text = "Параметры ГА";
            OpenParamsHU.Click += OpenParamsHU_Click;
            // 
            // openMaxLoadPoughZone
            // 
            openMaxLoadPoughZone.Image = (Image)resources.GetObject("openMaxLoadPoughZone.Image");
            openMaxLoadPoughZone.Name = "openMaxLoadPoughZone";
            openMaxLoadPoughZone.Size = new Size(215, 22);
            openMaxLoadPoughZone.Text = "Ограничения ЛОМ и ЗНР";
            openMaxLoadPoughZone.Click += OpenMaxLoadPoughZone_Click;
            // 
            // saveFile
            // 
            saveFile.DropDownItems.AddRange(new ToolStripItem[] { saveParamsHU, saveMaxLoadPoughZone });
            saveFile.Image = (Image)resources.GetObject("saveFile.Image");
            saveFile.Name = "saveFile";
            saveFile.Size = new Size(133, 22);
            saveFile.Text = "Сохранить";
            // 
            // saveParamsHU
            // 
            saveParamsHU.Image = (Image)resources.GetObject("saveParamsHU.Image");
            saveParamsHU.Name = "saveParamsHU";
            saveParamsHU.Size = new Size(215, 22);
            saveParamsHU.Text = "Параметры ГА";
            saveParamsHU.Click += SaveParametersHU_Click;
            // 
            // saveMaxLoadPoughZone
            // 
            saveMaxLoadPoughZone.Image = (Image)resources.GetObject("saveMaxLoadPoughZone.Image");
            saveMaxLoadPoughZone.Name = "saveMaxLoadPoughZone";
            saveMaxLoadPoughZone.Size = new Size(215, 22);
            saveMaxLoadPoughZone.Text = "Ограничения ЛОМ и ЗНР";
            saveMaxLoadPoughZone.Click += SaveMaxLoadPoughZone_Click;
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
            inputRestrictionsTabPage.Controls.Add(groupBox3);
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
            // groupBox3
            // 
            groupBox3.Controls.Add(groupBox5);
            groupBox3.Location = new Point(6, 212);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(229, 115);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Вычисляются";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label10);
            groupBox5.Controls.Add(label11);
            groupBox5.Controls.Add(label12);
            groupBox5.Controls.Add(label13);
            groupBox5.Controls.Add(label14);
            groupBox5.Controls.Add(label15);
            groupBox5.Controls.Add(lowerCalcRestrictionsTextBox);
            groupBox5.Controls.Add(upperCalcRestrictionsTextBox);
            groupBox5.Controls.Add(label16);
            groupBox5.Controls.Add(label17);
            groupBox5.Location = new Point(12, 22);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(205, 82);
            groupBox5.TabIndex = 2;
            groupBox5.TabStop = false;
            groupBox5.Text = "Бассейновое водное управление";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label10.Location = new Point(72, 50);
            label10.Name = "label10";
            label10.Size = new Size(0, 12);
            label10.TabIndex = 18;
            label10.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(77, 54);
            label11.Name = "label11";
            label11.Size = new Size(0, 15);
            label11.TabIndex = 20;
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label12.Location = new Point(72, 22);
            label12.Name = "label12";
            label12.Size = new Size(0, 12);
            label12.TabIndex = 17;
            label12.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label13.Location = new Point(21, 35);
            label13.Name = "label13";
            label13.Size = new Size(35, 12);
            label13.TabIndex = 12;
            label13.Text = "НБ.max";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label14.Location = new Point(22, 63);
            label14.Name = "label14";
            label14.Size = new Size(33, 12);
            label14.TabIndex = 10;
            label14.Text = "НБ.min";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(10, 54);
            label15.Name = "label15";
            label15.Size = new Size(79, 15);
            label15.TabIndex = 11;
            label15.Text = "P            , МВт";
            // 
            // lowerCalcRestrictionsTextBox
            // 
            lowerCalcRestrictionsTextBox.Location = new Point(123, 51);
            lowerCalcRestrictionsTextBox.Name = "lowerCalcRestrictionsTextBox";
            lowerCalcRestrictionsTextBox.ReadOnly = true;
            lowerCalcRestrictionsTextBox.Size = new Size(66, 23);
            lowerCalcRestrictionsTextBox.TabIndex = 3;
            lowerCalcRestrictionsTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // upperCalcRestrictionsTextBox
            // 
            upperCalcRestrictionsTextBox.Location = new Point(123, 22);
            upperCalcRestrictionsTextBox.Name = "upperCalcRestrictionsTextBox";
            upperCalcRestrictionsTextBox.ReadOnly = true;
            upperCalcRestrictionsTextBox.Size = new Size(66, 23);
            upperCalcRestrictionsTextBox.TabIndex = 2;
            upperCalcRestrictionsTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(77, 26);
            label16.Name = "label16";
            label16.Size = new Size(0, 15);
            label16.TabIndex = 19;
            label16.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(10, 26);
            label17.Name = "label17";
            label17.Size = new Size(79, 15);
            label17.TabIndex = 8;
            label17.Text = "P            , МВт";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cubic2Label);
            groupBox2.Controls.Add(unitsSec2Label);
            groupBox2.Controls.Add(cubic1Label);
            groupBox2.Controls.Add(upperIndexLabel);
            groupBox2.Controls.Add(lowerIndexLabel);
            groupBox2.Controls.Add(lowerRestrictionsLabel);
            groupBox2.Controls.Add(lowerRestrictionsTextBox);
            groupBox2.Controls.Add(upperRestrictionsTextBox);
            groupBox2.Controls.Add(unitsSec1Label);
            groupBox2.Controls.Add(upperRestrictionsLabel);
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
            cubic2Label.Location = new Point(72, 50);
            cubic2Label.Name = "cubic2Label";
            cubic2Label.Size = new Size(10, 12);
            cubic2Label.TabIndex = 18;
            cubic2Label.Text = "3";
            cubic2Label.TextAlign = ContentAlignment.BottomLeft;
            // 
            // unitsSec2Label
            // 
            unitsSec2Label.AutoSize = true;
            unitsSec2Label.Location = new Point(77, 54);
            unitsSec2Label.Name = "unitsSec2Label";
            unitsSec2Label.Size = new Size(21, 15);
            unitsSec2Label.TabIndex = 20;
            unitsSec2Label.Text = "/с:";
            unitsSec2Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cubic1Label
            // 
            cubic1Label.AutoSize = true;
            cubic1Label.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cubic1Label.Location = new Point(72, 22);
            cubic1Label.Name = "cubic1Label";
            cubic1Label.Size = new Size(10, 12);
            cubic1Label.TabIndex = 17;
            cubic1Label.Text = "3";
            cubic1Label.TextAlign = ContentAlignment.BottomLeft;
            // 
            // upperIndexLabel
            // 
            upperIndexLabel.AutoSize = true;
            upperIndexLabel.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            upperIndexLabel.Location = new Point(22, 35);
            upperIndexLabel.Name = "upperIndexLabel";
            upperIndexLabel.Size = new Size(35, 12);
            upperIndexLabel.TabIndex = 12;
            upperIndexLabel.Text = "НБ.max";
            // 
            // lowerIndexLabel
            // 
            lowerIndexLabel.AutoSize = true;
            lowerIndexLabel.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lowerIndexLabel.Location = new Point(22, 63);
            lowerIndexLabel.Name = "lowerIndexLabel";
            lowerIndexLabel.Size = new Size(33, 12);
            lowerIndexLabel.TabIndex = 10;
            lowerIndexLabel.Text = "НБ.min";
            // 
            // lowerRestrictionsLabel
            // 
            lowerRestrictionsLabel.AutoSize = true;
            lowerRestrictionsLabel.Location = new Point(10, 54);
            lowerRestrictionsLabel.Name = "lowerRestrictionsLabel";
            lowerRestrictionsLabel.Size = new Size(67, 15);
            lowerRestrictionsLabel.TabIndex = 11;
            lowerRestrictionsLabel.Text = "Q            , м";
            // 
            // lowerRestrictionsTextBox
            // 
            lowerRestrictionsTextBox.Location = new Point(123, 51);
            lowerRestrictionsTextBox.Name = "lowerRestrictionsTextBox";
            lowerRestrictionsTextBox.Size = new Size(66, 23);
            lowerRestrictionsTextBox.TabIndex = 3;
            lowerRestrictionsTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // upperRestrictionsTextBox
            // 
            upperRestrictionsTextBox.Location = new Point(123, 22);
            upperRestrictionsTextBox.Name = "upperRestrictionsTextBox";
            upperRestrictionsTextBox.Size = new Size(66, 23);
            upperRestrictionsTextBox.TabIndex = 2;
            upperRestrictionsTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // unitsSec1Label
            // 
            unitsSec1Label.AutoSize = true;
            unitsSec1Label.Location = new Point(77, 26);
            unitsSec1Label.Name = "unitsSec1Label";
            unitsSec1Label.Size = new Size(21, 15);
            unitsSec1Label.TabIndex = 19;
            unitsSec1Label.Text = "/с:";
            unitsSec1Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // upperRestrictionsLabel
            // 
            upperRestrictionsLabel.AutoSize = true;
            upperRestrictionsLabel.Location = new Point(10, 26);
            upperRestrictionsLabel.Name = "upperRestrictionsLabel";
            upperRestrictionsLabel.Size = new Size(67, 15);
            upperRestrictionsLabel.TabIndex = 8;
            upperRestrictionsLabel.Text = "Q            , м";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(powerDRGroupBox);
            groupBox1.Location = new Point(6, 8);
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
            saveButton.DropDownItems.AddRange(new ToolStripItem[] { paramsHUToolStripMenu, maxLoadPoughZoneToolStripMenu });
            saveButton.Image = (Image)resources.GetObject("saveButton.Image");
            saveButton.ImageTransparentColor = Color.Magenta;
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(98, 22);
            saveButton.Text = "Сохранить";
            // 
            // paramsHUToolStripMenu
            // 
            paramsHUToolStripMenu.Image = (Image)resources.GetObject("paramsHUToolStripMenu.Image");
            paramsHUToolStripMenu.Name = "paramsHUToolStripMenu";
            paramsHUToolStripMenu.Size = new Size(215, 22);
            paramsHUToolStripMenu.Text = "Параметры ГА";
            paramsHUToolStripMenu.Click += ParamsHUToolStripMenu_Click;
            // 
            // maxLoadPoughZoneToolStripMenu
            // 
            maxLoadPoughZoneToolStripMenu.Image = (Image)resources.GetObject("maxLoadPoughZoneToolStripMenu.Image");
            maxLoadPoughZoneToolStripMenu.Name = "maxLoadPoughZoneToolStripMenu";
            maxLoadPoughZoneToolStripMenu.Size = new Size(215, 22);
            maxLoadPoughZoneToolStripMenu.Text = "Ограничения ЛОМ и ЗНР";
            maxLoadPoughZoneToolStripMenu.Click += MaxLoadPoughZoneToolStripMenu_Click;
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
            importBMPButton.Click += ImportBMPButton_Click;
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
            // calcButton
            // 
            calcButton.Location = new Point(303, 390);
            calcButton.Name = "calcButton";
            calcButton.Size = new Size(98, 23);
            calcButton.TabIndex = 4;
            calcButton.Text = "Расчёт РВР";
            calcButton.UseVisualStyleBackColor = true;
            calcButton.Click += CalcButton_Click;
            // 
            // ULRGroupBox
            // 
            ULRGroupBox.Controls.Add(label2);
            ULRGroupBox.Controls.Add(label1);
            ULRGroupBox.Controls.Add(LRTextBox);
            ULRGroupBox.Controls.Add(URTextBox);
            ULRGroupBox.Controls.Add(calcHeadButton);
            ULRGroupBox.Controls.Add(LRLabel);
            ULRGroupBox.Controls.Add(URLabel);
            ULRGroupBox.Location = new Point(269, 108);
            ULRGroupBox.Name = "ULRGroupBox";
            ULRGroupBox.Size = new Size(167, 110);
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
            LRTextBox.Location = new Point(87, 49);
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
            // calcHeadButton
            // 
            calcHeadButton.Location = new Point(25, 78);
            calcHeadButton.Name = "calcHeadButton";
            calcHeadButton.Size = new Size(119, 23);
            calcHeadButton.TabIndex = 7;
            calcHeadButton.Text = "Расчёт ЛОМ и ЗНР";
            calcHeadButton.UseVisualStyleBackColor = true;
            calcHeadButton.Click += CalcHeadButton_Click;
            // 
            // LRLabel
            // 
            LRLabel.AutoSize = true;
            LRLabel.Location = new Point(9, 53);
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
            calcGroupBox.Location = new Point(269, 223);
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
            // groupBox4
            // 
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(textBox3);
            groupBox4.Controls.Add(loadMaxTextBox);
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(label4);
            groupBox4.Location = new Point(269, 311);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(167, 110);
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
            // loadMaxTextBox
            // 
            loadMaxTextBox.Location = new Point(87, 23);
            loadMaxTextBox.Name = "loadMaxTextBox";
            loadMaxTextBox.ReadOnly = true;
            loadMaxTextBox.Size = new Size(66, 23);
            loadMaxTextBox.TabIndex = 2;
            loadMaxTextBox.TextAlign = HorizontalAlignment.Center;
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
            // checkoutHourTextBox
            // 
            checkoutHourTextBox.Location = new Point(11, 21);
            checkoutHourTextBox.Name = "checkoutHourTextBox";
            checkoutHourTextBox.Size = new Size(65, 23);
            checkoutHourTextBox.TabIndex = 9;
            checkoutHourTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // loadDataButton
            // 
            loadDataButton.Location = new Point(83, 21);
            loadDataButton.Name = "loadDataButton";
            loadDataButton.Size = new Size(74, 23);
            loadDataButton.TabIndex = 10;
            loadDataButton.Text = "Обновить";
            loadDataButton.UseVisualStyleBackColor = true;
            loadDataButton.Click += LoadDataButton_Click;
            // 
            // checkoutHourGroupBox
            // 
            checkoutHourGroupBox.Controls.Add(checkoutHourTextBox);
            checkoutHourGroupBox.Controls.Add(loadDataButton);
            checkoutHourGroupBox.Location = new Point(269, 47);
            checkoutHourGroupBox.Name = "checkoutHourGroupBox";
            checkoutHourGroupBox.Size = new Size(167, 56);
            checkoutHourGroupBox.TabIndex = 11;
            checkoutHourGroupBox.TabStop = false;
            checkoutHourGroupBox.Text = "Расчётный час";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 424);
            Controls.Add(calcButton);
            Controls.Add(groupBox4);
            Controls.Add(calcGroupBox);
            Controls.Add(toolBar);
            Controls.Add(tabControl);
            Controls.Add(toolStrip);
            Controls.Add(ULRGroupBox);
            Controls.Add(checkoutHourGroupBox);
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
            groupBox3.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
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
            checkoutHourGroupBox.ResumeLayout(false);
            checkoutHourGroupBox.PerformLayout();
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
        private Button calcButton;
        private GroupBox ULRGroupBox;
        private ToolStripButton exportDBButton;
        private ToolStripButton importBMPButton;
        private ToolStripSeparator toolStripSeparator2;
        private GroupBox powerDRGroupBox;
        private ToolStripSplitButton saveButton;
        private ToolStripMenuItem paramsHUToolStripMenu;
        private ToolStripMenuItem maxLoadPoughZoneToolStripMenu;
        private ToolStripSplitButton importDBButton;
        private ToolStripMenuItem currentCharacteristicsToolStripMenu;
        private ToolStripMenuItem protocolToolStripMenu;
        private GroupBox calcGroupBox;
        private TextBox powerRestrictions220TextBox;
        private TextBox powerRestrictions500TextBox;
        private GroupBox groupBox2;
        private TextBox lowerRestrictionsTextBox;
        private TextBox upperRestrictionsTextBox;
        private Label LRLabel;
        private Label URLabel;
        private TextBox LRTextBox;
        private TextBox URTextBox;
        private Label lowerRestrictionsLabel;
        private Label powerRestrictions220Label;
        private Label upperIndexLabel;
        private Label label6;
        private Label lowerIndexLabel;
        private Label restrictions220IndexLabel;
        private Label upperRestrictionsLabel;
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
        private TextBox loadMaxTextBox;
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
        private ToolStripMenuItem saveMaxLoadPoughZone;
        private DataGridViewTextBoxColumn HU;
        private DataGridViewTextBoxColumn RoughZoneFB;
        private DataGridViewTextBoxColumn RoughZoneSB;
        private DataGridViewTextBoxColumn MaxLoad;
        private ToolStripMenuItem openMaxLoadPoughZone;
        private TextBox checkoutHourTextBox;
        private Button loadDataButton;
        private GroupBox checkoutHourGroupBox;
        private GroupBox groupBox3;
        private GroupBox groupBox5;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private TextBox lowerCalcRestrictionsTextBox;
        private TextBox upperCalcRestrictionsTextBox;
        private Label label16;
        private Label label17;
    }
}
