namespace GitInsight.Entities;

public class RepoCheck
{
    public int Id { get; set; }

    [Required, Key] //use as primary key
    public string repoPath { get; set; }

    //[Required]
    public string? lastCheckedCommit { get; set; }

    //one-to-many relationship w. Contributions
    [Required]
    public ICollection<Contribution> Contributions { get; set; } = new HashSet<Contribution>();
}