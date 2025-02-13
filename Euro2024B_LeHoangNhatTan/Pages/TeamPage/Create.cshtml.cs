using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Euro2024B_LeHoangNhatTan.DataAccessObject;

namespace Euro2024B_LeHoangNhatTan.Pages.TeamPage
{
    public class CreateModel : PageModel
    {
        private readonly Euro2024BContext _context;

        public CreateModel(Euro2024BContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["GroupId"] = new SelectList(_context.GroupTeams, "GroupId", "GroupId");
            return Page();
        }

        [BindProperty]
        public Team Team { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Teams.Add(Team);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
