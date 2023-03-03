using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AttendanceRegister.BLL.JWTAuth
{
    public class AuthOptions
    {
        public static string Key { get; } = "eynssssfsdisksuo";
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
