using System.ComponentModel.DataAnnotations;

namespace AuthHub.Models.Organizations
{
    public class CreateOrganizationRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
