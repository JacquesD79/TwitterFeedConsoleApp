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
        public List<User> ListUsers()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, List<Follower>> GetUsers()
        {
            Dictionary<string, List<Follower>> _users = new Dictionary<string, List<Follower>>();
            List<Follower> _followers = new List<Follower>();
            string[] _lineSplitter = userFile.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string _line in _lineSplitter)
            {
                if (!string.IsNullOrWhiteSpace(_line)) // No empty rows allowed
                {
                    string[] _fSplit = _line.Split(new[] { "follows" }, StringSplitOptions.None);
                    string followerName = _fSplit[0].Trim();
                    Follower follower = new Follower()
                    {
                        Name = followerName
                    };

                    if (!string.IsNullOrWhiteSpace(followerName))
                    {
                        string[] splitUsers = _fSplit[1].Split(',');
                        foreach (string name in splitUsers)
                        {
                            _users.TryGetValue(name.Trim(), out _followers);
                            User _user = new User()
                            {
                                UserName = name.Trim(),
                                Followers = _followers != null ? _followers : new List<Follower>()
                            };
                            if (!_users.ContainsKey(name.Trim())) // add user to dict with empty list
                            {
                                _users.Add(name.Trim(), new List<Follower>());
                            }
                            if (!_user.Followers.Contains(follower))
                            {
                                _user.Followers.Add(follower);
                            }
                            _users[name.Trim()] = _user.Followers;
                        }
                    }
                }
            }

            return _users;
        }

        //private List<User> AddFollowersToUser(User _user, List<User> _users, List<Follower> _followers)
        //{
        //    List<User> result = new List<User>();
        //    if (!_users.Contains(_user))
        //    {
        //        //Add new users to list then update followers list anyway
        //        _users.Add(_user);
        //    }
        //    foreach (User u in _users)
        //    {
        //        u.Followers = u.Followers != null ? u.Followers : new List<Follower>();
        //        foreach (Follower f in _followers)
        //        {
        //            if (f.Follows.UserName.Equals(u.UserName))
        //            {
        //                if (!u.Followers.Contains(f)) //prevents adding duplicate followers
        //                {
        //                    u.Followers.Add(f);
        //                }
        //            }
        //        }
        //        result.Add(u);
        //    }
        //    return result;
        //}

        public List<Tweet> GetTweets()
        {
            List<Tweet> tweets = new List<Tweet>();
            var tweetStr = tweetFile;
            return tweets;
        }
    }
}
