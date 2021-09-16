using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider
{
    public class FeedProvider : IFeedData
    {
        private readonly IFeedData _feedData;
        public FeedProvider()
        {
            _feedData = new FeedData();
        }

        public List<Tweet> GetTweets(User user)
        {
            return _feedData.GetTweets(user);
        }

        public List<User> SetupUsersAndFollowers()
        {
            return _feedData.SetupUsersAndFollowers();
        }


    }
}
