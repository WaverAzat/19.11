using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class Project
    {
        public string Status { get; set; }
        public DateTime Data { get; set; }
        public Teamlead Teamlead { get; set; }
        public Project(string status, DateTime data, Teamlead teamlead)
        {
            Status = status;
            Data = data;
            Teamlead = teamlead;
        }

        public void ChangeStatus()
        {
            Status = "Исполнение";

        }
        public void ClosePr(List<Task> lst)
        {
            int count = 0;
            foreach (Task t in lst)
            {
                if (t.Status == "Выполнена")
                {
                    count++;
                }
            }
            if (count == lst.Count)
            {
                Status = "Закрыт";
            }
            else
            {
                Status = "Исполнение";
            }
        }
        public void ShowStatus()
        {
            Console.WriteLine($"Статус проекта: {Status}");
        }
    }
    public class Task
    {
        public string Opisanie { get; set; }
        public DateTime Srok { get; set; }
        public string Status { get; set; }
        public Employee Employee { get; set; }
        public Otchet Otchet { get; set; }
        public Task(string opisanie, DateTime srok, string status, Employee employee, Otchet otchet)
        {
            Opisanie = opisanie;
            Srok = srok;
            Status = status;
            Employee = employee;
            Otchet = otchet;
        }
    }
    public class Otchet
    {
        public string Text { get; set; }
        public DateTime Data { set; get; }
        public Employee Employee { get; set; }
        public Task Task { get; set; }
        public Otchet(string text, DateTime data, Employee employee, Task task)
        {
            Text = text;
            Data = data;
            Employee = employee;
            Task = task;

        }
        public void ShowOtchet()
        {
            Console.WriteLine($"{Employee.Name} отправил отчёт. Комментарий исполнителя: {Text} Статус выполненной задчи - {Task.Status}. Дата выполнения: {Data}. Дата дедлайна - {Task.Srok}");
        }
    }
    public class Employee
    {
        public string Name { get; set; }
        public Employee(string name)
        {
            Name = name;
        }

        public void TakeTask(Task task)
        {
            Console.WriteLine("Вы берёте задачу? (0 - Взять / 1 - Отклонение / 2 - Делегация задачи)");
            int otvet = int.Parse(Console.ReadLine());
            switch (otvet)
            {
                case 0:
                    task.Status = "В работе";
                    task.Employee = this;
                    break;
                case 1:
                    task.Status = "Назначена";
                    task.Employee = null;
                    break;
                case 2:

                    break;
            }
        }
        public Otchet CreateOtchet(Task t)
        {
            string text = "Выполнил задачу";
            DateTime data = DateTime.Now;
            t.Status = "На проверке";
            return new Otchet(text, data, this, t);
        }
    }
    public class Teamlead
    {
        public string Name { set; get; }
        public Task CreateTask()
        {
            Console.WriteLine("Введите описание задачи");
            string opisanie = Console.ReadLine();
            DateTime data = new DateTime(2022, 12, 31);
            return new Task(opisanie, data, "Назначена", null, null);
        }
        public void ChekTask(Task t)
        {

        }
    }
    public class Zakazchic
    {
        public string Name { set; get; }
        public void TakeOtchet(Otchet o, Task t)
        {
            if (t.Srok < o.Data)
            {
                Console.WriteLine("Задача просрочена");

            }
            else
            {
                Console.WriteLine("Вернуть отчёт? (Y / N)");
                string otv = Console.ReadLine();
                switch (otv)
                {
                    case "Y":
                        t.Status = "В работе";
                        break;
                    case "N":
                        t.Status = "Выполнена";
                        break;
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Teamlead teamlead = new Teamlead();
            Project p = new Project("Проект", new DateTime(2020, 12, 31), teamlead); // создали проект
            List<Task> listTask = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                listTask.Add(teamlead.CreateTask()); // создаём задачи
            }
            List<Employee> listEmp = new List<Employee>(); // штат сотрудников
            listEmp.Add(new Employee("Илья"));
            listEmp.Add(new Employee("Андрей"));
            listEmp.Add(new Employee("Амир"));
            listEmp.Add(new Employee("Кирилл"));
            listEmp.Add(new Employee("Лейсан"));
            listEmp.Add(new Employee("Карина"));
            listEmp.Add(new Employee("Азат"));
            listEmp.Add(new Employee("Халиль"));
            listEmp.Add(new Employee("Алия"));
            listEmp.Add(new Employee("Азамат"));
            for (int i = 0; i < 10; i++)
            {
                listEmp[i].TakeTask(listTask[i]); // раздаём задачи 
            }
            p.ChangeStatus(); // меняем статус проекта на "В исполнении"
            List<Otchet> listOtchet = new List<Otchet>();
            for (int i = 0; i < listEmp.Count; i++)
            {
                listOtchet.Add(listEmp[i].CreateOtchet(listTask[i])); // созадём отчёты
            }
            Zakazchic zakazchic = new Zakazchic();
            foreach (Otchet otchet in listOtchet) // проверяем отчёты
            {
                otchet.ShowOtchet();
                zakazchic.TakeOtchet(otchet, otchet.Task);
            }
            p.ClosePr(listTask);
            p.ShowStatus();
        }
    }
}