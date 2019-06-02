using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.BTO
{
    public class UserBTO
    {
        public string Id { get; set; }
        [Display(Name = "First name")]
        public string FirstName { get; set; }
    }
}
