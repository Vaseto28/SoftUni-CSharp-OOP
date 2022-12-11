namespace T05.BirthdayCelebrations
{
    public class Citizen : IObject, IName, IBirthday
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }

        public string Birthday { get; set; }

        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }
    }
}

