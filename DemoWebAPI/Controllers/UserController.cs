using Microsoft.AspNetCore.Mvc;
using Model;
using System.Linq;

namespace DemoWebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("Users")]


    public class UserController : Controller
    {

        private List<UserDTO> users = new List<UserDTO>()
        {
           new UserDTO(1,"Rishi", "Admin"),
           new UserDTO(2,"Vraj", "HR"),
           new UserDTO(3,"Bill", "Payroll"),

        };
        /// <summary>
        /// To get a user detail
        /// </summary>
       
        /// <returns></returns>
        [HttpGet("GetUserDetails")]
        
        public List<UserDTO> GetUserDetails()
        {
            return users;
        }
            
        
        /// <summary>
        /// Insert A new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("InsertUserDetails")]

        public List<UserDTO> InsertUserDetails(UserDTO user)
        {
            users.Add(user);
            return users;
        }

        /// <summary>
        /// Update user Details
        /// </summary>
        /// <returns></returns>
        [HttpPut("UpdateuserDetails")]


        public List<UserDTO> UpdateUserDetails(UserDTO user)
        {
            users.Add(user);
            return users;
        }

        /// <summary>
        /// Delete User Details
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpDelete("{userID}")]

        public List<UserDTO> DeleteUserDetails(UserDTO user)
        {
            users.Remove(user);
            return users;
        }

    }
}
