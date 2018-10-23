using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AthenaFunctionsForUSQL;

namespace AthenaFunctionsForUSQLTests
{
    public class DateTimeTests
    {
        [Fact]
        public void TruncateDateTest()
        {
            var date = DateTime.ParseExact("2018-03-15 14:40:52.531", "yyyy-MM-dd HH:mm:ss.fff",
                System.Globalization.CultureInfo.InvariantCulture);

            var seconds = DateTimeFunctions.TruncateDate(date, DateTimeFunctions.Precision.Second);
            var minute = DateTimeFunctions.TruncateDate(date, DateTimeFunctions.Precision.Minute);
            var hour = DateTimeFunctions.TruncateDate(date, DateTimeFunctions.Precision.Hour);
            var day = DateTimeFunctions.TruncateDate(date, DateTimeFunctions.Precision.Day);
            var week = DateTimeFunctions.TruncateDate(date, DateTimeFunctions.Precision.Week);
            var month = DateTimeFunctions.TruncateDate(date, DateTimeFunctions.Precision.Month);
            var year = DateTimeFunctions.TruncateDate(date, DateTimeFunctions.Precision.Year);

            Assert.Equal("2018-03-15 14:40:52.000", seconds.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Assert.Equal("2018-03-15 14:40:00.000", minute.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Assert.Equal("2018-03-15 14:00:00.000", hour.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Assert.Equal("2018-03-15 00:00:00.000", day.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Assert.Equal("2018-03-12 00:00:00.000", week.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Assert.Equal("2018-03-01 00:00:00.000", month.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Assert.Equal("2018-01-01 00:00:00.000", year.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        [Fact]
        public void TruncateEpochDateTest()
        {
            // Date time: Thursday, March 15, 2018 14:40:52 PM
            var date = 1521124852;

            // Test function on different formats
            var seconds = DateTimeFunctions.TruncateDate(date, DateTimeFunctions.Precision.Second);
            var minute = DateTimeFunctions.TruncateDate(date, DateTimeFunctions.Precision.Minute);
            var hour = DateTimeFunctions.TruncateDate(date, DateTimeFunctions.Precision.Hour);
            var day = DateTimeFunctions.TruncateDate(date, DateTimeFunctions.Precision.Day);
            var week = DateTimeFunctions.TruncateDate(date, DateTimeFunctions.Precision.Week);
            var month = DateTimeFunctions.TruncateDate(date, DateTimeFunctions.Precision.Month);
            var year = DateTimeFunctions.TruncateDate(date, DateTimeFunctions.Precision.Year);

            Assert.Equal("2018-03-15 14:40:52.000", seconds.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Assert.Equal("2018-03-15 14:40:00.000", minute.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Assert.Equal("2018-03-15 14:00:00.000", hour.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Assert.Equal("2018-03-15 00:00:00.000", day.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Assert.Equal("2018-03-12 00:00:00.000", week.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Assert.Equal("2018-03-01 00:00:00.000", month.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Assert.Equal("2018-01-01 00:00:00.000", year.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        [Fact]
        public void TruncateDateStringTest()
        {

            // Test function on different formats
            TruncDateFormatTest("2018-03-15 14:40:52.531", "yyyy-MM-dd HH:mm:ss.fff");
            TruncDateFormatTest("03/15/2018 02:40:52 PM", "MM/dd/yyyy hh:mm:ss tt");
            TruncDateFormatTest("2018-03-15T14:40:52", "yyyy-MM-ddTHH:mm:ss");
        }

        private void TruncDateFormatTest(string date, string format)
        {

            var seconds = DateTimeFunctions.TruncateDate(date, format, DateTimeFunctions.Precision.Second);
            var minute = DateTimeFunctions.TruncateDate(date, format, DateTimeFunctions.Precision.Minute);
            var hour = DateTimeFunctions.TruncateDate(date, format, DateTimeFunctions.Precision.Hour);
            var day = DateTimeFunctions.TruncateDate(date, format, DateTimeFunctions.Precision.Day);
            var week = DateTimeFunctions.TruncateDate(date, format, DateTimeFunctions.Precision.Week);
            var month = DateTimeFunctions.TruncateDate(date, format, DateTimeFunctions.Precision.Month);
            var year = DateTimeFunctions.TruncateDate(date, format, DateTimeFunctions.Precision.Year);

            Assert.Equal("2018-03-15 14:40:52.000", seconds.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Assert.Equal("2018-03-15 14:40:00.000", minute.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Assert.Equal("2018-03-15 14:00:00.000", hour.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Assert.Equal("2018-03-15 00:00:00.000", day.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Assert.Equal("2018-03-12 00:00:00.000", week.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Assert.Equal("2018-03-01 00:00:00.000", month.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Assert.Equal("2018-01-01 00:00:00.000", year.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }
    }
}
