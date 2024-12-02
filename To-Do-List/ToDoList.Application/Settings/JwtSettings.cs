namespace ToDoList.Application.Settings
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public int TokenExpirationMinutes { get; set; }
    }
}
