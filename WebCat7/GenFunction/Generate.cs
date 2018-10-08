using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebCat7.Models.AccountViewModels;

namespace WebCat7.GenFunction
{
    public class Generate
    {

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> generate([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Could not create token");

            var user = await UserManager.FindByEmailAsync(model.Email);

            if (user == null) return BadRequest("Could not create token");

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (!result.Succeeded) return BadRequest("Could not create token");

            var userClaims = await _userManager.GetClaimsAsync(user);

            userClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Email));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Issuer,
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
        public async Task<IActionResult> AddEmployeeClaim()

        {

            var user = await _userManager.GetUserAsync(User);

            var claim = new Claim("Employee", "Mosalla");

            var addClaimResult = await _userManager.AddClaimAsync(user, claim);

            return View(addClaimResult);

        }
    }
}