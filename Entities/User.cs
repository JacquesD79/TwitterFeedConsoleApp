using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public User()
        {
            Followers = new List<User>();
            Tweets = new List<Tweet>();
        }
        public string UserName { get; set; }
        public List<User> Followers { get; set; }
        public List<Tweet> Tweets { get; set; }

    }
}
