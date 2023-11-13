using System;

namespace singleton
{
    public sealed class Adam : Male
    {
        // lazy object
        // static Adam() {}

        // private static readonly Lazy<Adam> instance = new Lazy<Adam>(() => new Adam());

        // public static Adam GetInstance()
        // {
        //     return instance.Value;
        // }

        // double checked locking 


        private Adam() {} // private constructor

        public new string Name => "Adam";

        private static readonly object _lock = new object(); // locker

        private static Adam _instance;

        public static Adam GetInstance()
        {
            if (_instance == null) // first check
            {
                lock(_lock)
                {
                    if (_instance == null) // second check
                    {
                        _instance = new Adam(); // create single instance
                    }
                }
            }
            return _instance;
        }
    }
}