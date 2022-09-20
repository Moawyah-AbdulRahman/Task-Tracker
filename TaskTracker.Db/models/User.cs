namespace TaskTracker.Db;

public class User
{
    public long UserID { get; set; }

    public string Username { get; set; } = "";

    public string email { get; set; } = "";

    public string Password { get; set; } = "";

    public ICollection<Project>? OwnedProjects { get; set; }

    public ICollection<Project>? AccessableProjects { get; set; }

    public ICollection<Task>? Tasks { get; set; }
    
    public long? TeamId { get; set; }

    public Team? Team { get; set; }
}