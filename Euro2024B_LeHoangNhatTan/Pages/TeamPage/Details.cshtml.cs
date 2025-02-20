using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Euro2024B_LeHoangNhatTan.DataAccessObject;
using Euro2024B_LeHoangNhatTan.Repository;

namespace Euro2024B_LeHoangNhatTan.Pages.TeamPage
{
    public class DetailsModel : PageModel
    {
        private readonly ITeamRepository _teamRepository;

        public DetailsModel(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public Team Team { get; set; } = default!;

        public IActionResult OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = _teamRepository.GetTeamById((int)id);
            
            if (team == null)
            {
                return NotFound();
            }
            else
            {
                Team = team;
            }
            return Page();
        }
    }
}
