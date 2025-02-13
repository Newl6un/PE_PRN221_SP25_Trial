namespace Euro2024B_LeHoangNhatTan.Repository
{
    public interface IAccountRepository
    {
        Account? GetAccount(string email, string password, string status);
    }
}
