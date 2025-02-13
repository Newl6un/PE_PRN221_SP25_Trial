using System;
using System.Collections.Generic;

namespace Euro2024B_LeHoangNhatTan;

public partial class Team
{
    public int Id { get; set; }

    public string TeamName { get; set; } = null!;

    public int Point { get; set; }

    public int? GroupId { get; set; }

    public int Position { get; set; }

    public virtual GroupTeam? Group { get; set; }
}
