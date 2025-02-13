namespace Euro2024B_LeHoangNhatTan.Repository
{
    public interface ITeamRepository
    {
        public Team? GetTeamById(int teamId);

        public Team? GetTeamByName(string teamName);

        public List<Team> GetTeams();

        public Task CreateTeam(Team team);

        public void DeleteTeam(int teamId);

        public void UpdateTeam(int teamId, Team team);
    }
}
