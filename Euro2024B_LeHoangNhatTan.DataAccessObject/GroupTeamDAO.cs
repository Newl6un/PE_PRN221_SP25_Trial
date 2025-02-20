namespace Euro2024B_LeHoangNhatTan.DataAccessObject
{
    public class GroupTeamDAO
    {
        private Euro2024BContext _context;
        private static GroupTeamDAO _instance;

        public static GroupTeamDAO Instance 
        { 
            get 
            {
                _instance ??= new GroupTeamDAO();
                return _instance; 
            } 
        }

        public GroupTeamDAO()
        {
            _context = new Euro2024BContext();
        }

        public List<GroupTeam> GetGroupTeams()
        {
            return _context.GroupTeams.ToList();
        }
    }
}
