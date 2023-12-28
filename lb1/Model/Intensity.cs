using System.ComponentModel;

/// <summary>
/// Пространство имён Model.
/// </summary>
namespace Model
{
    /// <summary>
    /// Перечисление для интенсивности.
    /// </summary>
    public enum Intensity
    {
        /// <summary>
        /// Спринт - свыше 15 км/ч.
        /// </summary>
        [Description("Спринт")]
        Sprinting,

        /// <summary>
        /// Быстрый бег - 12 км/ч.
        /// </summary>
        [Description("Быстрый бег")]
        FastRunning,

        /// <summary>
        /// Умеренный бег - 10 км/ч.
        /// </summary>
        [Description("Умеренный бег")]
        ModerateRunning,

        /// <summary>
        /// Лёгкий бег - 8 км/ч.
        /// </summary>
        [Description("Лёгкий бег")]
        LightJogging
    }
}
