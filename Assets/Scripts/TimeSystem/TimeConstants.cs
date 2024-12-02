namespace TimeSystem
{
    /// <summary>
    /// Provides constant values for time-related components used in the game.
    /// These constants define the boundaries and conversion rates for various time units,
    /// ensuring consistent handling of time throughout the system.
    /// </summary>
    public static class TimeConstants
    {
        // Boundaries for time units
        public const float MinSecond = 0.0f;
        public const float MaxSecond = 60.0f;

        public const int MinMinute = 0;
        public const int MaxMinute = 60;

        public const int MinHour = 0;
        public const int MaxHour = 24;

        public const int MinDay = 0;
        public const int MaxDay = 30;

        public const int MinMonth = 0;
        public const int MaxMonth = 12;

        public const int MinYear = 0;
        public const int MaxYear = 1000;

        // Conversion rates for time units
        public const float SecondsPerMinute = MaxSecond;
        public const float SecondsPerHour = SecondsPerMinute * MaxMinute;
        public const float SecondsPerDay = SecondsPerHour * MaxHour;
        public const float SecondsPerMonth = SecondsPerDay * MaxDay;
        public const float SecondsPerYear = SecondsPerMonth * MaxMonth;

        // Acceptable margin of error for comparing floating-point values
        public const float Tolerance = 1e-3f; // 1 ms
    }
}