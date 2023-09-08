using System;

namespace patterns
{
    public abstract class Human
    {
        protected string name;
        protected Female mother;
        protected Male father;

        public Human() {}
        public Human(string name, Female mother, Male father)
        {
            this.name = name;
            this.father = father ?? throw new ArgumentNullException();
            this.mother = mother ?? throw new ArgumentNullException();
        }

        public string Name => this.name;

        public Female Mother => this.mother;

        public Male Father => this.father;
    }
}