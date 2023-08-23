using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OrdersApp.Core.DTO
{
    public class RegisterDTO
    {
        #region Properties

        [Required(ErrorMessage = "Person Name can't be blank.")]
        public string PersonName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email can't be blank.")]
        [EmailAddress(ErrorMessage = "Email address should be in a proper email address format.")]
        [Remote(action: "IsEmailAlreadyRegistered", controller: "Account", ErrorMessage = "Email already in use.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number can't be blank.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone Number should contain only digits.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password can't be blank.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirm Password can't be blank.")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        #endregion
    }
}
