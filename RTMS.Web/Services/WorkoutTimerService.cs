using System.Timers;

namespace RTMS.Web.Services
{
    public class WorkoutTimerService : IDisposable
    {
        private System.Timers.Timer _timer;
        private DateTime _startTime;

        public TimeSpan ElapsedTime => DateTime.UtcNow - _startTime;

        public event Action OnTimerChanged;

        public void StartTimer(DateTime startTime)
        {
            _startTime = startTime;

            // Dispose of any existing timer before creating a new one
            _timer?.Stop();
            _timer?.Dispose();

            // Initialize a new timer that ticks every second
            _timer = new System.Timers.Timer(1000); // 1-second interval
            _timer.Elapsed += OnTimerElapsed;
            _timer.AutoReset = true;
            _timer.Start();

            // Trigger an immediate UI update when the timer starts
            OnTimerChanged?.Invoke();
        }

        public void StopTimer()
        {
            // Stop and dispose the timer when no longer needed
            _timer?.Stop();
            _timer?.Dispose();
            _timer = null;

            // Trigger UI update on timer stop
            OnTimerChanged?.Invoke();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Notify subscribers (UI) that the timer has updated
            OnTimerChanged?.Invoke();
        }

        public void Dispose()
        {
            // Ensure the timer is properly cleaned up
            StopTimer();
        }
    }
}
