using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HutechFoodAPI.Models
{
    public class AdminRole
    {
        public int Id { get; set; }
        public string UserAdmin { get; set; }
        public string PassAdmin { get; set; }
        public string HotenAdmin { get; set; }
        public string EmailAdmin { get; set; }
        public int MaQuyen { get; set; }
    }
}