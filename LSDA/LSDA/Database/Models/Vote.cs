namespace LSDA.Database.Models;

public partial class Vote
{
    public int Id { get; set; }

    public int ParticipantId { get; set; }

    public int UserId { get; set; }

    public virtual Participant Participant { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
