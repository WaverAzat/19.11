using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW10
{
    class Game : IBeach, IMyGame, IHill, IMousetrap, ISea, IPostman, IFishing
    {
        static Random r = new Random();
        void IMousetrap.Game(Team t)
        {
            Console.WriteLine("Начинается игра Мышеловка!!! Выступает команда {0}" + "\n...", t.Name);
            for (int i = 0; i < 5; i++)
            {

                t.Points += r.Next(0, 5);
            }
            Console.WriteLine($"Очки команды после игры: {t.Points}");
            Thread.Sleep(1000);
        }
        void IHill.Game(Team t)
        {
            Console.WriteLine("Начинается игра Горка!!! Выступает команда {0}" + "\n...", t.Name);

            if (r.Next(20, 100) > 60)
            {
                t.Points += 5;
            }
            else
            {
                t.Points += 10;
            }
            Console.WriteLine($"Очки команды после игры: {t.Points}");
            Thread.Sleep(1000);
        }
        void ISea.Game(Team t)
        {
            Console.WriteLine("Начинается игра Море!!! Выступает команда {0}" + "\n...", t.Name);

            for (int i = 0; i < 8; i++)
            {
                t.Points += r.Next(0, 3);
            }
            Console.WriteLine($"Очки команды после игры: {t.Points}");
            Thread.Sleep(1000);
        }
        void IBeach.Game(Team t)
        {
            Console.WriteLine("Начинается игра Пляж!!! Выступает команда {0}" + "\n...", t.Name);

            for (int i = 0; i < 5; i++)
            {
                t.Points += r.Next(0, 5);
            }
            Console.WriteLine($"Очки команды после игры: {t.Points}");
            Thread.Sleep(1000);
        }
        void IPostman.Game(Team t)
        {
            Console.WriteLine("Начинается игра Почтальон!!! Выступает команда {0}" + "\n...", t.Name);

            for (int i = 0; i < 2; i++)
            {
                t.Points += r.Next(0, 10);
            }
            Console.WriteLine($"Очки команды после игры: {t.Points}");
            Thread.Sleep(1000);
        }
        void IFishing.Game(Team t)
        {
            Console.WriteLine("Начинается игра Рыбалка!!! Выступает команда {0}" + "\n...", t.Name);
            for (int i = 0; i < 6; i++)
            {

                if (r.Next(0, 10) > 5)
                {
                    t.Points += 10;
                }
                else if (r.Next(0, 10) <= 5 && r.Next(0, 10) > 0)
                {
                    t.Points += 5;
                }
                else
                {
                    t.Points -= 1;
                }
            }
            Console.WriteLine($"Очки команды после игры: {t.Points}");
            Thread.Sleep(1000);
        }
        void IMyGame.Game(Team t)
        {
            Console.WriteLine("Начинается игра Вилки и Розетки!!! Выступает команда {0}" + "\n...", t.Name);

            for (int i = 0; i < 2; i++)
            {
                t.Points += r.Next(0, 4);
            }
            Console.WriteLine($"Очки команды после игры: {t.Points}");
            Thread.Sleep(1000);
        }
        public void Endgame(List<Team> list)
        {
            foreach (Team t in list)
            {
                Console.WriteLine($"Команда {t.Name} набрала {t.Points} очков");
            }
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].Points == list[i + 1].Points)
                {
                    list[i].Points++;
                }
            }
            var sortlist = list.OrderByDescending(x => x.Points).ToList();
            Console.WriteLine($"Победила команда {sortlist[0].Name} с количеством очков: {sortlist[0].Points}");
        }
    }
}