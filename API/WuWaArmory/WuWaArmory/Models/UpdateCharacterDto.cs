namespace WuWaArmory.Models
{
    public class UpdateCharacterDto
    {
        public int? Age { get; set; }
        public required int Rating { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Region { get; set; }
    }
}
