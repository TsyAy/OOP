using System;

namespace PrototypePract
{
    class Program
    {
        static void Main(string[] args)
        {
            IFigure newCircle = new Circle(6);
            IFigure CircleClone = newCircle.Clone();
            newCircle.GetInfo();
            CircleClone.GetInfo();

            IFigure newSquare = new Square(10);
            IFigure SquareClone = newSquare.Clone();
            newSquare.GetInfo();
            SquareClone.GetInfo();

            IFigure newRectangle = new Rectangle(10, 18);
            IFigure RectangleClone = newRectangle.Clone();
            newRectangle.GetInfo();
            RectangleClone.GetInfo();

            IFigure RectangleCloneClone = RectangleClone.Clone();
            RectangleCloneClone.GetInfo();
        }

        interface IFigure
        {
            IFigure Clone();
            void GetInfo();
        }

        class Circle : IFigure
        {

            private int _radius;

            public Circle(int Radius) => _radius = Radius;

            public IFigure Clone() 
            {
                return new Circle(this._radius);
            }

            public void GetInfo() => Console.WriteLine("Это круг с радиусом {0}", _radius);
        }

        class Square : IFigure
        {

            private int _side;

            public Square(int side) => _side = side;

            public IFigure Clone()
            {
                return new Square(this._side);
            }

            public void GetInfo() => Console.WriteLine("Это квадрат с стороной {0}", _side);
        }

        class Rectangle : IFigure
        {

            private int _height, _weight;

            public Rectangle(int h, int w) {_height = h; _weight = w;} 

            public IFigure Clone()
            {
                return new Rectangle(this._height, this._weight);
            }

            public void GetInfo() => Console.WriteLine("Это прямоугольник с сторонами {0} и {1}", _height, _weight);
        }
    }
}
