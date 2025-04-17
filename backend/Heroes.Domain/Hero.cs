namespace Heroes.Domain.Entities
{
    public class Hero
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string HeroName { get; private set; } = string.Empty;
        public DateTime BirthDate { get; private set; }
        public float Height { get; private set; }
        public float Weight { get; private set; }

        public ICollection<HeroSuperPower> HeroSuperPowers { get; private set; } = new List<HeroSuperPower>();

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

        public void Update(string name, string heroName, DateTime birthDate, float height, float weight)
        {
            Name = name;
            HeroName = heroName;
            BirthDate = birthDate;
            Height = height;
            Weight = weight;
        }

        public void ClearPowers()
        {
            HeroSuperPowers.Clear();
        }
    }
}
