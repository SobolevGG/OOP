namespace WinFormsApp2
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
            техническаяПоддержкаToolStripMenuItem = new ToolStripMenuItem();
            tabControl = new TabControl();
            tabPage1 = new TabPage();
            dataGridView = new DataGridView();
            tabPage2 = new TabPage();
            toolStrip2 = new ToolStrip();
            toolStripButton2 = new ToolStripButton();
            editingModeButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            authorizationButton = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            toolStrip1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            toolStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, referenceButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
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
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "Открыть";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(103, 22);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveParamsHU });
            saveToolStripMenuItem.Image = (Image)resources.GetObject("saveToolStripMenuItem.Image");
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
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
            referenceButton.DropDownItems.AddRange(new ToolStripItem[] { openDoc, техническаяПоддержкаToolStripMenuItem });
            referenceButton.Image = (Image)resources.GetObject("referenceButton.Image");
            referenceButton.ImageTransparentColor = Color.Magenta;
            referenceButton.Name = "referenceButton";
            referenceButton.Size = new Size(66, 22);
            referenceButton.Text = "Справка";
            referenceButton.Click += editingMode_Click;
            // 
            // openDoc
            // 
            openDoc.Image = (Image)resources.GetObject("openDoc.Image");
            openDoc.Name = "openDoc";
            openDoc.Size = new Size(206, 22);
            openDoc.Text = "Открыть";
            openDoc.Click += openDoc_Click;
            // 
            // техническаяПоддержкаToolStripMenuItem
            // 
            техническаяПоддержкаToolStripMenuItem.Image = (Image)resources.GetObject("техническаяПоддержкаToolStripMenuItem.Image");
            техническаяПоддержкаToolStripMenuItem.Name = "техническаяПоддержкаToolStripMenuItem";
            техническаяПоддержкаToolStripMenuItem.Size = new Size(206, 22);
            техническаяПоддержкаToolStripMenuItem.Text = "Техническая поддержка";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            tabControl.Location = new Point(0, 53);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(593, 372);
            tabControl.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(585, 344);
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
            dataGridView.Size = new Size(294, 338);
            dataGridView.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(585, 344);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ограничения";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripButton2, editingModeButton, toolStripSeparator1, authorizationButton, toolStripButton1 });
            toolStrip2.Location = new Point(0, 25);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(800, 25);
            toolStrip2.TabIndex = 3;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton2
            // 
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(86, 22);
            toolStripButton2.Text = "Сохранить";
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
            // 
            // toolStripButton1
            // 
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(114, 22);
            toolStripButton1.Text = "toolStripButton1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStrip2);
            Controls.Add(tabControl);
            Controls.Add(toolStrip1);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
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
        private ToolStripButton toolStripButton1;
        private ToolStripMenuItem saveParamsHU;
        private ToolStrip toolStrip2;
        private ToolStripButton editingModeButton;
        private ToolStripButton authorizationButton;
        private ToolStripButton toolStripButton2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton referenceButton;
        private ToolStripMenuItem openDoc;
        private ToolStripMenuItem техническаяПоддержкаToolStripMenuItem;
    }
}
