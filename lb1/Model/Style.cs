using System.ComponentModel;

/// <summary>
/// Пространство имён Model.
/// </summary>
namespace Model
{
    /// <summary>
    /// Перечисление для стилей плавания.
    /// </summary>
    public enum Style
    {
        /// <summary>
        /// Свободный стиль.
        /// </summary>
        [Description("Свободный стиль")]
        Freestyle,

        /// <summary>
        /// На спине.
        /// </summary>
        [Description("На спине")]
        Backstroke,

        /// <summary>
        /// Брасс.
        /// </summary>
        [Description("Брасс")]
        Breaststroke,

        /// <summary>
        /// Баттерфляй.
        /// </summary>
        [Description("Баттерфляй")]
        Butterfly
    }
}
