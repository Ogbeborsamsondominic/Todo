using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTINUATION_TODO
{
    public class TaskManager
    {
        public List<Task> tasks = new List<Task>();

        public List<Task> GetTasksByUser(User user)
        {
            var userTasks = tasks.Where(t => t.UserId == user.Id).ToList();
            return userTasks;
        }
    }
}