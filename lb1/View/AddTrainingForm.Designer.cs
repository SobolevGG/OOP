/// <summary> 
/// Пространство имён View.
/// </summary>
namespace View
{
    /// <summary>
    /// Класс для пользовательского ввода.
    /// </summary>
    partial class AddTrainingForm
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTrainingForm));
            payrollMethod = new GroupBox();
            comboTrainingSelection = new ComboBox();
            accrualParameters = new GroupBox();
            buttonClose = new Button();
            buttonOk = new Button();
            runCalcUserControl = new RunCalcUserControl();
            pressCalcUserControl = new PressCalcUserControl();
            swimCalcUserControl = new SwimCalcUserControl();
            payrollMethod.SuspendLayout();
            accrualParameters.SuspendLayout();
            SuspendLayout();
            // 
            // payrollMethod
            // 
            payrollMethod.BackColor = Color.White;
            payrollMethod.Controls.Add(comboTrainingSelection);
            payrollMethod.Location = new Point(8, 2);
            payrollMethod.Margin = new Padding(3, 2, 3, 2);
            payrollMethod.Name = "payrollMethod";
            payrollMethod.Padding = new Padding(3, 2, 3, 2);
            payrollMethod.Size = new Size(264, 55);
            payrollMethod.TabIndex = 7;
            payrollMethod.TabStop = false;
            payrollMethod.Text = "Тип тренировки";
            payrollMethod.Enter += Method_Enter;
            // 
            // comboTrainingSelection
            // 
            comboTrainingSelection.FormattingEnabled = true;
            comboTrainingSelection.Location = new Point(17, 20);
            comboTrainingSelection.Margin = new Padding(3, 2, 3, 2);
            comboTrainingSelection.Name = "comboTrainingSelection";
            comboTrainingSelection.Size = new Size(231, 23);
            comboTrainingSelection.TabIndex = 9;
            comboTrainingSelection.SelectedIndexChanged += ComboBoxTrainingSelection;
            // 
            // accrualParameters
            // 
            accrualParameters.BackColor = Color.White;
            accrualParameters.Controls.Add(buttonClose);
            accrualParameters.Controls.Add(buttonOk);
            accrualParameters.Controls.Add(runCalcUserControl);
            accrualParameters.Controls.Add(pressCalcUserControl);
            accrualParameters.Location = new Point(8, 61);
            accrualParameters.Margin = new Padding(3, 2, 3, 2);
            accrualParameters.Name = "accrualParameters";
            accrualParameters.Padding = new Padding(3, 2, 3, 2);
            accrualParameters.Size = new Size(264, 184);
            accrualParameters.TabIndex = 10;
            accrualParameters.TabStop = false;
            accrualParameters.Text = "Параметры начисления";
            accrualParameters.Enter += Parameters_Enter;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(168, 145);
            buttonClose.Margin = new Padding(3, 2, 3, 2);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(79, 25);
            buttonClose.TabIndex = 14;
            buttonClose.Text = "Отмена";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += ButtonClose;
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(17, 145);
            buttonOk.Margin = new Padding(3, 2, 3, 2);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(79, 25);
            buttonOk.TabIndex = 13;
            buttonOk.Text = "Расчёт";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += ButtonOk;
            // 
            // runCalcUserControl
            // 
            runCalcUserControl.BackColor = Color.White;
            runCalcUserControl.Location = new Point(5, 21);
            runCalcUserControl.Margin = new Padding(3, 2, 3, 2);
            runCalcUserControl.Name = "runCalcUserControl";
            runCalcUserControl.Size = new Size(254, 109);
            runCalcUserControl.TabIndex = 2;
            runCalcUserControl.Load += pressCalcUserControl1_Load;
            // 
            // pressCalcUserControl
            // 
            pressCalcUserControl.BackColor = Color.Transparent;
            pressCalcUserControl.Location = new Point(5, 20);
            pressCalcUserControl.Margin = new Padding(3, 2, 3, 2);
            pressCalcUserControl.Name = "pressCalcUserControl";
            pressCalcUserControl.Size = new Size(264, 97);
            pressCalcUserControl.TabIndex = 0;
            // 
            // swimCalcUserControl
            // 
            swimCalcUserControl.BackColor = Color.White;
            swimCalcUserControl.ForeColor = SystemColors.ControlText;
            swimCalcUserControl.Location = new Point(13, 82);
            swimCalcUserControl.Margin = new Padding(3, 2, 3, 2);
            swimCalcUserControl.Name = "swimCalcUserControl";
            swimCalcUserControl.Size = new Size(254, 109);
            swimCalcUserControl.TabIndex = 11;
            // 
            // AddTrainingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(280, 253);
            Controls.Add(swimCalcUserControl);
            Controls.Add(accrualParameters);
            Controls.Add(payrollMethod);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "AddTrainingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Расчёт тренировки";
            Load += TrainingLoad;
            payrollMethod.ResumeLayout(false);
            accrualParameters.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox payrollMethod;
        private GroupBox accrualParameters;
        private ComboBox comboTrainingSelection;
        private Button buttonOk;
        private Button buttonClose;
        private RunCalcUserControl runCalcUserControl;
        private PressCalcUserControl pressCalcUserControl;
        private SwimCalcUserControl swimCalcUserControl;
    }
}