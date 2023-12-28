namespace View
{
    partial class AddTrainingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            swimCalcUserControl = new SwimCalcUserControl();
            runCalcUserControl = new RunCalcUserControl();
            pressCalcWageRateUserControl = new PressCalcUserControl();
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
            payrollMethod.Size = new Size(269, 55);
            payrollMethod.TabIndex = 7;
            payrollMethod.TabStop = false;
            payrollMethod.Text = "Тип тренировки";
            payrollMethod.Enter += payrollMethod_Enter;
            // 
            // comboTrainingSelection
            // 
            comboTrainingSelection.FormattingEnabled = true;
            comboTrainingSelection.Location = new Point(17, 20);
            comboTrainingSelection.Margin = new Padding(3, 2, 3, 2);
            comboTrainingSelection.Name = "comboTrainingSelection";
            comboTrainingSelection.Size = new Size(236, 23);
            comboTrainingSelection.TabIndex = 9;
            comboTrainingSelection.SelectedIndexChanged += ComboBoxSalarySelection;
            // 
            // accrualParameters
            // 
            accrualParameters.BackColor = Color.White;
            accrualParameters.Controls.Add(buttonClose);
            accrualParameters.Controls.Add(buttonOk);
            accrualParameters.Controls.Add(swimCalcUserControl);
            accrualParameters.Controls.Add(runCalcUserControl);
            accrualParameters.Controls.Add(pressCalcWageRateUserControl);
            accrualParameters.Location = new Point(8, 62);
            accrualParameters.Margin = new Padding(3, 2, 3, 2);
            accrualParameters.Name = "accrualParameters";
            accrualParameters.Padding = new Padding(3, 2, 3, 2);
            accrualParameters.Size = new Size(269, 150);
            accrualParameters.TabIndex = 10;
            accrualParameters.TabStop = false;
            accrualParameters.Text = "Параметры начисления";
            accrualParameters.Enter += accrualParameters_Enter;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(137, 121);
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
            buttonOk.Location = new Point(17, 121);
            buttonOk.Margin = new Padding(3, 2, 3, 2);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(79, 25);
            buttonOk.TabIndex = 13;
            buttonOk.Text = "ОК";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += ButtonOk;
            // 
            // swimCalcUserControl
            // 
            swimCalcUserControl.BackColor = Color.White;
            swimCalcUserControl.ForeColor = SystemColors.ControlText;
            swimCalcUserControl.Location = new Point(5, 20);
            swimCalcUserControl.Margin = new Padding(3, 2, 3, 2);
            swimCalcUserControl.Name = "swimCalcUserControl";
            swimCalcUserControl.Size = new Size(259, 97);
            swimCalcUserControl.TabIndex = 1;
            // 
            // runCalcUserControl
            // 
            runCalcUserControl.Location = new Point(5, 30);
            runCalcUserControl.Margin = new Padding(3, 2, 3, 2);
            runCalcUserControl.Name = "runCalcUserControl";
            runCalcUserControl.Size = new Size(259, 87);
            runCalcUserControl.TabIndex = 2;
            runCalcUserControl.Load += wageRateUserControl1_Load;
            // 
            // pressCalcWageRateUserControl
            // 
            pressCalcWageRateUserControl.BackColor = Color.Transparent;
            pressCalcWageRateUserControl.Location = new Point(5, 20);
            pressCalcWageRateUserControl.Margin = new Padding(3, 2, 3, 2);
            pressCalcWageRateUserControl.Name = "pressCalcWageRateUserControl";
            pressCalcWageRateUserControl.Size = new Size(264, 68);
            pressCalcWageRateUserControl.TabIndex = 0;
            // 
            // AddTrainingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(284, 232);
            Controls.Add(accrualParameters);
            Controls.Add(payrollMethod);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "AddTrainingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Расчёт тренировки";
            Load += SalaryLoad;
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
        private SwimCalcUserControl swimCalcUserControl;
        private RunCalcUserControl runCalcUserControl;
        private PressCalcUserControl pressCalcWageRateUserControl;
    }
}