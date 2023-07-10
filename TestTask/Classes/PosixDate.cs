using System;
using TestTask.Interfaces;

namespace TestTask.Classes
{
    public class PosixDate : IPosixBirthDate
    {
        private Random _random = new Random();
        public long PersonDate()
        {
            DateTime dateMin = new DateTime(1930, 1, 1);
            DateTime dateMax = new DateTime(1990, 1, 1);
            int dateDiff = (dateMax - dateMin).Days;
            DateTime birthDate = dateMin.AddDays(_random.Next(dateDiff));
            
            return new DateTimeOffset(birthDate).ToUnixTimeSeconds();
        }

        public long ChildDate()
        {
            DateTime dateMin = new DateTime(2002, 1, 1);
            int dateDiff = (DateTime.Now - dateMin).Days;
            DateTime birthDate = dateMin.AddDays(_random.Next(dateDiff));
            
            return new DateTimeOffset(birthDate).ToUnixTimeSeconds();
        }
    }
}