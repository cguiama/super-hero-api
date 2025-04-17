namespace Heroes.Domain.Entities
{
    public class HeroSuperPower
    {
        public Guid HeroId { get; private set; }
        public Hero Hero { get; private set; } = null!;

        public Guid SuperPowerId { get; private set; }
        public SuperPower SuperPower { get; private set; } = null!;

        private HeroSuperPower() { }

        public HeroSuperPower(Guid heroId, Guid superPowerId)
        {
            HeroId = heroId;
            SuperPowerId = superPowerId;
        }

        public HeroSuperPower(Hero hero, SuperPower power)
        {
            Hero = hero;
            HeroId = hero.Id;
            SuperPower = power;
            SuperPowerId = power.Id;
        }
    }
}
