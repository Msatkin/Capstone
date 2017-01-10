using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Capstone_Api.Models.BindingModels
{
    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}