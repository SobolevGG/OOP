/// <summary> 
/// ������������ ��� View.
/// </summary>
namespace View
{
    /// <summary>
    /// ����� ��� ������������� TrainingCalc.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// ����� ����� � ���������.
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new TrainingCalcForm());
        }
    }
}