namespace Animals
{
    public class Animal
    {
        private string name;
        private string favouriteFood;

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

        public string FavouriteFood
        {
            get
            {
                return this.favouriteFood;
            }
            set
            {
                this.favouriteFood = value;
            }
        }

        public Animal(string name, string favouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
        }

        public virtual string ExplainSelf()
        {
            return string.Empty;
        }
    }
}

