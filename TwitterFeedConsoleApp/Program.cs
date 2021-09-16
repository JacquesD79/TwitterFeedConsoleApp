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
            var users = _feedProvider.GetUsersAndFollowers();
            var sortedList = users.OrderBy(x => x.UserName).ToList();

            foreach (User user in sortedList)
            {
                user.Tweets = _feedProvider.GetTweets(user);// get current users tweets
                Console.WriteLine($"{user.UserName}");

                foreach (Tweet tweet in user.Tweets)
                {
                    if (!user.Followers.Any(x => x.UserName.Equals(tweet.User.UserName))) // include tweet of user being followed
                    {
                        Console.WriteLine($"\t@{tweet.User.UserName}: {tweet.TweetFeed}");
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
