using Microsoft.JSInterop;
using System.Timers;

namespace RTMS.Web.Services
{
    public class RestTimerService : IDisposable
    {
        private System.Timers.Timer _timer;
        private TimeSpan _remainingTime;
        private readonly IJSRuntime _jsRuntime;

        public TimeSpan RemainingTime => _remainingTime;
        public bool IsRunning => _timer != null && _timer.Enabled && _remainingTime > TimeSpan.Zero;

        public event Action OnTimerChanged;

        public RestTimerService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public void StartTimer(int seconds)
        {
            _remainingTime = TimeSpan.FromSeconds(seconds);

            // Dispose of any existing timer before creating a new one
            _timer?.Stop();
            _timer?.Dispose();

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

        private async void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (_remainingTime > TimeSpan.Zero)
            {
                _remainingTime = _remainingTime.Subtract(TimeSpan.FromSeconds(1));

                // Check for the last 5 seconds
                if (_remainingTime.TotalSeconds <= 3 && _remainingTime.TotalSeconds > 0)
                {
                    // Play short beep sound
                    await _jsRuntime.InvokeVoidAsync("playBeep", "short");
                }
                else if (_remainingTime.TotalSeconds == 0)
                {
                    // Play long beep sound when time is up
                    await _jsRuntime.InvokeVoidAsync("playBeep", "long");
                }

                // Notify subscribers about the change
                OnTimerChanged?.Invoke();
            }
            else
            {
                StopTimer(); // Stop when it hits zero
            }
        }

        void IDisposable.Dispose()
        {
            StopTimer();
        }
    }
}
