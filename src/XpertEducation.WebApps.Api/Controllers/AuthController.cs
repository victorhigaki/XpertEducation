﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XpertEducation.Core.Notifications;
using XpertEducation.GestaoAlunos.Application;
using XpertEducation.WebApps.Api.Models;

namespace XpertEducation.WebApps.Api.Controllers;

public class AuthController : BaseController
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtSettings _jwtSettings;
    private readonly IAlunoAppService _alunoService;

    public AuthController(SignInManager<IdentityUser> signInManager,
                          UserManager<IdentityUser> userManager,
                          IOptions<JwtSettings> jwtSettings,
                          INotifications notifications,
                          IAlunoAppService alunoService) : base(notifications)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtSettings = jwtSettings.Value;
        _alunoService = alunoService;
    }

    [HttpPost("registrar")]
    public async Task<IActionResult> Registrar(RegisterUserViewModel registrarUsuario)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        var user = new IdentityUser
        {
            UserName = registrarUsuario.Email,
            Email = registrarUsuario.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, registrarUsuario.Password);

        if (result.Succeeded)
        {
            await AddAluno(user);
            await _signInManager.SignInAsync(user, isPersistent: false);
            return CustomResponse(await GerarJwt(registrarUsuario.Email));
        }

        return CustomResponse("Falha ao registrar o usuário");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserViewModel loginUser)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

        if (result.Succeeded)
        {
            return CustomResponse(await GerarJwt(loginUser.Email));
        }

        return CustomResponse("Usuário ou senha incorreta");
    }

    private async Task<string> GerarJwt(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var roles = await _userManager.GetRolesAsync(user);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Issuer = _jwtSettings.Emissor,
            Audience = _jwtSettings.ValidoEm,
            Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpiracaoHoras),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        });

        var encodedToken = tokenHandler.WriteToken(token);

        return encodedToken;
    }

    private async Task AddAluno(IdentityUser user)
    {
        var userId = await _userManager.GetUserIdAsync(user);
        await _userManager.AddToRoleAsync(user, "Aluno");
        await _alunoService.Adicionar(new AlunoViewModel { Id = new Guid(userId) });
    }
}
