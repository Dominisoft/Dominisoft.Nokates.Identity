using System.Collections.Generic;
using Dominisoft.Nokates.Common.Models;

namespace Dominisoft.Nokates.Identity.Models
{
    public class UserRoles
    {
        public User User { get; set; }
        public List<Role> Roles { get; set; }
    }
}
