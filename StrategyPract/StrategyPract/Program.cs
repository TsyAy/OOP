using System;

namespace StrategyPract
{
    class Program
    {
        static void Main(string[] args)
        {
            Keyboard MyKeyboard = new Keyboard(68, new MechanicalSystem());
            MyKeyboard.Print();
            MyKeyboard.PrintSystem = new MembraneSystem();
            MyKeyboard.Print();
        }
    }
        interface IPrintable
        {
            void Print();
        }

        class MechanicalSystem : IPrintable
        {
            public void Print()
            {
                Console.WriteLine("Клац-клац, я механическая клавиатура!");
            }
        }

        class MembraneSystem : IPrintable
        {
            public void Print()
            {
                Console.WriteLine("Плюх-плюх, я мембранная клавиатура!");
            }
        }

        class Keyboard
        {
            public IPrintable PrintSystem { private get; set; }
            private int _numberOfKeys;
            

            public Keyboard(int num, IPrintable sys)
            {
                PrintSystem = sys;
                _numberOfKeys = num;
            }

            public void Print()
            {
                PrintSystem.Print();
            }
        }

    
}
