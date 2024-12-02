namespace WebApp.DTO
{
    public class EnclosureDTO
    {
        public EnclosureDTO() { }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string? PFPURL { get; set; }
    }
}
