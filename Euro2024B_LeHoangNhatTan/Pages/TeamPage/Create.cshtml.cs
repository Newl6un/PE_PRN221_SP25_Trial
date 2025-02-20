using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Euro2024B_LeHoangNhatTan.Repository;
using Microsoft.AspNetCore.Components;

namespace Euro2024B_LeHoangNhatTan.Pages.TeamPage
{
    public class CreateModel : PageModel
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IGroupTeamRepository _groupTeamRepository;

        public CreateModel(ITeamRepository teamRepository, IGroupTeamRepository groupTeamRepository)
        {
            _teamRepository = teamRepository;
            _groupTeamRepository = groupTeamRepository;
        }

        public IActionResult OnGet()
        {
        ViewData["GroupId"] = new SelectList(_groupTeamRepository.GetGroupTeams(), "GroupId", "GroupId");
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

            await _teamRepository.CreateTeam(Team);

            return RedirectToPage("./Index");
        }
    }
}
