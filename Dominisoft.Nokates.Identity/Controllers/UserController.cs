using System.Collections.Generic;
using Dominisoft.Nokates.Common.Infrastructure.Controllers;
using Dominisoft.Nokates.Common.Infrastructure.Helpers;
using Dominisoft.Nokates.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dominisoft.Nokates.Identity.Controllers
{
    [Route("[controller]")]

    public class UserController : BaseController<User>
    {
        public UserController() : base(RepositoryHelper.CreateRepository<User>())
        { }
        [HttpGet("All")]
        public List<User> GetAllUsers()
        {
            return Repository.GetAll();
        }
    }
}
