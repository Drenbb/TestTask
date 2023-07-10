using System;
using System.Collections.Generic;
using TestTask.Interfaces;

namespace TestTask.Classes
{
    public class CreateData : ICreateData
    {
        private Random _random = new Random();

        public string CreateCreditCardNumber()
        {
            int num1 = _random.Next(0000, 9999);
            int num2 = _random.Next(0000, 9999);
            int num3 = _random.Next(0000, 999);
            int num4 = _random.Next(0000, 9999);
            return $"{num1} {num2} {num3} {num4}";
        }

        public string CreatePhoneNumber()
        {
            int num1 = _random.Next(000, 999);
            int num2 = _random.Next(000, 999);
            int num3 = _random.Next(00, 99);
            int num4 = _random.Next(00, 99);
            return $"8 {num1}-{num2}-{num3}-{num4}";
        }

        public int GetAge(DateTime startDate)
        {
            int personAge = DateTime.Now.Year - startDate.Year;

            if (startDate.Month == DateTime.Now.Month && DateTime.Now.Day < startDate.Day)
            {
                personAge--;
            }
            else if (DateTime.Now.Month < startDate.Month)
            {
                personAge--;
            }

            return personAge;
        }
    }
}