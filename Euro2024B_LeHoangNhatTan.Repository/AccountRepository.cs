using Euro2024B_LeHoangNhatTan.DataAccessObject;

namespace Euro2024B_LeHoangNhatTan.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public Account? GetAccount(string email, string password, string status)
        {
            return AccountsDAO.Instance.GetAccount(email, password, status);
        }
    }
}
