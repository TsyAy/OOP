using System;

namespace CommandPract
{
    class Program
    {
        static void Main(string[] args)
        {
            TV SamsungQE75Q77TAU = new TV();
            Pult PutiOtTelevisora = new Pult();
            PutiOtTelevisora.SetCommand(0, new PWR_On(SamsungQE75Q77TAU));
            PutiOtTelevisora.SetCommand(1, new PWR_Off(SamsungQE75Q77TAU));
            PutiOtTelevisora.SetCommand(2, new CH_Next(SamsungQE75Q77TAU));
            PutiOtTelevisora.SetCommand(3, new CH_Prev(SamsungQE75Q77TAU));
            PutiOtTelevisora.PressButton(0);
            PutiOtTelevisora.PressButton(2);
            PutiOtTelevisora.PressButton(3);
            PutiOtTelevisora.PressButton(1);
            Console.ReadLine();
        }
    }

    interface ICommand
    {
        void Execute();
        void Undo();
    }

    class TV
    {
        public void On() => Console.WriteLine("Включился");
        public void Off() => Console.WriteLine("Выключился");
        public void NextChannel() => Console.WriteLine("Следующий канал");
        public void PrevChannel() => Console.WriteLine("Предыдущий канал");
    }

    class PWR_On : ICommand
    {
        private TV _televisor;
        public PWR_On(TV tv)
        {
            if(tv != null) _televisor = tv;
        }
        public void Execute() => _televisor.On();
        public void Undo() => _televisor.Off();
    }

    class PWR_Off : ICommand
    {
        private TV _televisor;
        public PWR_Off(TV tv)
        {
            if (tv != null) _televisor = tv;
        }
        public void Execute() => _televisor.Off();
        public void Undo() => _televisor.On();

    }

    class CH_Next : ICommand
    {
        private TV _televisor;
        public CH_Next(TV tv)
        {
            if (tv != null) _televisor = tv;
        }
        public void Execute() => _televisor.NextChannel();
        public void Undo() => _televisor.PrevChannel();

    }
    class CH_Prev : ICommand
    {
        private TV _televisor;
        public CH_Prev(TV tv)
        {
            if (tv != null) _televisor = tv;
        }
        public void Execute() => _televisor.PrevChannel();
        public void Undo() => _televisor.NextChannel();

    }


    class NoCommand : ICommand
    {
        public void Execute() { }
        public void Undo() { }
    }

    class Pult
    {
        private ICommand[] _buttons; 
        public Pult()
        {
            _buttons = new ICommand[4];
            for(int i=0; i<_buttons.Length; i++)
            {
                _buttons[i] = new NoCommand(); 
            }
        }

        public void SetCommand(int id, ICommand setCommand)
        {
            if (setCommand != null) _buttons[id] = setCommand;
        }

        public void PressButton(int id)
        {
            _buttons[id].Execute();
        }

    }



}
