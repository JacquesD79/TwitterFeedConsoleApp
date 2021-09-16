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
        List<User> SetupUsersAndFollowers();
        List<Tweet> GetTweets(User user);
    }
}
