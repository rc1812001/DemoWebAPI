using System;
using System.Collections.Generic;

namespace Model.DBModels;
 /// <summary>
 /// 
 /// </summary>
public partial class StudentTable
{
    /// <summary>
    /// 
    /// </summary>
    public int StudentId { get; set; }


    /// <summary>
    /// 
    /// </summary>
    public string StudentName { get; set; } = null!;


    /// <summary>
    /// 
    /// </summary>
    public string? MobileNumber { get; set; }



    /// <summary>
    /// 
    /// </summary>
    public string? City { get; set; }
}
