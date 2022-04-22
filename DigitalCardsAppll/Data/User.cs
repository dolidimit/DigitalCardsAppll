using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DigitalCardsAppll.Data
{
    public class User : IdentityUser
    {
        [MaxLength(20)]
        public string FullName { get; set; }

    
    }
}
