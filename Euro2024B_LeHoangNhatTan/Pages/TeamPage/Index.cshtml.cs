using Microsoft.AspNetCore.Mvc.RazorPages;
using Euro2024B_LeHoangNhatTan.Repository;

namespace Euro2024B_LeHoangNhatTan.Pages.TeamPage
{
    public class IndexModel : PageModel
    {
        private readonly ITeamRepository _teamRepository;

        public IndexModel(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public IList<Team> Team { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Team = _teamRepository.GetTeams();
        }
    }
}
