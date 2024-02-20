using System;
using System.Collections.Generic;

namespace LSDA.Database.Models;

public partial class Party
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();
}
