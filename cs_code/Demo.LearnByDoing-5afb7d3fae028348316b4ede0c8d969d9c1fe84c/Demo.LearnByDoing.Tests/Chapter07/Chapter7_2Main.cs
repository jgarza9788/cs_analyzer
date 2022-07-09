using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.Tests.Chapter07
{
    public class Chapter7_2Main
    {
        public static void Main(string[] args)
        {
            const int callCount = 15;
            Employees handlers = new Employees(callCount);

            List<Employee> employees = GetEmployees(10).ToList();
            List<Manager> managers= GetManagers(4).ToList();
            List<Director> directors = GetDirectors(2).ToList();

            handlers.AddCallHandlers(employees);
            handlers.AddCallHandlers(managers.Cast<Employee>().ToList());
            handlers.AddCallHandlers(directors.Cast<Employee>().ToList());

            handlers.Accept(new CallHandlerVisitor());
        }

        private static IEnumerable<Director> GetDirectors(int directorCount)
        {
            for (int i = 0; i < directorCount; i++)
            {
                yield return new Director("director " + i, true);
            }
        }

        private static IEnumerable<Manager> GetManagers(int managerCount)
        {
            for (int i = 0; i < managerCount; i++)
            {
                yield return new Manager("manager " + i, true);
            }
        }

        private static IEnumerable<Employee> GetEmployees(int employeeCount)
        {
            for (int i = 0; i < employeeCount; i++)
            {
                yield return new Employee("employee " + i, false);
            }
        }
    }

    public class Employees : IElement
    {
        public int CallCount { get; set; }

        public Employees(int callCount)
        {
            CallCount = callCount;
        }

        public List<List<Employee>> Handlers { get; set; } = new List<List<Employee>>();

        public void AddCallHandlers(List<Employee> employees)
        {
            Handlers.Add(employees);
        }

        public void Accept(IVisitor visitor)
        {
            //visitor.Visit(this, CallCount);
            List<Employee> employees = Handlers.SelectMany(group => group).ToList();
            foreach (Employee employee in employees)
            {
                employee.Accept(visitor);
            }
        }
    }

    public interface IElement
    {
        void Accept(IVisitor visitor);
    }

    public interface IVisitor
    {
        void Visit(IElement element, int callCount);
    }

    public class CallHandlerVisitor : IVisitor
    {
        public static int CurrentCall { get; set; } = 0;

        public void Visit(IElement element, int callCount)
        {
            var employee = element as Employee;
            if (employee.CanHandleCall)
            {
                Console.WriteLine("{0} is handling the call {1}", employee.Name, CurrentCall++);
            }
        }
    }

    public class Director : Manager
    {
        public Director(string name, bool isHandlingCall) : base(name, isHandlingCall)
        {
        }
    }

    public class Manager : Employee
    {
        public Manager(string name, bool isHandlingCall) : base(name, isHandlingCall)
        {
        }
    }

    public class Employee : IElement
    {
        public string Name { get; set; }
        public bool CanHandleCall { get; set; }

        public Employee(string name, bool canHandleCall)
        {
            Name = name;
            CanHandleCall = canHandleCall;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this, 1);
        }
    }
}
