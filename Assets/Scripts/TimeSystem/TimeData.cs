using System;

namespace TimeSystem
{
    /// <summary>
    /// Defines a structure for managing in-game time, encapsulating components like seconds, minutes, hours, days, months, and years. 
    /// Ensures that each component respects predefined valid ranges and provides utility methods for conversions and comparisons.
    /// </summary>
    public class TimeData
    {
        private float _second;
        private int _minute;
        private int _hour;
        private int _day;
        private int _month;
        private int _year;

        /// <summary>
        /// Gets or sets the second. The value must be within the range of <see cref="TimeConstants.MinSecond"/> and <see cref="TimeConstants.MaxSecond"/>.
        /// </summary>
        public float Second
        {
            get => _second;
            set => _second = value is >= TimeConstants.MinSecond and <= TimeConstants.MaxSecond
                ? value
                : throw new ArgumentOutOfRangeException(
                    $"Second must be between {TimeConstants.MinSecond} and {TimeConstants.MaxSecond}");
        }

        /// <summary>
        /// Gets or sets the minute. The value must be within the range of <see cref="TimeConstants.MinMinute"/> and <see cref="TimeConstants.MaxMinute"/>.
        /// </summary>
        public int Minute
        {
            get => _minute;
            set => _minute = value is >= TimeConstants.MinMinute and <= TimeConstants.MaxMinute
                ? value
                : throw new ArgumentOutOfRangeException(
                    $"Minute must be between {TimeConstants.MinMinute} and {TimeConstants.MaxMinute}");
        }

        /// <summary>
        /// Gets or sets the hour. The value must be within the range of <see cref="TimeConstants.MinHour"/> and <see cref="TimeConstants.MaxHour"/>.
        /// </summary>
        public int Hour
        {
            get => _hour;
            set => _hour = value is >= TimeConstants.MinHour and <= TimeConstants.MaxHour
                ? value
                : throw new ArgumentOutOfRangeException(
                    $"Hour must be between {TimeConstants.MinHour} and {TimeConstants.MaxHour}");
        }

        /// <summary>
        /// Gets or sets the day. The value must be within the range of <see cref="TimeConstants.MinDay"/> and <see cref="TimeConstants.MaxDay"/>.
        /// </summary>
        public int Day
        {
            get => _day;
            set => _day = value is >= TimeConstants.MinDay and <= TimeConstants.MaxDay
                ? value
                : throw new ArgumentOutOfRangeException(
                    $"Day must be between {TimeConstants.MinDay} and {TimeConstants.MaxDay}");
        }

        /// <summary>
        /// Gets or sets the month. The value must be within the range of <see cref="TimeConstants.MinMonth"/> and <see cref="TimeConstants.MaxMonth"/>.
        /// </summary>
        public int Month
        {
            get => _month;
            set => _month = value is >= TimeConstants.MinMonth and <= TimeConstants.MaxMonth
                ? value
                : throw new ArgumentOutOfRangeException(
                    $"Month must be between {TimeConstants.MinMonth} and {TimeConstants.MaxMonth}");
        }

        /// <summary>
        /// Gets or sets the year. The value must be within the range of <see cref="TimeConstants.MinYear"/> and <see cref="TimeConstants.MaxYear"/>.
        /// </summary>
        public int Year
        {
            get => _year;
            set => _year = value is >= TimeConstants.MinYear and <= TimeConstants.MaxYear
                ? value
                : throw new ArgumentOutOfRangeException(
                    $"Year must be between {TimeConstants.MinYear} and {TimeConstants.MaxYear}");
        }

        /// <summary>
        /// Constructor that initializes the time data with minimum valid values.
        /// </summary>
        public TimeData()
        {
            Second = TimeConstants.MinSecond;
            Minute = TimeConstants.MinMinute;
            Hour = TimeConstants.MinHour;
            Day = TimeConstants.MinDay;
            Month = TimeConstants.MinMonth;
            Year = TimeConstants.MinYear;
        }

        /// <summary>
        /// Constructor that initializes the time data with specific values.
        /// </summary>
        public TimeData(float second, int minute, int hour, int day, int month, int year)
        {
            Second = second;
            Minute = minute;
            Hour = hour;
            Day = day;
            Month = month;
            Year = year;
        }

        /// <summary>
        /// Creates an <see cref="TimeData"/> instance from an absolute time value in seconds.
        /// </summary>
        public static TimeData FromAbsoluteTime(double absoluteTime)
        {
            int year = (int)(absoluteTime / TimeConstants.SecondsPerYear);
            absoluteTime %= TimeConstants.SecondsPerYear;
            int month = (int)(absoluteTime / TimeConstants.SecondsPerMonth);
            absoluteTime %= TimeConstants.SecondsPerMonth;
            int day = (int)(absoluteTime / TimeConstants.SecondsPerDay);
            absoluteTime %= TimeConstants.SecondsPerDay;
            int hour = (int)(absoluteTime / TimeConstants.SecondsPerHour);
            absoluteTime %= TimeConstants.SecondsPerHour;
            int minute = (int)(absoluteTime / TimeConstants.SecondsPerMinute);
            float second = (float)(absoluteTime % TimeConstants.SecondsPerMinute);

            return new TimeData(second, minute, hour, day, month, year);
        }

        /// <summary>
        /// Creates an absolute time value in seconds from an <see cref="TimeData"/> instance.
        /// </summary>
        public static double ToAbsoluteTime(TimeData formattedTime)
        {
            return formattedTime.Second +
                   formattedTime.Minute * TimeConstants.SecondsPerMinute +
                   formattedTime.Hour * TimeConstants.SecondsPerHour +
                   formattedTime.Day * TimeConstants.SecondsPerDay +
                   formattedTime.Month * TimeConstants.SecondsPerMonth +
                   formattedTime.Year * TimeConstants.SecondsPerYear;
        }

        /// <summary>
        /// Computes a hash code for the current <see cref="TimeData"/> instance.
        /// The hash code is calculated based on the second (with tolerance applied), minute, hour, day, month, and year.
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine((int)(Second / TimeConstants.Tolerance), Minute, Hour, Day, Month, Year);
        }

        /// <summary>
        /// Determines whether two TimeData instances are equal within a small tolerance.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is TimeData other)
            {
                return this == other;
            }
            return false;
        }

        /// <summary>
        /// Determines whether two TimeData instances are equal within a small tolerance.
        /// </summary>
        public static bool operator ==(TimeData a, TimeData b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;

            return Math.Abs(ToAbsoluteTime(a) - ToAbsoluteTime(b)) < TimeConstants.Tolerance;
        }

        /// <summary>
        /// Determines whether two TimeData instances are not equal.
        /// </summary>
        public static bool operator !=(TimeData a, TimeData b) => !(a == b);

        /// <summary>
        /// Determines whether one TimeData instance is less than or equal to another.
        /// </summary>
        public static bool operator <=(TimeData a, TimeData b) => ToAbsoluteTime(a) <= ToAbsoluteTime(b);

        /// <summary>
        /// Determines whether one TimeData instance is greater than or equal to another.
        /// </summary>
        public static bool operator >=(TimeData a, TimeData b) => ToAbsoluteTime(a) >= ToAbsoluteTime(b);

        /// <summary>
        /// Determines whether one TimeData instance is less than another.
        /// </summary>
        public static bool operator <(TimeData a, TimeData b) => ToAbsoluteTime(a) < ToAbsoluteTime(b);

        /// <summary>
        /// Determines whether one TimeData instance is greater than another.
        /// </summary>
        public static bool operator >(TimeData a, TimeData b) => ToAbsoluteTime(a) > ToAbsoluteTime(b);

        /// <summary>
        /// Adds two TimeData instances together.
        /// </summary>
        public static TimeData operator +(TimeData a, TimeData b) =>
            FromAbsoluteTime(ToAbsoluteTime(a) + ToAbsoluteTime(b));

        /// <summary>
        /// Subtracts one TimeData instance from another. Throws an exception if the first instance is less than the second.
        /// </summary>
        public static TimeData operator -(TimeData a, TimeData b)
        {
            if (a < b)
                throw new InvalidOperationException("Cannot subtract a larger TimeData from a smaller one");

            return FromAbsoluteTime(ToAbsoluteTime(a) - ToAbsoluteTime(b));
        }

        /// <summary>
        /// Returns a string representation of the TimeData object in the format:
        /// "YYYY-MM-DD HH:MM:SS".
        /// </summary>
        public override string ToString()
        {
            return $"{Year:D4}-{Month:D2}-{Day:D2} {Hour:D2}:{Minute:D2}:{Second:F2}";
        }
    }
}