using System;

namespace TimeSystem
{
    /// <summary>
    /// Represents the time data for in-game time management (second, minute, hour, day, month, year).
    /// This class ensures that all time components are within specified ranges, throwing exceptions for invalid values.
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
        /// Default constructor that initializes the time data with minimum valid values.
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
            const float secondsPerMinute = TimeConstants.MaxSecond;
            const float secondsPerHour = secondsPerMinute * TimeConstants.MaxMinute;
            const float secondsPerDay = secondsPerHour * TimeConstants.MaxHour;
            const float secondsPerMonth = secondsPerDay * TimeConstants.MaxDay;
            const float secondsPerYear = secondsPerMonth * TimeConstants.MaxMonth;

            int year = (int)(absoluteTime / secondsPerYear);
            absoluteTime %= secondsPerYear;
            int month = (int)(absoluteTime / secondsPerMonth);
            absoluteTime %= secondsPerMonth;
            int day = (int)(absoluteTime / secondsPerDay);
            absoluteTime %= secondsPerDay;
            int hour = (int)(absoluteTime / secondsPerHour);
            absoluteTime %= secondsPerHour;
            int minute = (int)(absoluteTime / secondsPerMinute);
            float second = (float)(absoluteTime % secondsPerMinute);

            return new TimeData(second, minute, hour, day, month, year);
        }

        /// <summary>
        /// Converts the current TimeData instance into absolute time value in seconds.
        /// </summary>
        public double ToAbsoluteTime()
        {
            const float secondsPerMinute = TimeConstants.MaxSecond;
            const float secondsPerHour = secondsPerMinute * TimeConstants.MaxMinute;
            const float secondsPerDay = secondsPerHour * TimeConstants.MaxHour;
            const float secondsPerMonth = secondsPerDay * TimeConstants.MaxDay;
            const float secondsPerYear = secondsPerMonth * TimeConstants.MaxMonth;

            return Second + Minute * secondsPerMinute + Hour * secondsPerHour + Day * secondsPerDay +
                   Month * secondsPerMonth + Year * secondsPerYear;
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