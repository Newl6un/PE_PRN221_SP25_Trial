namespace Euro2024B_LeHoangNhatTan.DataAccessObject
{
    public class AccountsDAO
    {
        private Euro2024BContext? _dbCotext;
        private static AccountsDAO? _instance;

        public AccountsDAO()
        {
            _dbCotext = new Euro2024BContext();
        }

        public static AccountsDAO Instance
        {
            get
            {
                if(_instance == null)
                        _instance = new AccountsDAO();

                return _instance;
            }
        }

        public  Account? GetAccount(string email, string password, string status)
        {
            var account =  _dbCotext!.Accounts
                .Where(a => a.Email.Equals(email) && a.Password!.Equals(password) && a.Status!.Equals(status)).FirstOrDefault();

            return account;
        }

    } 
}
