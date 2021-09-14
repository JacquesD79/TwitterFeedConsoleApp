using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IFeedData
    {
        List<User> ListUsers();
        Dictionary<string, List<Follower>> GetUsers();
        List<Tweet> GetTweets();
    }
}
