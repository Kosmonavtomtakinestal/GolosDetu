using System;
using System.Collections.Generic;

namespace LSDA.Database.Models;

public partial class Participant
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public string? Description { get; set; }

    public byte[]? Photo { get; set; }

    public int? PartyId { get; set; }

    public virtual Party? Party { get; set; }

    public virtual Result? Result { get; set; }

    public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();
}
