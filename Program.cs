using System;

namespace patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Combos combos = ComboCreator.CreateCombos(ComboCode.LITE);
            combos.PrintOrder();
            
            Combos combos1 = ComboCreator.CreateCombos(ComboCode.FAMILY);
            combos.PrintOrder();

            Combos combos2 = ComboCreator.CreateCombos(ComboCode.MEGA);
            combos.PrintOrder();
        }
    }
}