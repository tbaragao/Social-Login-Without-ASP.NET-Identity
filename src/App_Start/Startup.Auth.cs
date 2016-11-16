using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Twitter;
using Owin.Security.Providers.LinkedIn;


namespace SocialLoginWithoutIdentity
{
    public partial class Startup
    {
        private void ConfigureAuth(IAppBuilder app)
        {
            var cookieOptions = new CookieAuthenticationOptions
            {
                LoginPath = new PathString("/Account/Login")
            };

            app.UseCookieAuthentication(cookieOptions);

            app.SetDefaultSignInAsAuthenticationType(cookieOptions.AuthenticationType);

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
            {
                ClientId = GoogleClientId,
                ClientSecret = GoogleClientSecret,
                Provider = new GoogleOAuth2AuthenticationProvider()

            });

            app.UseFacebookAuthentication(new FacebookAuthenticationOptions
            {
                AppId = FacebookAppId,
                AppSecret = FacebookAppSecret,
                Provider = new FacebookAuthenticationProvider()

            });

            app.UseTwitterAuthentication(new TwitterAuthenticationOptions
            {
                ConsumerKey = TwitterConsumerKey,
                ConsumerSecret = TwitterConsumerSecret,
                Provider = new TwitterAuthenticationProvider(),
                BackchannelCertificateValidator = new Microsoft.Owin.Security.CertificateSubjectKeyIdentifierValidator(new[]
        {

          "A5EF0B11CEC04103A34A659048B21CE0572D7D47", // VeriSign Class 3 Secure Server CA - G2
          "0D445C165344C1827E1D20AB25F40163D8BE79A5", // VeriSign Class 3 Secure Server CA - G3
          "7FD365A7C2DDECBBF03009F34339FA02AF333133", // VeriSign Class 3 Public Primary CA - G5
          "39A55D933676616E73A761DFA16A7E59CDE66FAD", // Symantec Class 3 Secure Server CA - G4
          "‎add53f6680fe66e383cbac3e60922e3b4c412bed", // Symantec Class 3 EV SSL CA - G3
          "4eb6d578499b1ccf5f581ead56be3d9b6744a5e5", // VeriSign Class 3 Primary CA - G5
          "5168FF90AF0207753CCCD9656462A212B859723B", // DigiCert SHA2 High Assurance Server C‎A 
          "B13EC36903F8BF4701D498261A0802EF63642BC3"  // DigiCert High Assurance EV Root CA
        })
            });



            //app.Use(async (Context, next) =>
            //{
            //    await next.Invoke();
            //});
        }
    }
}