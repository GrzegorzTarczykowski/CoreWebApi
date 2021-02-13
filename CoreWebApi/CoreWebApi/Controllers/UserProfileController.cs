using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        public UserProfileController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await userManager.FindByIdAsync(userId);
            return new
            {
                user.Email,
                user.UserName
            };
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("ForAdmin")]
        public string GetMethodForAdmin()
        {
            return "Get Method For Admin";
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        [Route("ForCustomer")]
        public string GetMethodForCustomer()
        {
            return "Get Method For Customer";
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Customer")]
        [Route("ForAdminOrCustomer")]
        public string GetMethodForAdminOrCustomer()
        {
            return "Get Method For Admin Or Customer";
        }
    }
}