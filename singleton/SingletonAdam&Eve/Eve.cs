using System;

namespace singleton
{
    public sealed class Eve : Female
    {
        private Eve() {} // constructor default

        public new string Name => "Eve";

        private static readonly object _lock = new object();

        private static Eve _instance;

        public static Eve GetInstance(Adam adam)
        {
            if (adam == null)
            {
                throw new ArgumentNullException();
            }
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Eve(); 
                    }
                }
            }
            return _instance;
        } 
    }
}