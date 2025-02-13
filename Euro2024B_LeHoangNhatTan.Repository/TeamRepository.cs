
using Euro2024B_LeHoangNhatTan.DataAccessObject;

namespace Euro2024B_LeHoangNhatTan.Repository
{
    public class TeamRepository : ITeamRepository
    {
        public Task CreateTeam(Team team)
        {
            return TeamDAO.Instance.CreateTeam(team);
        }

        public void DeleteTeam(int teamId)
        {
            TeamDAO.Instance.DeleteTeam(teamId);
        }

        public Team? GetTeamById(int teamId)
        {
            return TeamDAO.Instance.GetTeamById(teamId);
        }

        public Team? GetTeamByName(string teamName)
        {
            return TeamDAO.Instance.GetTeamByName(teamName);
        }

        public List<Team> GetTeams()
        {
            return TeamDAO.Instance.GetTeams();
        }

        public void UpdateTeam(int teamId, Team team)
        {
            TeamDAO.Instance.UpdateTeam(teamId, team);
        }
    }
}
