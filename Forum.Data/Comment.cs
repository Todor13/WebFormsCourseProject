//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Forum.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public int Id { get; set; }
        public string Contents { get; set; }
        public System.DateTime Published { get; set; }
        public int AnswerId { get; set; }
        public int UserId { get; set; }
        public bool IsVisible { get; set; }
    
        public virtual Answer Answer { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
