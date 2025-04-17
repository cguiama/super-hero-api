namespace Heroes.Domain.Entities
{
    public class SuperPower
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;

        public ICollection<HeroSuperPower> HeroSuperPowers { get; private set; } = new List<HeroSuperPower>();

        private SuperPower() { }

        public SuperPower(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            HeroSuperPowers = new List<HeroSuperPower>();
        }
    }
}
