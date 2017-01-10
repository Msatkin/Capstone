using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;

namespace Capstone
{
    class Auth
    {
        public bool IsAuthenticated { get { return _isAuthenticated; } }

        private string _clientId = "119543361125-8k9f8911j82a167e8msa25573atnbaqq.apps.googleusercontent.com";
        private string _clientSecret = "kmkqKMD15aKXBocb10GmFteZ";
        private bool _isAuthenticated = false;
        private OAuth2Authenticator auth;

        public void LoginWithGoogle()
        {
            auth = new OAuth2Authenticator(
                clientId: _clientId,
                clientSecret: _clientSecret,
                scope: "https://www.googleapis.com/auth/userinfo.email",
                authorizeUrl: new Uri("https://accounts.google.com/o/oauth2/auth"),
                redirectUrl: new Uri("https://www.googleapis.com/plus/v1/people/me"),
                accessTokenUrl: new Uri("https://accounts.google.com/o/oauth2/token"),
                getUsernameAsync: null
            );
            auth.Completed += (sender, e) => {
                _isAuthenticated = auth.IsAuthenticated();
            };
        }
    }
}
