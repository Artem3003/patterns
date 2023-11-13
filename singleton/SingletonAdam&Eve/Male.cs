using System;

namespace singleton
{
    public class Male : Human
    {
        public Male() {}
        public Male(string name, Female mother, Male father) : base(name, mother, father) {}
    }
}