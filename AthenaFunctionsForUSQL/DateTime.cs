using System;
using System.Globalization;

namespace AthenaFunctionsForUSQL
{
    public static class DateTimeFunctions
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public enum Precision
        {
            Second,
            Minute,
            Hour,
            Day,
            Week,
            Month,
            Year
        }

        /// <summary>
        /// Truncate the date to the specified precision 
        /// </summary>
        /// <param name="epochTime">The epoch time</param>
        /// <param name="precision">The precision to truncate the date time</param>
        /// <returns>The date time where all fields that are less significant than the selected precision are set to zero</returns>
        public static DateTime TruncateDate(long epochTime, Precision precision)
        {
            DateTime date = epoch.AddSeconds(epochTime);
            return TruncateDate(date, precision);
        }


        /// <summary>
        /// Truncate the date to the specified precision 
        /// </summary>
        /// <param name="dateTime">The date time string</param>
        /// <param name="dateFormat">The date time format</param>
        /// <param name="precision">The precision to truncate the date time</param>
        /// <returns>The date time where all fields that are less significant than the selected precision are set to zero</returns>
        public static DateTime TruncateDate(string dateTime, string dateFormat, Precision precision)
        {
            DateTime date = DateTime.ParseExact(dateTime, dateFormat, CultureInfo.InvariantCulture);
            return TruncateDate(date, precision);
        }

        /// <summary>
        /// Truncate the date to the specified precision 
        /// </summary>
        /// <param name="dateTime">The date time</param>
        /// <param name="precision">The precision to truncate the date time</param>
        /// <returns>The date time where all fields that are less significant than the selected precision are set to zero</returns>
        public static DateTime TruncateDate(DateTime dateTime, Precision precision)
        {
            switch (precision)
            {
                case Precision.Second:
                    return dateTime.Trim(TimeSpan.TicksPerSecond);
                case Precision.Minute:
                    return dateTime.Trim(TimeSpan.TicksPerMinute);
                case Precision.Hour:
                    return dateTime.Trim(TimeSpan.TicksPerHour);
                case Precision.Day:
                    return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
                case Precision.Week:
                    return dateTime.StartOfWeek();
                case Precision.Month:
                    return new DateTime(dateTime.Year, dateTime.Month, 1);
                case Precision.Year:
                    return new DateTime(dateTime.Year, 1, 1);
                default:
                    throw new ArgumentException("Unsupported precision");
            }
        }

        private static DateTime StartOfWeek(this DateTime dt)
        {
            int diff = (7 + (dt.DayOfWeek - DayOfWeek.Monday)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        private static DateTime Trim(this DateTime date, long roundTicks)
        {
            return new DateTime(date.Ticks - date.Ticks % roundTicks, date.Kind);
        }
    }
}