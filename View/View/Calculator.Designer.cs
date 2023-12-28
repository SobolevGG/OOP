namespace View
{
    partial class Calculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculator));
            groupBoxСalculator = new GroupBox();
            dataGridViewSpace = new DataGridView();
            buttonCleanFilter = new Button();
            buttonRandom = new Button();
            buttonReset = new Button();
            buttonSearch = new Button();
            buttonDelete = new Button();
            buttonAdd = new Button();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            SaveToolStripMenuItem = new ToolStripMenuItem();
            OpenToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            groupBoxСalculator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSpace).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxСalculator
            // 
            groupBoxСalculator.Controls.Add(dataGridViewSpace);
            groupBoxСalculator.Location = new Point(0, 27);
            groupBoxСalculator.Margin = new Padding(3, 2, 3, 2);
            groupBoxСalculator.Name = "groupBoxСalculator";
            groupBoxСalculator.Padding = new Padding(3, 2, 3, 2);
            groupBoxСalculator.Size = new Size(647, 164);
            groupBoxСalculator.TabIndex = 9;
            groupBoxСalculator.TabStop = false;
            groupBoxСalculator.Text = "Калькулятор заработных плат";
            // 
            // dataGridViewSpace
            // 
            dataGridViewSpace.AllowUserToOrderColumns = true;
            dataGridViewSpace.AllowUserToResizeColumns = false;
            dataGridViewSpace.AllowUserToResizeRows = false;
            dataGridViewSpace.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSpace.Location = new Point(5, 20);
            dataGridViewSpace.Margin = new Padding(3, 2, 3, 2);
            dataGridViewSpace.Name = "dataGridViewSpace";
            dataGridViewSpace.RowHeadersWidth = 51;
            dataGridViewSpace.RowTemplate.Height = 25;
            dataGridViewSpace.Size = new Size(634, 138);
            dataGridViewSpace.TabIndex = 1;
            // 
            // buttonCleanFilter
            // 
            buttonCleanFilter.Location = new Point(225, 224);
            buttonCleanFilter.Margin = new Padding(3, 2, 3, 2);
            buttonCleanFilter.Name = "buttonCleanFilter";
            buttonCleanFilter.Size = new Size(194, 25);
            buttonCleanFilter.TabIndex = 15;
            buttonCleanFilter.Text = "Сбросить фильтр";
            buttonCleanFilter.UseVisualStyleBackColor = true;
            // 
            // buttonRandom
            // 
            buttonRandom.Location = new Point(446, 224);
            buttonRandom.Name = "buttonRandom";
            buttonRandom.Size = new Size(194, 25);
            buttonRandom.TabIndex = 14;
            buttonRandom.Text = "Случайная зарплата";
            buttonRandom.UseVisualStyleBackColor = true;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(446, 194);
            buttonReset.Margin = new Padding(3, 2, 3, 2);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(194, 23);
            buttonReset.TabIndex = 13;
            buttonReset.Text = "Очистить";
            buttonReset.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(6, 224);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(194, 23);
            buttonSearch.TabIndex = 12;
            buttonSearch.Text = "Фильтр";
            buttonSearch.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(225, 194);
            buttonDelete.Margin = new Padding(3, 2, 3, 2);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(194, 23);
            buttonDelete.TabIndex = 11;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(6, 196);
            buttonAdd.Margin = new Padding(3, 2, 3, 2);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(142, 23);
            buttonAdd.TabIndex = 10;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { SaveToolStripMenuItem, OpenToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(49, 22);
            toolStripDropDownButton1.Text = "Файл";
            // 
            // SaveToolStripMenuItem
            // 
            SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            SaveToolStripMenuItem.Size = new Size(133, 22);
            SaveToolStripMenuItem.Text = "Сохранить";
            // 
            // OpenToolStripMenuItem
            // 
            OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            OpenToolStripMenuItem.Size = new Size(133, 22);
            OpenToolStripMenuItem.Text = "Загрузить";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 16;
            toolStrip1.Text = "toolStrip1";
            // 
            // Calculator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBoxСalculator);
            Controls.Add(buttonCleanFilter);
            Controls.Add(buttonRandom);
            Controls.Add(buttonReset);
            Controls.Add(buttonSearch);
            Controls.Add(buttonDelete);
            Controls.Add(buttonAdd);
            Controls.Add(toolStrip1);
            Name = "Calculator";
            Text = "Form1";
            groupBoxСalculator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewSpace).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBoxСalculator;
        private DataGridView dataGridViewSpace;
        private Button buttonCleanFilter;
        private Button buttonRandom;
        private Button buttonReset;
        private Button buttonSearch;
        private Button buttonDelete;
        private Button buttonAdd;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem SaveToolStripMenuItem;
        private ToolStripMenuItem OpenToolStripMenuItem;
        private ToolStrip toolStrip1;
    }
}
