using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Models.Responses;


namespace Services.Interfaces
{
    public interface IAuthService
    {
         Task<AuthResponse> Verify(string accessToken);
     
    }
}
