using System;
using System.Collections.Generic;

namespace LSDA.Database.Models;

public partial class Participant
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public int PartyId { get; set; }

    public virtual Party Party { get; set; } = null!;

    public virtual Result? Result { get; set; }

    public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();
}
