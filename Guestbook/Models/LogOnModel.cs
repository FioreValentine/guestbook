using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Guestbook.Models
{
    public class LogOnModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }
}