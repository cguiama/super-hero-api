namespace Heroes.Domain.Entities
{
    public class Hero
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string HeroName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public float Height { get; private set; }
        public float Weight { get; private set; }

        public ICollection<HeroSuperPower> HeroSuperPowers { get; private set; }

        
        private Hero() { }

        
        public Hero(string name, string heroName, DateTime birthDate, float height, float weight)
        {
            Id = Guid.NewGuid();
            Name = name;
            HeroName = heroName;
            BirthDate = birthDate;
            Height = height;
            Weight = weight;
            HeroSuperPowers = new List<HeroSuperPower>();
        }

        
        public void AddPower(HeroSuperPower power)
        {
            HeroSuperPowers.Add(power);
        }
    }
}
