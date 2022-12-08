namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value >= 0)
                {
                    this.age = value;
                }
            }
        }

        public Person(string name, int age)
        {
            this.name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}

