using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 
    /// </summary>
    public class UserDTO
    {


        /// <summary>
        /// enter UserId 
        /// </summary>
        public int userId { get; set; }

        /// <summary>
        /// enter UserName 
        /// </summary>
        public string? userName { get; set; }

        /// <summary>
        /// Enter userProperty
        /// </summary>
        /// 
        public string? Role { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <param name="Role"></param>
        public UserDTO(int userId, string userName, string Role) //constuctor with arguments 
        {
            this.userId = userId;
            this.userName = userName;
            this.Role = Role;
        }
    }




}
