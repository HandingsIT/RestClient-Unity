
#nullable enable
[System.Serializable]
public class User
{
    public int Id { get; set; }
    public string? Account { get; set; }
    public string? Password { get; set; }
    public string? Name { get; set; }
    public string? Mail { get; set; }
    public string? PhoneNumber { get; set; }

    public System.DateTime? CreateTime { get; set; }
    public System.DateTime? LogInTime { get; set; }
    public System.DateTime? LogOutTime { get; set; }
}