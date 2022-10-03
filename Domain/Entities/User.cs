using Domain.Data.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity<Guid>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
