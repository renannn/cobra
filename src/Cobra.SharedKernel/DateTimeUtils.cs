using System;

namespace Cobra.SharedKernel
{
    public static class DateTimeUtils
    {

        public static readonly DateTime Epoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);


        public static int GetAge(this DateTimeOffset birthday, DateTime comparisonBase, DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.LocalDateTime)
        {
            return GetAge(birthday.GetDateTimeOffsetPart(dateTimeOffsetPart), comparisonBase);
        }

        public static int GetAge(this DateTimeOffset birthday)
        {
            var birthdayDateTime = birthday.UtcDateTime;
            var now = DateTime.UtcNow;
            return GetAge(birthdayDateTime, now);
        }

        public static int GetAge(this DateTime birthday, DateTime comparisonBase)
        {
            var now = comparisonBase;
            var age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age)) age--;

            return age;
        }

        public static int GetAge(this DateTime birthday)
        {
            var now = birthday.Kind.GetNow();
            return GetAge(birthday, now);
        }

        public static DateTime GetDateTimeOffsetPart(
            this DateTimeOffset dateTimeOffset,
            DateTimeOffsetPart dataDateTimeOffsetPart)
        {
            return dataDateTimeOffsetPart switch
            {
                DateTimeOffsetPart.DateTime => dateTimeOffset.DateTime,
                DateTimeOffsetPart.LocalDateTime => dateTimeOffset.LocalDateTime,
                DateTimeOffsetPart.UtcDateTime => dateTimeOffset.UtcDateTime,
                _ => throw new ArgumentOutOfRangeException(nameof(dataDateTimeOffsetPart), dataDateTimeOffsetPart, null),
            };
        }

        public static DateTime GetNow(this DateTimeKind dataDateTimeKind)
        {
            switch (dataDateTimeKind)
            {
                case DateTimeKind.Utc:
                    return DateTime.UtcNow;
                default:
                    return DateTime.Now;
            }
        }

        /// <summary>
        /// Converts a given <see cref="DateTime"/> to milliseconds from Epoch.
        /// </summary>
        /// <param name="dateTime">A given <see cref="DateTime"/></param>
        /// <returns>Milliseconds since Epoch</returns>
        public static long ToEpochMilliseconds(this DateTime dateTime)
        {
            return (long)dateTime.ToUniversalTime().Subtract(Epoch).TotalMilliseconds;
        }

        /// <summary>
        /// Converts a given <see cref="DateTime"/> to milliseconds from Epoch.
        /// </summary>
        /// <param name="dateTime">A given <see cref="DateTime"/></param>
        /// <param name="dateTimeOffsetPart"></param>
        /// <returns>Milliseconds since Epoch</returns>
        public static long ToEpochMilliseconds(this DateTimeOffset dateTime,
            DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.LocalDateTime)
        {
            var dt = dateTime.GetDateTimeOffsetPart(dateTimeOffsetPart);
            return ToEpochMilliseconds(dt);
        }

        /// <summary>
        /// Converts a given <see cref="DateTime"/> to seconds from Epoch.
        /// </summary>
        /// <param name="dateTime">A given <see cref="DateTime"/></param>
        /// <returns>The Unix time stamp</returns>
        public static long ToEpochSeconds(this DateTime dateTime)
        {
            return dateTime.ToEpochMilliseconds() / 1000;
        }

        /// <summary>
        /// Converts a given <see cref="DateTime"/> to seconds from Epoch.
        /// </summary>
        /// <param name="dateTime">A given <see cref="DateTime"/></param>
        /// <param name="dateTimeOffsetPart"></param>
        /// <returns>The Unix time stamp</returns>
        public static long ToEpochSeconds(this DateTimeOffset dateTime,
            DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.LocalDateTime)
        {
            var dt = dateTime.GetDateTimeOffsetPart(dateTimeOffsetPart);
            return ToEpochSeconds(dt);
        }

        /// <summary>
        /// Checks the given date is between the two provided dates
        /// </summary>
        public static bool IsBetween(this DateTime date, DateTime startDate, DateTime endDate, bool compareTime = false)
        {
            return compareTime ? date >= startDate && date <= endDate : date.Date >= startDate.Date && date.Date <= endDate.Date;
        }

        /// <summary>
        /// Checks the given date is between the two provided dates
        /// </summary>
        public static bool IsBetween(this DateTimeOffset date, DateTimeOffset startDate, DateTimeOffset endDate,
            bool compareTime = false,
            DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.LocalDateTime)
        {
            var dateOff = date.GetDateTimeOffsetPart(dateTimeOffsetPart);
            var startDateOff = startDate.GetDateTimeOffsetPart(dateTimeOffsetPart);
            var endDateOff = endDate.GetDateTimeOffsetPart(dateTimeOffsetPart);
            return IsBetween(dateOff, startDateOff, endDateOff, compareTime);
        }

        /// <summary>
        /// Returns whether the given date is the last day of the month
        /// </summary>
        public static bool IsLastDayOfTheMonth(this DateTime dateTime)
        {
            return dateTime == new DateTime(dateTime.Year, dateTime.Month, 1).AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// Returns whether the given date is the last day of the month
        /// </summary>
        public static bool IsLastDayOfTheMonth(this DateTimeOffset dateTime,
            DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.LocalDateTime)
        {
            var dt = dateTime.GetDateTimeOffsetPart(dateTimeOffsetPart);
            return IsLastDayOfTheMonth(dt);
        }

        /// <summary>
        /// Returns whether the given date falls in a weekend
        /// </summary>
        public static bool IsWeekend(this DateTime value)
        {
            return value.DayOfWeek == DayOfWeek.Sunday || value.DayOfWeek == DayOfWeek.Saturday;
        }

        /// <summary>
        /// Returns whether the given date falls in a weekend
        /// </summary>
        public static bool IsWeekend(this DateTimeOffset dateTime,
            DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.LocalDateTime)
        {
            var dt = dateTime.GetDateTimeOffsetPart(dateTimeOffsetPart);
            return IsWeekend(dt);
        }

        /// <summary>
        /// Determines if a given year is a LeapYear or not.
        /// </summary>
        public static bool IsLeapYear(this DateTime value)
        {
            return DateTime.DaysInMonth(value.Year, 2) == 29;
        }

        /// <summary>
        /// Determines if a given year is a LeapYear or not.
        /// </summary>
        public static bool IsLeapYear(this DateTimeOffset dateTime,
            DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.LocalDateTime)
        {
            var dt = dateTime.GetDateTimeOffsetPart(dateTimeOffsetPart);
            return IsLeapYear(dt);
        }

        /// <summary>
        /// Converts a DateTime to a DateTimeOffset
        /// </summary>
        /// <param name="dt">Source DateTime.</param>
        /// <param name="offset">Offset</param>
        public static DateTimeOffset ToDateTimeOffset(this DateTime dt, TimeSpan offset)
        {
            if (dt == DateTime.MinValue)
                return DateTimeOffset.MinValue;

            return new DateTimeOffset(dt.Ticks, offset);
        }

        /// <summary>
        /// Converts a DateTime to a DateTimeOffset
        /// </summary>
        /// <param name="dt">Source DateTime.</param>
        /// <param name="offsetInHours">Offset</param>
        public static DateTimeOffset ToDateTimeOffset(this DateTime dt, double offsetInHours = 0)
            => ToDateTimeOffset(dt, offsetInHours == 0 ? TimeSpan.Zero : TimeSpan.FromHours(offsetInHours));

        /// <summary>
        /// Retruns dt.Date which is the start of the day
        /// </summary>
        public static DateTime GetStartOfDay(this DateTime dt) => dt.Date;

        /// <summary>
        /// Retruns dateTime.Date which is the start of the day
        /// </summary>
        public static DateTime GetStartOfDay(this DateTimeOffset dateTime,
            DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.LocalDateTime)
        {
            var dt = dateTime.GetDateTimeOffsetPart(dateTimeOffsetPart);
            return GetStartOfDay(dt);
        }

        /// <summary>
        /// Retruns the end of the day
        /// </summary>
        public static DateTime GetEndOfDay(this DateTime dt) => dt.Date.AddTicks(-1).AddDays(1);

        /// <summary>
        /// Retruns the end of the day
        /// </summary>
        public static DateTime GetEndOfDay(this DateTimeOffset dateTime,
            DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.LocalDateTime)
        {
            var dt = dateTime.GetDateTimeOffsetPart(dateTimeOffsetPart);
            return GetEndOfDay(dt);
        }

        /// <summary>
        /// برای نمونه تاریخ جمعه‌ی قبلی را باز می‌گرداند
        /// </summary>
        /// <param name="dt">تاریخ</param>
        /// <param name="dayOfWeek">مبنای محاسبه</param>
        /// <param name="includeToday">آیا امروز هم محاسبه شود؟</param>
        /// <returns></returns>
        public static DateTime GetPrevious(this DateTime dt, DayOfWeek dayOfWeek, bool includeToday = true)
        {
            if (dt.DayOfWeek == dayOfWeek)
            {
                if (includeToday)
                {
                    return dt;
                }
                dt.AddDays(1);
            }
            int diff = (7 + (dt.DayOfWeek - dayOfWeek)) % 7;
            return dt.AddDays(-diff).Date;
        }

        public static DateTime GetPrevious(this DateTimeOffset dateTime, DayOfWeek dayOfWeek, bool includeToday = true,
            DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.LocalDateTime)
        {
            var dt = dateTime.GetDateTimeOffsetPart(dateTimeOffsetPart);
            return GetPrevious(dt, dayOfWeek, includeToday);
        }

        public static DateTime GetNext(this DateTime dt, DayOfWeek dayOfWeek, bool includeToday = true)
        {
            if (dt.DayOfWeek == dayOfWeek)
            {
                if (includeToday)
                {
                    return dt;
                }
                dt.AddDays(-1);
            }
            return dt.AddDays(DayOfWeek.Saturday - dt.DayOfWeek).Date;
        }

        public static DateTime GetNext(this DateTimeOffset dateTime, DayOfWeek dayOfWeek, bool includeToday = true,
            DateTimeOffsetPart dateTimeOffsetPart = DateTimeOffsetPart.LocalDateTime)
        {
            var dt = dateTime.GetDateTimeOffsetPart(dateTimeOffsetPart);
            return GetNext(dt, dayOfWeek, includeToday);
        }
    }
}