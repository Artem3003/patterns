using System;

namespace patterns
{
    public class Female : Human
    {
        public Female() {}
        public Female(string name, Female mother, Male father) : base(name, mother, father) {}
    }
}