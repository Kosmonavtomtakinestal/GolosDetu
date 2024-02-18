using System;
using System.Collections.Generic;

namespace LSDA.Database.Models;

public partial class User
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Series { get; set; } = null!;

    public string Number { get; set; } = null!;

    public string Inn { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();
}
