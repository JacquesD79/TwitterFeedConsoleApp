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

        public List<Tweet> GetTweets()
        {
            return _feedData.GetTweets();
        }

        public Dictionary<string, List<Follower>> GetUsers()
        {
            return _feedData.GetUsers();
        }

        public List<Entities.User> ListUsers()
        {
            throw new NotImplementedException();
        }
    }
}
