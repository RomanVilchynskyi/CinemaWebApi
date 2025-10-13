using System.ComponentModel;

namespace BuisnessLogic.DTOs.Accounts
{
    public class LoginModel
    {
        [DefaultValue("rere@gmail.com")]
        public string Email { get; set; }

        [DefaultValue("Qwert-123")]
        public string Password { get; set; }
    }
}
