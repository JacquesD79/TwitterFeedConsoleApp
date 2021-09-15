using Entities;
using Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterFeedConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FeedProvider _feedProvider = new FeedProvider();
            var users = _feedProvider.SetupUsersAndFollowers();
            var sortedList = users.OrderBy(x => x.UserName).ToList();
            foreach (User user in sortedList)
            {
                Console.WriteLine($"{user.UserName}");
                foreach (Tweet tweet in user.Tweets)
                {
                    Console.WriteLine($"\t@{user.UserName}: {tweet.TweetFeed}");
                }
            }

            Console.ReadKey();
        }
    }
}
