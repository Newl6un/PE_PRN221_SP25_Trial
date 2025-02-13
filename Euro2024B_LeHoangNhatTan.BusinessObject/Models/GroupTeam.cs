using System;
using System.Collections.Generic;

namespace Euro2024B_LeHoangNhatTan;

public partial class GroupTeam
{
    public int GroupId { get; set; }

    public string? GroupName { get; set; }

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
