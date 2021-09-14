using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Tweet
    {
        public User User { get; set; }
        public string TweetFeed { get; set; }
    }
}
