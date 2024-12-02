namespace WebApp.DTO
{
    public class AnimalDTO
    {
        private string name;
        private string profilePictureURL;
        private string introDescription;
        private Dictionary<string, string> characteristics = new Dictionary<string, string>();
        private Dictionary<string, string> topics = new Dictionary<string, string>();
    }
}
