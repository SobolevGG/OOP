using System;
using Model;

/// <summary> 
/// Пространство имён View.
/// </summary>
namespace View
{
    partial class TrainingCalcForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">true - если управляемые 
        /// ресурсы должны быть освобождены;
        /// иначе - false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainingCalcForm));
            groupBoxСalculator = new GroupBox();
            dataGridViewSpace = new DataGridView();
            buttonAdd = new Button();
            buttonDelete = new Button();
            buttonSearch = new Button();
            buttonReset = new Button();
            buttonRandom = new Button();
            buttonCleanFilter = new Button();
            toolStripDropDownButton = new ToolStripDropDownButton();
            SaveToolStripMenuItem = new ToolStripMenuItem();
            OpenToolStripMenuItem = new ToolStripMenuItem();
            toolStrip = new ToolStrip();
            groupBoxСalculator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSpace).BeginInit();
            toolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxСalculator
            // 
            groupBoxСalculator.BackColor = Color.Transparent;
            groupBoxСalculator.Controls.Add(dataGridViewSpace);
            groupBoxСalculator.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupBoxСalculator.Location = new Point(32, 39);
            groupBoxСalculator.Margin = new Padding(3, 2, 3, 2);
            groupBoxСalculator.Name = "groupBoxСalculator";
            groupBoxСalculator.Padding = new Padding(3, 2, 3, 2);
            groupBoxСalculator.Size = new Size(732, 293);
            groupBoxСalculator.TabIndex = 0;
            groupBoxСalculator.TabStop = false;
            groupBoxСalculator.Text = "Программа тренировок";
            groupBoxСalculator.Enter += groupBoxСalculator_Enter;
            // 
            // dataGridViewSpace
            // 
            dataGridViewSpace.AllowUserToOrderColumns = true;
            dataGridViewSpace.AllowUserToResizeColumns = false;
            dataGridViewSpace.AllowUserToResizeRows = false;
            dataGridViewSpace.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSpace.Location = new Point(7, 20);
            dataGridViewSpace.Margin = new Padding(3, 2, 3, 2);
            dataGridViewSpace.Name = "dataGridViewSpace";
            dataGridViewSpace.ReadOnly = true;
            dataGridViewSpace.RowHeadersWidth = 51;
            dataGridViewSpace.RowTemplate.Height = 25;
            dataGridViewSpace.Size = new Size(717, 269);
            dataGridViewSpace.TabIndex = 1;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(645, 336);
            buttonAdd.Margin = new Padding(3, 2, 3, 2);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(116, 38);
            buttonAdd.TabIndex = 2;
            buttonAdd.Text = "Рассчитать свою тренировку";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += ButtonAdd_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(157, 337);
            buttonDelete.Margin = new Padding(3, 2, 3, 2);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(116, 38);
            buttonDelete.TabIndex = 3;
            buttonDelete.Text = "Удалить тренировку";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += ButtonDelete_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(401, 337);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(116, 38);
            buttonSearch.TabIndex = 4;
            buttonSearch.Text = "Фильтр тренировок";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += ButtonSearch_Click;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(279, 337);
            buttonReset.Margin = new Padding(3, 2, 3, 2);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(116, 38);
            buttonReset.TabIndex = 5;
            buttonReset.Text = "Удалить все тренировки";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += ButtonReset_Click;
            // 
            // buttonRandom
            // 
            buttonRandom.Location = new Point(35, 337);
            buttonRandom.Name = "buttonRandom";
            buttonRandom.Size = new Size(116, 38);
            buttonRandom.TabIndex = 6;
            buttonRandom.Text = "Случайная тренировка";
            buttonRandom.UseVisualStyleBackColor = true;
            buttonRandom.Click += ButtonRandom_Click;
            // 
            // buttonCleanFilter
            // 
            buttonCleanFilter.Location = new Point(523, 336);
            buttonCleanFilter.Margin = new Padding(3, 2, 3, 2);
            buttonCleanFilter.Name = "buttonCleanFilter";
            buttonCleanFilter.Size = new Size(116, 38);
            buttonCleanFilter.TabIndex = 7;
            buttonCleanFilter.Text = "Сброс фильтра";
            buttonCleanFilter.UseVisualStyleBackColor = true;
            buttonCleanFilter.Click += ButtonCleanFilter_Click;
            // 
            // toolStripDropDownButton
            // 
            toolStripDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton.DropDownItems.AddRange(new ToolStripItem[] { SaveToolStripMenuItem, OpenToolStripMenuItem });
            toolStripDropDownButton.Image = (Image)resources.GetObject("toolStripDropDownButton.Image");
            toolStripDropDownButton.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton.Name = "toolStripDropDownButton";
            toolStripDropDownButton.Size = new Size(49, 22);
            toolStripDropDownButton.Text = "Файл";
            // 
            // SaveToolStripMenuItem
            // 
            SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            SaveToolStripMenuItem.Size = new Size(180, 22);
            SaveToolStripMenuItem.Text = "Сохранить";
            SaveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // OpenToolStripMenuItem
            // 
            OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            OpenToolStripMenuItem.Size = new Size(180, 22);
            OpenToolStripMenuItem.Text = "Загрузить";
            OpenToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // toolStrip
            // 
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(799, 25);
            toolStrip.TabIndex = 8;
            toolStrip.Text = "toolStrip1";
            // 
            // TrainingCalcForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(799, 438);
            Controls.Add(toolStrip);
            Controls.Add(buttonCleanFilter);
            Controls.Add(buttonRandom);
            Controls.Add(buttonReset);
            Controls.Add(buttonSearch);
            Controls.Add(buttonDelete);
            Controls.Add(buttonAdd);
            Controls.Add(groupBoxСalculator);
            ForeColor = SystemColors.ControlText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "TrainingCalcForm";
            Text = "Калькулятор калорий";
            Load += MainForm_Load;
            groupBoxСalculator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewSpace).EndInit();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBoxСalculator;
        private DataGridView dataGridViewSpace;
        private Button buttonAdd;
        private Button buttonDelete;
        private Button buttonSearch;
        private Button buttonReset;
        private Button buttonRandom;
        private Button buttonCleanFilter;
        private ToolStripDropDownButton toolStripDropDownButton;
        private ToolStrip toolStrip;
        private ToolStripMenuItem SaveToolStripMenuItem;
        private ToolStripMenuItem OpenToolStripMenuItem;
    }
}