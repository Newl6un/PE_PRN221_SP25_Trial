using Euro2024B_LeHoangNhatTan.DataAccessObject;

namespace Euro2024B_LeHoangNhatTan.Repository
{
    public class GroupTeamRepository : IGroupTeamRepository
    {

        public List<GroupTeam> GetGroupTeams()
        {
            return GroupTeamDAO.Instance.GetGroupTeams();
        }
    }
}
