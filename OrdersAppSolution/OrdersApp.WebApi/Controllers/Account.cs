using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrdersApp.Core.DTO;
using OrdersApp.Core.Identity;

namespace OrdersApp.WebApi.Controllers
{
    [AllowAnonymous]
    public class Account : CustomControllerBase
    {
        #region Fields

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        #endregion

        #region Ctors

        public Account(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        #endregion

        #region Action Methods

        [HttpPost("register")]
        public async Task<ActionResult<ApplicationUser>> PostRegister(RegisterDTO registerDTO)
        {
            // Check Model Validation
            if (!ModelState.IsValid)
            {
                string? errorMessage = string.Join(" | ", ModelState.Values.SelectMany(errors => errors.Errors)
                                                                           .Select(err => err.ErrorMessage));
                return Problem(errorMessage);
            }

            // Create User
            ApplicationUser applicationUser = new ApplicationUser()
            {
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.PhoneNumber,
                UserName = registerDTO.Email,
                PersonName = registerDTO.PersonName
            };

            // Inserting user into user database table
            IdentityResult result = await _userManager.CreateAsync(applicationUser, registerDTO.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(applicationUser, isPersistent: false);
                return Ok(applicationUser);
            }
            else
            {
                string? errorMessage = string.Join(" | ", result.Errors.Select(err => err.Description));
                return Problem(errorMessage);
            }
        }

        [HttpGet]
        public async Task<IActionResult> IsEmailAlreadyRegistered(string email)
        {
            ApplicationUser? applicationUser = await _userManager.FindByEmailAsync(email);
            if (applicationUser == null)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        #endregion
    }
}
