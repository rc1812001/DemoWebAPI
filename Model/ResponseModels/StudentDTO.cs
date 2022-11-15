using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ResponseModels
{
    /// <summary>
    /// 
    /// </summary>
    public class StudentDTO
    {

        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public string? MobileNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? City { get; set; }
    }
}
