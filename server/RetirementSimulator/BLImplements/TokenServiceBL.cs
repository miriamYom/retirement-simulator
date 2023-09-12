
using AutoMapper;
using BL.DTO;
using DL.DalApi;
using DL.DataObjects;

namespace BL.BLImplements
{
    public class TokenServiceBL : ITokenServiceBL
    {
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;
        public TokenServiceBL(ITokenService tokenService, IMapper mapper)
        {
            this.tokenService = tokenService;
            this.mapper = mapper;
        }

        public Task AddUserRefreshTokens(UserRefreshTokenDTO usersToken)
        {
            UserRefreshToken usersTokenForDal = mapper.Map<UserRefreshTokenDTO, UserRefreshToken>(usersToken);
            return tokenService.AddUserRefreshTokens(usersTokenForDal);
        }

        public Task DeleteUserRefreshTokens(string email, string refreshToken)
        {
            return tokenService.DeleteUserRefreshTokens(email, refreshToken);
        }

        public Task<UserRefreshToken> GetSavedRefreshTokens(string userId, string refreshToken)
        {
            return tokenService.GetSavedRefreshTokens(userId, refreshToken);
        }
    }
}
