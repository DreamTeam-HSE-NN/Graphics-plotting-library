using GraphsPlotting.BaseClasses;
using System.Windows.Input;

namespace GraphsPlotting.Helpers
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Преобразует Key в нормальный символ
        /// </summary>
        public static string GetStringValue(this Key key)
        {
            switch (key)
            {
                case Key.D0: return "0";
                case Key.D1: return "1";
                case Key.D2: return "2";
                case Key.D3: return "3";
                case Key.D4: return "4";
                case Key.D5: return "5";
                case Key.D6: return "6";
                case Key.D7: return "7";
                case Key.D8: return "8";
                case Key.D9: return "9";
                case Key.OemComma: return ",";
                case Key.OemMinus: return "-";

                default:
                    throw new ArgumentException($"Ключ {key} не распознан");
            }
        }

        /// <summary>
        /// Получает значение аттрибута StringValue для Enum-типов
        /// </summary>
        public static string GetStringValue(this Enum value)
        {
            StringValueAttribute[]? attributes = value.GetType().GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
            return attributes != null && attributes.Length != 0 ? attributes[0].StringValue : "";
        }
    }
}
