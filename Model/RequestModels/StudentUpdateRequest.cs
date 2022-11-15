using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.RequestModels
{
  /// <summary>
  /// Update request which includes properties to be updated
  /// </summary>
    public class StudentUpdateRequest
    {

        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Name property 
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Mobile.No property
        /// </summary>
        public string? MobileNumber { get; set; }

            /// <summary>
            /// City 
            /// </summary>
            public string? City { get; set; }
        }
}
