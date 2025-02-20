using Microsoft.EntityFrameworkCore;

namespace Euro2024B_LeHoangNhatTan.DataAccessObject
{
    public class TeamDAO
    {
        private Euro2024BContext _context;
        private static TeamDAO? _instance;

        public TeamDAO()
        {
            _context = new Euro2024BContext();
        }

        public TeamDAO(Euro2024BContext euro2024BContext)
        {
            _context = euro2024BContext;
        }

        public static TeamDAO Instance
        {
            get
            {
                if( _instance == null )
                    _instance =  new TeamDAO();

                return _instance;
            }
        }

        public Team? GetTeamById(int teamId)
        {
            return _context.Teams.Where(t => t.Id.Equals(teamId)).Include(e => e.Group).AsNoTracking().FirstOrDefault();
        }

        public Team? GetTeamByName(string teamName)
        {
            return _context.Teams.Where(t => t.TeamName.Equals(teamName)).AsNoTracking().FirstOrDefault();
        }

        public List<Team> GetTeams()
        {
            return _context.Teams.Include(e => e.Group).AsNoTracking().ToList();
        }

        public async Task CreateTeam(Team teamforCreate)
        {
            Team? currentTeam = GetTeamByName(teamforCreate.TeamName);
            if (currentTeam != null)
                return;

            await _context.Teams.AddAsync(teamforCreate);
            await _context.SaveChangesAsync();
        }

        public void UpdateTeam(int teamId, Team teamforUpdate)
        {
            Team? currentTeam = GetTeamById(teamId);
            if (currentTeam == null)
                return;

            _context.Teams.Attach(teamforUpdate);
            _context.Entry(teamforUpdate).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteTeam(int teamId)
        {
            Team? currentTeam = GetTeamById(teamId);
            if (currentTeam == null)
                return;

            _context.Teams.Remove(currentTeam);
            _context.SaveChanges();
        }


    }
}
