using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class FeedData : IFeedData
    {
        string tweetFile = FileResource.tweet;
        string userFile = FileResource.user;

        public List<User> GetUsersAndFollowers()
        {
            List<User> _users = new List<User>();
            string[] _userFileLineSplitter = userFile.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string _line in _userFileLineSplitter)
            {
                if (!string.IsNullOrWhiteSpace(_line)) // No empty rows allowed
                {
                    string[] _fSplit = _line.Split(new[] { "follows" }, StringSplitOptions.None);
                    string followerName = _fSplit[0].Trim();
                    
                    if (!string.IsNullOrWhiteSpace(followerName))
                    {
                        User follower = new User()
                        {
                            UserName = followerName
                        };

                        if (!_users.Any(x => x.UserName.Equals(follower.UserName))) // add follower of type user to dict with empty list
                        {
                            _users.Add(follower);
                        }
                        string[] splitUsers = _fSplit[1].Split(',');
                        foreach (string name in splitUsers)
                        {
                            User _user = new User()
                            {
                                UserName = name.Trim()
                            };

                            if (!_users.Any(x => x.UserName.Equals(name.Trim()))) // add user to dict with empty list
                            {
                                _users.Add(_user);
                            }

                            //Get current users saved followers list to add more followers to user
                            _user.Followers = _users.Where(x => x.UserName.Equals(name.Trim())).FirstOrDefault().Followers;

                            //Prevent duplicate followers and user cannot follow self
                            if (!_user.Followers.Any(x => x.UserName.Equals(follower.UserName)) && !follower.UserName.Equals(_user.UserName))
                            {
                                _user.Followers.Add(follower);
                            }
                        }
                    }
                }
            }
            return _users;
        }

        public List<Tweet> GetTweets(User user)
        {
            string[] _tweetFileLineSplitter = tweetFile.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            List<Tweet> tweets = new List<Tweet>();
            bool didUserPostTweet = false;

            foreach (string _line in _tweetFileLineSplitter)
            {
                try
                {
                    string[] _tweetLineUserSplitter = _line.Split('>');
                    if (!string.IsNullOrWhiteSpace(_tweetLineUserSplitter[0]))
                    {
                        Tweet tweet = new Tweet()
                        {
                            TweetFeed = _tweetLineUserSplitter[1].Length <= 140 ? _tweetLineUserSplitter[1] : _tweetLineUserSplitter[1].Substring(0, 137) + "...", // trim characters greater than 140
                            User = new User() { UserName = _tweetLineUserSplitter[0] }
                        };
                        tweets.Add(tweet);
                    }
                    if (user.UserName.Equals(_tweetLineUserSplitter[0].Trim())) 
                    {
                        didUserPostTweet = true;
                    }
                }
                catch
                {
                    // return an empty list if there is an error to prevent the app from breaking
                    return new List<Tweet>();
                }
            }
            // if the users tweet is in the list then display it else no need to display
            return didUserPostTweet == true ? tweets : new List<Tweet>();
        }

    }
}
