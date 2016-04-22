using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace ManagerReports.Web
{
    public static class ViewExtentions
    {
        /// <summary>
        ///     Округляет число до десятков
        /// </summary>
        public static int RoundToTen(this int number)
        {
            var lastDigit = number%10;
            return lastDigit < 5 ? number/10*10 : (number/10 + 1)*10;
        }

        /// <summary>
        ///     Возвращает процентное содержание числа в source
        /// </summary>
        public static int Percentage(this decimal number, decimal source)
        {
            return source != 0 ? decimal.ToInt32(number / source * 100.0m) : 0;
        }

        /// <summary>
        ///     Возвращает процентное содержание числа в source
        /// </summary>
        /// <remarks>Если в качестве аргумента был передан null, вернет 0</remarks>
        public static int Percentage(this decimal number, decimal? source)
        {
            return Percentage(number, source.GetValueOrDefault(1));
        }

        /// <summary>
        ///     Возвращает процентное содержание числа в source
        /// </summary>
        /// <remarks>Если в качестве аргумента был передан null, вернет 0</remarks>
        public static int Percentage(this decimal? number, decimal? source)
        {
            return Percentage(number.GetValueOrDefault(0), source.GetValueOrDefault(1));
        }

        /// <summary>
        ///     Возвращает исходное значение, но не большее, чем limit
        /// </summary>
        /// <remarks>Если исходное значение больше limit, возвращает limit, иначе - исходное значение</remarks>
        public static int Limit(this int source, int limit)
        {
            return source > limit ? limit : source;
        }

        /// <summary>
        ///     Отображает только значимые цифры после запятой
        /// </summary>
        /// <param name="source">Исходное число</param>
        /// <param name="digitCount">Количество цифр после запятой. Если задан, то ровно столько цифр и будет отображаться</param>
        public static string TrimNonsignificantDigits(this decimal source, int? digitCount = null)
        {
            if (source == 0)
            {
                return "";
            }

            var splittedSource = source.ToString(CultureInfo.InvariantCulture).Split('.', ',');
            var pointDigitsCount = digitCount ?? (splittedSource.Length > 1 ? splittedSource[1].Count(i => i != '0') : 0);
            return source.ToString(string.Concat("N", pointDigitsCount.ToString()));
        }

        /// <summary>
        ///     Отображает только значащие цифры после запятой
        /// </summary>
        /// <param name="source">Исходное число</param>
        /// <param name="digitCount">Количество цифр после запятой. Если задан, то ровно столько цифр и будет отображаться</param>
        /// <remarks>Если в качестве аргумента был передан null, вернет строку "не задано"</remarks>
        public static string TrimNonsignificantDigits(this decimal? source, int? digitCount = null)
        {
            return source.HasValue ? TrimNonsignificantDigits(source.Value, digitCount) : "не задано";
        }

        /// <summary>
        ///     Возвращает атрибут TAttribute заданного перечисления
        /// </summary>
        /// <typeparam name="TAttribute">Тип возвращаемого атрибута</typeparam>
        /// <param name="enumValue">Перечисление</param>
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue) where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .Single()
                            .GetCustomAttribute<TAttribute>();
        }
    }
}