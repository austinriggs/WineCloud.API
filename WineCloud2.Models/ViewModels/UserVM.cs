using System;
using System.Collections.Generic;
using System.Text;

namespace WineCloud2.Models.ViewModels
{
    public class UserVM
    {
        public UserVM() { }

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}
