using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10
{
    interface IBeach { void Game(Team t); }
    interface IMousetrap { void Game(Team t); }
    interface ISea { void Game(Team t); }
    interface IFishing { void Game(Team t); }
    interface IPostman { void Game(Team t); }
    interface IHill { void Game(Team t); }
    interface IMyGame { void Game(Team t); }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> lst = new List<Team>();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Введите название страны");
                string t = Console.ReadLine();
                Team team = new Team(t);
                lst.Add(team);
            }
            Game game = new Game();
            foreach (Team t in lst)
            {
                ((IMousetrap)game).Game(t);
                ((ISea)game).Game(t);
                ((IHill)game).Game(t);
                ((IFishing)game).Game(t);
                ((IBeach)game).Game(t);
                ((IMyGame)game).Game(t);
                ((IPostman)game).Game(t);
            }
            game.Endgame(lst);
        }
    }
}