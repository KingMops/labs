using System;

namespace Lab2_Var2
{
    //Класс "Вектор"
    class Vector2D
    {
        double x, y;
        //Конструктор по умолчанию, нулевой вектор
        public Vector2D() { x = y = 0; }
        //Конструктор с параметрами
        public Vector2D(double x, double y) { this.x = x; this.y = y; }

        //Конструктор копирования
        public Vector2D(Vector2D v)
        {
            this.x = v.x;
            this.y = v.y;
        }
        //Оператор сложения (покомпонентного)
        static public Vector2D operator +(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.x + v2.x, v1.y + v2.y);
        }
        //Вычитания
        static public Vector2D operator -(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.x - v2.x, v1.y - v2.y);
        }
        //Умножения на скаляр (справа и слева)
        static public Vector2D operator *(Vector2D v, double c)
        {
            return new Vector2D(v.x * c, v.y * c);
        }
        static public Vector2D operator *(double c, Vector2D v)
        {
            return new Vector2D(v.x * c, v.y * c);
        }
        //Скалярное произведение
        static public double operator *(Vector2D v1, Vector2D v2)
        {
            return v1.x * v2.x + v1.y * v2.y;
        }

        //Длина вектора в Эвклидовом пространстве
        public double Length
        {
            get { return Math.Sqrt(x * x + y * y); }
        }
        //Для ввода с консоли
        static public Vector2D Input()
        {
            //Результат
            Vector2D result = new Vector2D();
            string s; //Строка для ввода
            do
            {
                Console.Write("x="); //Запрос
                s = Console.ReadLine(); //Получить ответ
            }
            //До тех пор, пока не будет введено правильное действительное число
            while (!double.TryParse(s, out result.x));

            do
            {
                Console.Write("y="); //Запрос
                s = Console.ReadLine(); //Получить ответ
            }
            //До тех пор, пока не будет введено правильное действительное число
            while (!double.TryParse(s, out result.y));

            return result;
        }
        //Для вывода не экран
        public override string ToString()
        {
            return "( " + x.ToString() + " ; " + y.ToString() + " )" + " Длина " + Length.ToString("0.0000");
        }

    }
    class Program
    {
        static void Help()
        {
            Console.WriteLine();
            Console.WriteLine("A Ввести вектор A");
            Console.WriteLine("B Ввести вектор B");
            Console.WriteLine("С Ввести скаляр C");
            Console.WriteLine("? Вывести текущие значения");
            Console.WriteLine("+ Вычислить A+B");
            Console.WriteLine("- Вычислить A-B");
            Console.WriteLine("* Вычислить A*C, C*A и A*B");
            Console.WriteLine("Q Закончить работу");
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            Help();
            Vector2D a = new Vector2D();
            Vector2D b = new Vector2D();
            double c = 0;
            string s;
            while (true)
            {
                //Вывод текущего состояния переменных
                Console.WriteLine();
                string str = Console.ReadLine();
                char ch = ' ';
                if (str.Length > 0) ch = str[0];
                //char ch = Console.ReadKey().KeyChar;
                //Console.WriteLine();
                switch (ch)
                {
                    case 'A':
                    case 'a':
                        a = Vector2D.Input();
                        Console.WriteLine("A : " + a.ToString());
                        break;
                    case 'B':
                    case 'b':
                        b = Vector2D.Input();
                        Console.WriteLine("B : " + b.ToString());
                        break;
                    case 'C':
                    case 'c':
                        //Ввести скалярную величину
                        do
                        {
                            Console.Write("c = ");
                            s = Console.ReadLine();
                        }
                        while (!double.TryParse(s, out c));
                        Console.WriteLine("C : " + c.ToString());
                        break;
                    case '+':
                        Console.WriteLine("A+B = " + (a + b).ToString());
                        break;
                    case '-':
                        Console.WriteLine("A-B = " + (a - b).ToString());
                        break;
                    case '*':
                        Console.WriteLine("A * C = " + (a * c).ToString());
                        Console.WriteLine("C * B = " + (c * b).ToString());
                        Console.WriteLine("A * B = " + (a * b).ToString("0.000"));
                        break;
                    case '?':
                        Console.WriteLine("A : " + a.ToString());
                        Console.WriteLine("B : " + b.ToString());
                        Console.WriteLine("C : " + c.ToString());
                        break;
                    case 'Q':
                    case 'q':
                        return;
                    default: //Если неизвестный символ - то помощь
                        Help();
                        break;
                }
                Console.WriteLine("______________________________________");
            }
        }
    }
}