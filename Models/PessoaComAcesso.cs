using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HanamiAPI.Models
{
    public class PessoaComAcesso : IdentityUser<int>
    {
        public ICollection<Posts> Posts { get; set; } = new List<Posts>();
    }
}
