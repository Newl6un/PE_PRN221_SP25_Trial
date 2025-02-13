using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Euro2024B_LeHoangNhatTan.DataAccessObject;

namespace Euro2024B_LeHoangNhatTan.Pages.TeamPage
{
    public class DetailsModel : PageModel
    {
        private readonly Euro2024BContext _context;

        public DetailsModel(Euro2024BContext context)
        {
            _context = context;
        }

        public Team Team { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FirstOrDefaultAsync(m => m.Id == id);
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
