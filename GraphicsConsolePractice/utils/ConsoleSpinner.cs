using System;
using System.Threading;
using System.Threading.Tasks;

namespace GraphicsConsolePractice
{
    class Spinner : IDisposable
    {

        private int _posX;
        private int _posY;
        private int _delayMs;
        private bool _isSpinning;
        private int _index = 0;
        private Thread _spinnerThread;


        public static readonly string[] Basic = { "|", "/", "-", "\\" };

        //Constructor
        public Spinner (int x, int y, int delayMs = 100)
        {
            _posX = x;
            _posY = y;
            _delayMs = delayMs;
            _isSpinning = false;
        }

        public void Start()
        {
            if (_isSpinning) return;

            _isSpinning = true;
            Console.CursorVisible = false;
            _spinnerThread = new Thread(SpinnerLoop);
            _spinnerThread.IsBackground = true;
            _spinnerThread.Start();

        }

        private void SpinnerLoop()
        {
            Console.CursorVisible = false;

            try
            {
                while (_isSpinning)
                {
                    Console.SetCursorPosition(_posX, _posY);
                    Console.Write(Basic[_index]);
                    Thread.Sleep(_delayMs);
                    _index = (_index + 1) % Basic.Length;
                }
            }
            finally
            {
                Console.SetCursorPosition(_posX, _posY);
                Console.Write(' ');
                Console.CursorVisible = true;
            }
        }

        public void Stop()
        {
            _isSpinning = false;
            if (_spinnerThread.ThreadState == ThreadState.Running)
            {
                _spinnerThread.Join(1000);
            }
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
