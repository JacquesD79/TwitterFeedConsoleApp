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
            var user = _feedProvider.GetUsers();
            _feedProvider.GetTweets();
            Console.WriteLine(user);
            Console.ReadKey();
        }
    }
}
