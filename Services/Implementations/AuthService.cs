using AutoMapper;
using Data.Context;
using Data.Models.Responses;
using Data.ViewModels;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services.Implementations
{

    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        public AuthService(AppDbContext context, IConfiguration configuration, IMapper mapper, ITokenService tokenService)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            _tokenService = tokenService;

            if (FirebaseApp.DefaultInstance == null)
            {
                var fbconfig = new FirebaseConfig();
                _configuration.Bind("Firebase", fbconfig);

                var json = JsonConvert.SerializeObject(fbconfig);
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromJson(json)
                });
            }
        }
        public async Task<AuthResponse> Verify(string accessToken)
        {
            //Firebase verify Token
            FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(accessToken);
            string uid = decodedToken.Uid;

            if (decodedToken != null)
            {
                return new AuthResponse()
                {
                    UId = uid,
                    Token = "SUCCESS"
                };
            }

            throw new Exception("Verify Fail!");
            /*var isExistUser = _context.Users.Any(u => u.UId == uid);
            if (!isExistUser)
            {
                throw new Exception("User is not existed");
            }
            else
            {
                
            }*/


        }
    }
}
