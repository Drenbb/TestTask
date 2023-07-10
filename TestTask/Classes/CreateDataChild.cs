using System;
using System.Collections.Generic;
using TestTask.Interfaces;

namespace TestTask.Classes
{
    public class CreateDataChild : ICreateDataChild
    {
        private Random _random = new Random();
        private string[] _names = { "Елена", "Анастасия", "Арина", "Альбина", "Василиса", "Виктория", "Оливия", "Антон", "Мария", "Сабина" };
        private string[] _lastNames = { "Макаров", "Макарова", "Сахаров", "Черкасов", "Терентьева", "Королев", "Ларин", "Алексеев", "Балашова", "Носова"};
        private PosixDate _posixDate = new PosixDate();
        
        public List<Child> CreateChildList()
        {
            List<Child> listChild = new List<Child>();
            for (int i = 0; i < 5000; i++)
            {
                Child child = new Child();
                child.Id = i;
                child.FirstName = _names[_random.Next(0, 9)];
                child.LastName = _lastNames[_random.Next(0, 9)];
                child.BirthDate = _posixDate.ChildDate();
                child.Gender = _random.Next(0, 2) == 1 ? Gender.Female : Gender.Male;
                listChild.Add(child);
            }
            return listChild;
        }
    }
}