namespace TimeSystem
{
    /// <summary>
    /// A static class containing constants for time-related boundaries used in the game.
    /// These values define the minimum and maximum ranges for various time components,
    /// such as seconds, minutes, hours, days, months, years.
    /// </summary>
    public static class TimeConstants
    {
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
    }
}