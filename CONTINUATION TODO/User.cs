using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CONTINUATION_TODO
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();
        // public List<User> Users { get; set; }
    }
}

