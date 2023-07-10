using System;

namespace TestTask.Interfaces
{
    public interface ICreateData
    {
        public string CreateCreditCardNumber();
        public string CreatePhoneNumber();

        public int GetAge(DateTime startDate);
    }
}