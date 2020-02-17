using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TaskTrackIT.Shared.Models;
using System.Net.Http.Headers;

namespace TaskTrackIT.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            this.httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<RegisterResult> Register(RegisterModel registerModel)
        {
            var result = await httpClient.PostJsonAsync<RegisterResult>("api/Register", registerModel);
            return result;
        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            LoginResult result;
            try
            {
                result = await httpClient.PostJsonAsync<LoginResult>("api/Login", loginModel);
                if (result.Successful)
                {
                    await _localStorage.SetItemAsync("authToken", result.Token);
                    ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(result.Token);
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
                }
            }
            catch(Exception ex)
            {
                result = new LoginResult
                {
                    Successful = false,
                    Error = "Internet Access Failure" + ex.Message
                };
            }
            return result;
        }

        public async Task Logout()
        {
            System.Diagnostics.Debug.WriteLine($"{this.GetType().Name} AuthService: Logout begins");
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            httpClient.DefaultRequestHeaders.Authorization = null;
            System.Diagnostics.Debug.WriteLine($"{this.GetType().Name} AuthService: Logout completed");
        }
    }
}
