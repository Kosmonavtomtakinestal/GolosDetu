using System;
using System.Collections.Generic;

namespace LSDA.Database.Models;

public partial class Result
{
    public int ParticipantId { get; set; }

    public int Count { get; set; }

    public virtual Participant Participant { get; set; } = null!;
}
