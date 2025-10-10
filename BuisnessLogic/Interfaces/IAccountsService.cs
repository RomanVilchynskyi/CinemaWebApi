using BuisnessLogic.DTOs.Accounts;

namespace BuisnessLogic.Interfaces
{
    public interface IAccountsService
    {
        Task Register(RegisterModel model);
        Task Login(LoginModel model);
        Task Logout(LogoutModel model);
    }
}
