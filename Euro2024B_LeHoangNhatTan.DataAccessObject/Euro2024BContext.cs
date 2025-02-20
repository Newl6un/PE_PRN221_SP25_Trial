using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Euro2024B_LeHoangNhatTan.DataAccessObject;

public partial class Euro2024BContext : DbContext
{
    public Euro2024BContext()
    {
    }

    public Euro2024BContext(DbContextOptions<Euro2024BContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<GroupTeam> GroupTeams { get; set; }

    public virtual DbSet<Team> Teams { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(GetConnectionString());

    }

    private string? GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true).Build();

        var str = configuration.GetConnectionString("DbConnection");

        return str;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__Accounts__A9D10535A1399FBF");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Status).HasMaxLength(10);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<GroupTeam>(entity =>
        {
            entity.HasKey(e => e.GroupId);

            entity.ToTable("GroupTeam");

            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.GroupName).HasMaxLength(50);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.TeamName).HasMaxLength(50);

            entity.HasOne(d => d.Group).WithMany(p => p.Teams)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_Teams_GroupTeam");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
