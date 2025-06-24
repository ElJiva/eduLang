namespace eduLangApp.Models;

public class AuthResponse
{
  public string Message { get; set; }
  public UserData User { get; set; }
  public bool Success { get; set; }
}

public class UserData
{
  public int Id { get; set; }
  public string Email { get; set; }
  public string Role {get;set;}
}