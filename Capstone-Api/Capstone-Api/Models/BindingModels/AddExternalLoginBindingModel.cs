using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Capstone_Api.Models.BindingModels
{
    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }
}