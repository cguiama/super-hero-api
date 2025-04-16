namespace Heroes.Application.Features.Heroes.Dtos
{
    public class HeroCreateDto
    {
        public string? Name { get; set; }
        public string? HeroName { get; set; }
        public DateTime BirthDate { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public List<Guid>? SuperPowerIds { get; set; }
    }
}
