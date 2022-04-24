using System;
using System.Net;
using Dominisoft.Nokates.Common.Infrastructure.Helpers;

namespace Dominisoft.Nokates.Identity.Client
{ 
    public interface IAuthenticationClient
    {
        string Authenticate(string username, string password);
        void Logout();
    }
    public class AuthenticationClient : IAuthenticationClient
{
    private readonly string _serviceRootUri;

    public AuthenticationClient(string serviceRootUri)
    {
        _serviceRootUri = serviceRootUri;
    }

    public string Authenticate(string username,string password)
        => HttpHelper.Post($"{_serviceRootUri}/Authentication/",new NetworkCredential(username,password),string.Empty);

        public void Logout()
            => HttpHelper.Get($"{_serviceRootUri}/metrics/","");

    }
}
