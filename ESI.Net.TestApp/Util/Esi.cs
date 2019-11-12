using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESI.Net.TestApp.Data;
using ESI.NET;
using ESI.NET.Enumerations;
using ESI.NET.Models.SSO;
using Microsoft.AspNetCore.Identity;

namespace ESI.Net.TestApp.Util
{
    public static class Esi
    {
        public static async Task UpdateTokenAsync(string refreshToken, ApplicationUser applicationUser, IEsiClient esiClient)

        {
            SsoToken ssoToken = await esiClient.SSO.GetToken(GrantType.RefreshToken, refreshToken);

            AuthorizedCharacterData authorizedCharacterData = new AuthorizedCharacterData() { RefreshToken = refreshToken, Token = ssoToken.AccessToken, TokenType = ssoToken.TokenType, CorporationID = 98342486, ExpiresOn = DateTime.Now.AddSeconds(ssoToken.ExpiresIn), CharacterID = applicationUser.CharID, CharacterName = applicationUser.UserName };
            esiClient.SetCharacterData(authorizedCharacterData);
        }
    }
}
