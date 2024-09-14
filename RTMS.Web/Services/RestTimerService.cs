namespace RTMS.Web.Services
{
    public class RestTimerService : IDisposable
    {
        private System.Timers.Timer _timer;
        private TimeSpan _remainingTime;
        private CancellationTokenSource _cancellationTokenSource;
        public TimeSpan RemainingTime => _remainingTime;
        public bool IsRunning => _timer != null && _timer.Enabled && _remainingTime > TimeSpan.Zero;

        public event Action OnTimerChanged;

        public void StartTimer(int seconds)
        {
            _remainingTime = TimeSpan.FromSeconds(seconds);
            _cancellationTokenSource?.Cancel(); // Stop any previous timer
            _cancellationTokenSource = new CancellationTokenSource();

            _timer?.Stop(); // Ensure any existing timer is stopped
            _timer?.Dispose(); // Dispose of any existing timer

            _timer = new System.Timers.Timer(1000); // 1-second interval
            _timer.Elapsed += OnTimerElapsed;
            _timer.AutoReset = true;
            _timer.Enabled = true;

            // Trigger UI update on timer start
            OnTimerChanged?.Invoke();
        }

        public void StopTimer()
        {
            _timer?.Stop();
            _timer?.Dispose();
            _timer = null;

            // Trigger UI update on timer stop
            OnTimerChanged?.Invoke();
        }

        private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_cancellationTokenSource.Token.IsCancellationRequested)
            {
                StopTimer();
                return;
            }

            if (_remainingTime > TimeSpan.Zero)
            {
                _remainingTime = _remainingTime.Subtract(TimeSpan.FromSeconds(1));

                // Notify subscribers about the change
                OnTimerChanged?.Invoke();
            }
            else
            {
                StopTimer(); // Stop when it hits zero, no need to render zero
            }
        }

        void IDisposable.Dispose()
        {
            StopTimer();
            _cancellationTokenSource?.Dispose();
        }
    }
}
