using UnityEngine;

namespace TimeSystem
{
    /// <summary>
    /// Manages the in-game time system, including time scaling and pausing.
    /// This singleton class updates the absolute time and provides formatted time data.
    /// </summary>
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager Instance;

        private double _absoluteTime;

        [Header("SETTINGS")]
        [SerializeField, Range(0.0f, 144.0f), Tooltip("The scale at which time passes")]
        private float scale = 1.0f;

        [Tooltip("Indicates whether time is currently paused")]
        public bool pause;

        /// <summary>
        /// Initializes the <see cref="TimeManager"/> instance. Ensures that only one instance persists
        /// across different scenes by setting it as a singleton and preventing destruction on scene load.
        /// </summary>
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Updates the absolute time each frame. If the time is not paused.
        /// </summary>
        private void Update()
        {
            if (!pause)
                _absoluteTime += Time.deltaTime * scale;
        }

        /// <summary>
        /// Gets the current absolute time in seconds since the game started.
        /// </summary>
        public double AbsoluteTime => _absoluteTime;

        /// <summary>
        /// Gets the formatted time based on the current absolute time, as an <see cref="TimeData"/> object.
        /// </summary>
        public TimeData FormattedTime => TimeData.FromAbsoluteTime(_absoluteTime);
    }
}