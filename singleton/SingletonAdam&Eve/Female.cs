using System;

namespace singleton
{
    public class Female : Human
    {
        public Female() {}
        public Female(string name, Female mother, Male father) : base(name, mother, father) {}
    }
}