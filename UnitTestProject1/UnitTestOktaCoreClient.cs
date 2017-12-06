using System;
using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okta.Core;
using Okta.Core.Clients;
using Okta.Core.Models;

namespace UnitTestProject1
{
    /// <summary>
    /// This UnitTest is implemented using Okta.Core.Client v0.3.3
    /// </summary>
    [TestClass]
    public class UnitTestOktaCoreClient
    {
        readonly string _token = "00bPbh-EP6gcqj2bNTtSfeu_GOzamGh5aph4tJCkWl";
        readonly string _orgUrl = "https://dev-399435.oktapreview.com";

        /// <summary>
        /// Create a (random) Profile and attempt to set a custom attribute value (for attribute "CrmId").
        /// </summary>
        [TestMethod]
        public void CreateUserAndSetCustomAttributeTest()
        {
            var usersClient = new UsersClient(_token, new Uri(_orgUrl));

            var identifier = DateTime.Now.Ticks.ToString();
            var email = $"Test_{identifier}@test.com";
            var user = new User(email, email, $"OktaCoreClient_FN_{identifier}", $"OktaCoreClient_LN{identifier}");

            // Create the user
            user = usersClient.Add(user);

            //Test Retrieve
            var userData = usersClient.Get(email);

            userData.SetProperty("CrmId", identifier);
            userData = usersClient.Update(userData);

            Assert.IsNotNull(usersClient);
        }

        [TestMethod]
        public void RetrieveProfilesTest()
        {
            var usersClient = new UsersClient(_token, new Uri(_orgUrl));

            Uri nextPage = null;
            PagedResults<User> users;

            var foundUsers = false;
            do
            {
                users = usersClient.GetList(pageSize: 100, nextPage: nextPage);

                foundUsers = (users.Results.Count > 0) || foundUsers;

                foreach (var user in users.Results)
                {
                    // Do something with each user
                }
                nextPage = users.NextPage;
            }
            while (!users.IsLastPage);

            Assert.IsTrue(foundUsers);
        }


  
    }
}
