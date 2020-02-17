using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTrackIT.Shared.Models;

namespace TaskTrackIT.Client.Services
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
        Task<RegisterResult> Register(RegisterModel registerModel);
    }
}
