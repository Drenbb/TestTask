using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Classes;

namespace TestTask
{
    class Program
    {
        
        
        static async Task Main(string[] args)
        {
            string[] names =
            {
                "Елена", "Анастасия", "Арина", "Альбина", "Василиса", "Виктория", "Оливия", "Антон", "Мария", "Сабина"
            };
            string[] lastNames =
            {
                "Макаров", "Макарова", "Сахаров", "Черкасов", "Терентьева", "Королев", "Ларин", "Алексеев", "Балашова",
                "Носова"
            };
            Random random = new Random();

            CreateDataChild createDataChild = new CreateDataChild();
            List<Child> listChild = createDataChild.CreateChildList();
            CreateData createData = new CreateData();
            PosixDate posixDate = new PosixDate();

            List<Person> listPerson = new List<Person>();
            for (int i = 0; i < 10000; i++)
            {
                Person person = new Person();
                person.Id = i;
                person.TransportId = Guid.NewGuid();
                person.FirstName = names[random.Next(0, names.Length)];
                person.LastName = lastNames[random.Next(0, lastNames.Length)];
                person.SequenceId = i;
                var cardCount = random.Next(1, 3);
                List<string> creditCardNumbers = new List<string>();
                for (int i1 = 0; i1 < cardCount; i1++)
                {
                    creditCardNumbers.Add(createData.CreateCreditCardNumber());
                }
                person.CreditCardNumbers = creditCardNumbers.ToArray();
                person.BirthDate = posixDate.PersonDate();
                person.Age = createData.GetAge(new UnixTimestamp(person.BirthDate));
                List<string> phoneNumbers = new List<string>();
                int phoneCount = random.Next(1, 3);
                for (int i1 = 0; i1 < phoneCount; i1++)
                {
                    phoneNumbers.Add(createData.CreatePhoneNumber());
                }
                person.Phones = phoneNumbers.ToArray();
                person.Salary = Convert.ToDouble(random.Next(0, 100));
                person.IsMarred = random.Next(0, 2) == 1;
                person.Gender = random.Next(0, 2) == 1 ? Gender.Female : Gender.Male;
                List<Child> children = new List<Child>();
                for (int ii = 0; ii < random.Next(0, 3); ii++)
                {
                    children.Add(listChild[random.Next(0,listChild.Count-1)]);
                }
                person.Children = children.ToArray();
                listPerson.Add(person);
            }

            JsonWork jsonWork = new JsonWork();

            var jsonStr = jsonWork.Serialize(listPerson);
            FileWork fileWork = new FileWork();

            await fileWork.WriteFile(jsonStr);
            GC.Collect();

            string objStr = await fileWork.ReadFile();
            Console.WriteLine(objStr);

            List<Person> persons = jsonWork.Deserialize<Person>(objStr);
            
            Console.WriteLine("persons count - " + persons.Count);
            int cardC =0;

            foreach (var person in persons)
            {
                cardC += person.CreditCardNumbers.Length;
            }
            
            Console.WriteLine("persons credit card count- " + cardC);
            
            Console.ReadKey();
        }
    }
}