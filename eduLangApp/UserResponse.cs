namespace eduLangApp;

public class UserResponse
{
    public string Message { get; set; }
    public UserData User { get; set; }
}

public class UserData
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}