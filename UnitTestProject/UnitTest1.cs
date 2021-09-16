using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Provider;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        FeedProvider _feedProvider = new FeedProvider();

        [TestMethod]
        public void UserAlanHasTweets()
        {
            User _user = new User()
            {
                UserName = "Alan"
            };
            bool hasTweets = _feedProvider.GetTweets(_user).Count > 0 ? true : false;

            Assert.IsTrue(hasTweets); 
        }
        [TestMethod]
        public void UserWardHasTweets()
        {
            User _user = new User()
            {
                UserName = "Ward"
            };
            bool hasTweets = _feedProvider.GetTweets(_user).Count > 0 ? true : false;

            Assert.IsTrue(hasTweets);
        }
        [TestMethod]
        public void UserMartinHasNoTweets()
        {
            User _user = new User()
            {
                UserName = "Martin"
            };
            bool hasTweets = _feedProvider.GetTweets(_user).Count > 0 ? true : false;

            Assert.IsFalse(hasTweets);
        }

        [TestMethod]
        public void UsersInFile()
        {
            bool usersExistInFile = _feedProvider.SetupUsersAndFollowers().Count > 0 ? true : false;

            Assert.IsTrue(usersExistInFile);
        }
    }
}
