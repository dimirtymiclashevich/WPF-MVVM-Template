using System.Threading.Tasks;

namespace AppName.Common
{
    public class Cancellator
    {
        public volatile bool IsCanceled;

        public void Cancel() => IsCanceled = true;
    }

    /// <summary>
    /// Simple and light-weight class designed only to help supress repeated notifications
    /// about window size change during window's resize.
    /// </summary>
    public class BouncingSuppressor
    {
        private Cancellator _cts;
        private long _number;
        private int _checkTime;

        public BouncingSuppressor(int checkTime = 100)
        {
            _checkTime = checkTime;
        }

        public async Task<bool> Check()
        {
            long number = ++_number;

            _cts?.Cancel();
            _cts = new Cancellator();
            Cancellator cts = _cts;

            await Task.Delay(_checkTime);

            _cts = null;
            return number == _number && !cts.IsCanceled;
        }

        public void Cancel()
        {
            _cts?.Cancel();
        }
    }
}
