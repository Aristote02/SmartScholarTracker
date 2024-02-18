#region
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StudentProgress.BusinessLogic.Exceptions;
using StudentProgress.BusinessLogic.Profiles.Dtos;
using StudentProgress.BusinessLogic.Requests;
using StudentProgress.BusinessLogic.Services.Interfaces;
using StudentProgress.DataAccess.Entities;
using StudentProgress.DataAccess.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
#endregion

namespace StudentProgress.BusinessLogic.Services.Implementations;

public class AppUserService : IAppUserService
{
    private readonly IAppUserRepository _appUserRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    public AppUserService(IAppUserRepository appUserRepository, IMapper mapper, IConfiguration configuration)
    {
        _appUserRepository = appUserRepository;
        _mapper = mapper;
        _configuration = configuration;
    }
    public async Task<AppUserDto> AddAsync(AppUserRequest request)
    {
        var user = await _appUserRepository.GetUserByEmailAsync(request.Email);

        if (user is not null)
        {
            throw new ExistException("A user with this email already exist");
        }

        var appUserWithRole = SetUserRole(_mapper.Map<AppUser>(request));
        var userAdded = await _appUserRepository.AddAsync(appUserWithRole);

        return _mapper.Map<AppUserDto>(userAdded);
    }

    public async Task<AppUserDto> DeleteAsync(AppUserRequest request)
    {
        var user = await _appUserRepository.GetUserByEmailAsync(request.Email);

        if (user is null)
        {
            throw new NotFoundException("There is no user with that email");
        }

        var userDeleted = await _appUserRepository.DeleteAsync(_mapper.Map<AppUser>(request));

        return _mapper.Map<AppUserDto>(userDeleted);
    }

    public async Task<List<AppUserDto>> GetAllUsersAsync()
    {
        var users = await _appUserRepository.GetAllUsersAsync();

        return _mapper.Map<List<AppUserDto>>(users);
    }

    public async Task<AppUserDto> GetUserById(int id)
    {
        var user = await _appUserRepository.GetUserByIdAsync(id);

        if (user is null)
        {
            throw new NotFoundException("There is no user with that Id");
        }

        return _mapper.Map<AppUserDto>(user);
    }

    public async Task<string> LoginAsync(UserLogin userLogin)
    {
        var user = await _appUserRepository.GetUserByEmailAsync(userLogin.Email);

        if (!IsValidUser(user, userLogin))
        {
            throw new Unauthorized("Wrong email or password, please try again or sign up");
        }

        return GenerateToken(user);
    }

    public async Task<AppUserDto> UpdateAsync(AppUserRequest request)
    {
        var user = await _appUserRepository.GetUserByEmailAsync(request.Email);

        if (user is null)
        {
            throw new NotFoundException("There is no user with that Email to be updated");
        }

        var userUpdated = await _appUserRepository.UpdateAsync(_mapper.Map<AppUser>(request));

        return _mapper.Map<AppUserDto>(userUpdated);
    }

    private AppUser SetUserRole(AppUser appUser)
    {
        appUser.RoleId = -2;

        return appUser;
    }
    private bool IsValidUser(AppUser appUser, UserLogin userLogin)
    {
        if (appUser is null)
        {
            throw new NotFoundException("The user was not found");
        }

        if (appUser.Password != userLogin.Password)
        {
            return false;
        }

        return true;
    }

    private string GenerateToken(AppUser appUser)
    {
        var claimsIdentity = new ClaimsIdentity(new Claim[] {
            new Claim(ClaimTypes.Name, appUser.UserName),
            new Claim(ClaimTypes.Email, appUser.Email),
            new Claim(ClaimTypes.Role, appUser.Role.Name)
        });

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = claimsIdentity,
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:key"])), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
