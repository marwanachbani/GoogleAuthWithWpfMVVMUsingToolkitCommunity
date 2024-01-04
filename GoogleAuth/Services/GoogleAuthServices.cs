using Google.Apis.Auth.OAuth2;
using Google.Apis.Plus.v1;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleAuth.Services
{
    internal class GoogleAuthServices
    {
        private const string ClientId = "xxxx";
        private const string ClientSecret = "xxxx";

        public async Task<UserCredential> AuthenticateAsync(CancellationToken cancellationToken = default)
        {
            

            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = ClientId,
                    ClientSecret = ClientSecret
                },
                new[] { PlusService.Scope.UserinfoProfile },
                "user",
                cancellationToken,
                new FileDataStore("Google.Apis.Auth.WPF.Store")
            );

            return credential;
        }
    }
}
