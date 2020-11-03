using System;

namespace ConsoleApplication1
{
    // Класс прямоугольников
    class Rectangle
    {
        // Конструктор класса
        public Rectangle(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        // Метод ввода параметров класаа
        public void enter()
        {
            Console.Write("Введите координату 'x' прямоугольника: ");
            X = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите координату 'y' прямоугольника: ");
            Y = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите ширину прямоугольника: ");
            Width = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите высоту прямоугольника: ");
            Height = Convert.ToDouble(Console.ReadLine());
        }

        ///
        /// Блок геттеров/сеттеров параметров класса
        /// 

        public double X
        {
            get; set;
        }

        public double Y
        {
            get; set;
        }

        public double Width
        {
            get; set;
        }

        public double Height
        {
            get; set;
        }

        // Метод перемещения 
        public void Offset(double x, double y)
        {
            X += x;
            Y += y;
        }

        // Метод изменения размеров
        public void Resize(double width, double height)
        {
            Width += width;
            Height += height;
        }

        // Метод изменения размеров
        public void Resize(double c)
        {
            Width *= c;
            Height *= c;
        }

        // Метод построения прямоугольника r, получаемый пересечением прямоугольников r1 и r2
        public static Rectangle Intersect(Rectangle r1, Rectangle r2)
        {
            double maxStartX = Math.Max(r1.X, r2.X);
            double minEndX = Math.Min(r1.X + r1.Width, r2.X + r2.Width);
            double MaxStartY = Math.Max(r1.Y, r2.Y);
            double minEndY = Math.Min(r1.Y + r1.Height, r2.Y + r2.Height);
            if (minEndX >= maxStartX && minEndY >= MaxStartY)
            {
                return new Rectangle(maxStartX, MaxStartY, minEndX - maxStartX, minEndY - MaxStartY);
            }
            // Если не пересекаются - возвращаем null
            return null;
        }

        // Метод построения прямоугольника r, получаемый объединением прямоугольников r1 и r2
        public static Rectangle Union(Rectangle r1, Rectangle r2)
        {
            double minStartX = Math.Min(r1.X, r2.X);
            double maxEndX = Math.Max(r1.X + r1.Width, r2.X + r2.Width);
            double minStartY = Math.Min(r1.Y, r2.Y);
            double MaxEndY = Math.Max(r1.Y + r1.Height, r2.Y + r2.Height);
            return new Rectangle(minStartX, minStartY, maxEndX - minStartX, MaxEndY - minStartY);
        }

        // Метод преобразования объекта класса в строку (для красивого вывода в консольку)
        public override string ToString()
        {
            return String.Format("Координаты: ({0}, {1})\nШирина: {2}\nВысота: {3}", X, Y, Width, Height);
        }
    }


    class Program
    {
        // основная функция программы, содержащее меню для тестирования методов класса Rectangle
        static void Main(string[] args)
        {
            // объявляем и создаем два объекта класса Rectangle, с помощью которых будем тестировать методы класса Rectangle
            Rectangle r1 = new Rectangle(0, 0, 0, 0);
            Rectangle r2 = new Rectangle(0, 0, 0, 0);

            // запускаем бесконечный цикл для возможности повторного выбора какого-либо пункта меню
            while (true)
            {
                // выводим меню пользователю
                Console.WriteLine("====== МЕНЮ ======");
                Console.WriteLine("1 - ввести координаты первого прямоугольника");
                Console.WriteLine("2 - ввести координаты второго прямоугольника");
                Console.WriteLine("3 - вывести координаты и размеры первого прямоугольника");
                Console.WriteLine("4 - вывести координаты и размеры второго прямоугольника");
                Console.WriteLine("5 - переместить первый прямоугольник");
                Console.WriteLine("6 - переместить второй прямоугольник");
                Console.WriteLine("7 - изменить размеры первого прямоугольника");
                Console.WriteLine("8 - изменить размеры второго прямоугольника");
                Console.WriteLine("9 - вывести прямоугольник, получаемый пересечением первого и второго");
                Console.WriteLine("10 - вывести прямоугольник, получаемый объединением первого и второго");
                Console.WriteLine("11 - завершить работу программы");
                Console.WriteLine();

                // получаем от пользователя выбранный пункт меню
                Console.Write("Введите выбранный пункт меню: ");
                string option = Console.ReadLine();

                // в зависимости от пункта делаем то или иное действие
                switch (option)
                {
                    // если выбран 1 пункт меню
                    case "1":
                        {
                            r1.enter();
                            break;
                        }

                    // если выбран 2 пункт меню
                    case "2":
                        {
                            r2.enter();
                            break;
                        }

                    // если выбран 3 пункт меню
                    case "3":
                        {
                            Console.WriteLine(r1);
                            break;
                        }

                    // если выбран 4 пункт меню
                    case "4":
                        {
                            Console.WriteLine(r2);
                            break;
                        }

                    // если выбран 5 пункт меню
                    case "5":
                        {
                            Console.Write("Введите сколько прибавить к координате 'x': ");
                            double x_plus = Convert.ToDouble(Console.ReadLine());

                            Console.Write("Введите сколько прибавить к координате 'y': ");
                            double y_plus = Convert.ToDouble(Console.ReadLine());

                            r1.Offset(x_plus, y_plus);
                            break;
                        }

                    // если выбран 6 пункт меню
                    case "6":
                        {
                            Console.Write("Введите сколько прибавить к координате 'x': ");
                            double x_plus = Convert.ToDouble(Console.ReadLine());

                            Console.Write("Введите сколько прибавить к координате 'y': ");
                            double y_plus = Convert.ToDouble(Console.ReadLine());

                            r2.Offset(x_plus, y_plus);
                            break;
                        }

                    // если выбран 7 пункт меню
                    case "7":
                        {
                            Console.Write("Введите коэффициент: ");
                            double c = Convert.ToDouble(Console.ReadLine());

                            r1.Resize(c);
                            break;
                        }

                    // если выбран 8 пункт меню
                    case "8":
                        {
                            Console.Write("Введите коэффициент: ");
                            double c = Convert.ToDouble(Console.ReadLine());

                            r2.Resize(c);
                            break;
                        }

                    // если выбран 9 пункт меню
                    case "9":
                        {
                            Rectangle r = Rectangle.Intersect(r1, r2);
                            Console.WriteLine("Получившийся прямоугольник:");
                            Console.WriteLine(r);
                            break;
                        }

                    // если выбран 10 пункт меню
                    case "10":
                        {
                            Rectangle r = Rectangle.Union(r1, r2);
                            Console.WriteLine("Получившийся прямоугольник:");
                            Console.WriteLine(r);
                            break;
                        }

                    // если выбран 11 пункт меню
                    case "11":
                        {
                            // выходим из главной функции, то есть завершаем работу программы
                            return;
                        }

                    // ветка switch'a по умолчанию - сюда попадаем, если не попали в остальные ветки
                    default:
                        {
                            Console.Write("Такого пункта не существует. Пожалуйста, повторите ввод.");
                            break;
                        }
                }
            }
        }
    }
}
