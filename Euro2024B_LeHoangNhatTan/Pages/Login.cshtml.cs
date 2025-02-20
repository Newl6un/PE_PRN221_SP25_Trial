using Euro2024B_LeHoangNhatTan.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Euro2024B_LeHoangNhatTan.Pages
{
    public class LoginModel : PageModel
    {
        private IAccountRepository _accountRepository;

        public LoginModel(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void OnGet()
        {
        }

        public void OnPost() 
        {
           var email =  Request.Form["txtEmail"];
           var password = Request.Form["txtPassword"];

            var account = _accountRepository.GetAccount(email, password, "active");

            if(account == null)
            {
                Response.Redirect("/Login");
            }
            else
            {
                HttpContext.Session.SetString("email", account.Email!);
                HttpContext.Session.SetString("role", account.RoleId.ToString());
                Response.Redirect("/TeamPage");
            }
        }
    }
}
