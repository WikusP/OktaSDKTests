using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okta.Sdk;
using Okta.Sdk.Configuration;

namespace UnitTestProject2
{
    /// <summary>
    /// This UnitTest is implemented using Okta.Sdk (PreRelease) 1.0.0-alpha4
    /// </summary>
    [TestClass]
    public class UnitTestOktaSdk
    {
        static string _token = "00bPbh-EP6gcqj2bNTtSfeu_GOzamGh5aph4tJCkWl";
        static string _orgUrl = "https://dev-399435.oktapreview.com";

        /// <summary>
        /// Create Profile with 'Nickname' and 'CrmId' (Custom Attribute) containing a value.
        /// Failure.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task CreateProfileWithNickNameAndCustomAttribute()
        {
            var client = new OktaClient(
                new OktaClientConfiguration
                {
                    OrgUrl = _orgUrl,
                    Token = _token
                });

            var identifier = DateTime.Now.Ticks.ToString();
            var email = $"Test_{identifier}@test.com";

            var user = await client.Users.CreateUserAsync(
                // User with password
                new CreateUserWithPasswordOptions
                {
                    // User profile object
                    Profile = new UserProfile
                    {
                        FirstName = $"OktaSdk_FN_{identifier}",
                        LastName = $"OktaSdk_LN_{identifier}",
                        Email = email,
                        Login = email,
                        ["nickName"] = $"OnCreate_{identifier}",
                        ["CrmId"] = $"{identifier}"
                    },
                    Password = "D1sturB1ng!",
                    Activate = false,
                });
        }

        /// <summary>
        /// Create Profile with 'Nickname' and 'CrmId' (Custom Attribute) containing a value.
        /// Update Profile.'Nickname' after create.
        /// Update Profile.'CrmId' after create.
        /// Failure.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task CreateProfileUpdateNickNameAndCustomAttribute()
        {
            var client = new OktaClient(
                new OktaClientConfiguration
                {
                    OrgUrl = _orgUrl,
                    Token = _token
                });

            var identifier = DateTime.Now.Ticks.ToString();
            var email = $"Test_{identifier}@test.com";

            var user = await client.Users.CreateUserAsync(
                // User with password
                new CreateUserWithPasswordOptions
                {
                    // User profile object
                    Profile = new UserProfile
                    {
                        FirstName = $"OktaSdk_FN_{identifier}",
                        LastName = $"OktaSdk_LN_{identifier}",
                        Email = email,
                        Login = email,
                        ["nickName"] = $"OnCreate_{identifier}",
                        ["CrmId"] = $"{identifier}"
                    },
                    Password = "D1sturB1ng!",
                    Activate = false,
                });

            user.Profile["nickName"] = $"OnUpdate_{identifier}";
            user.Profile["CrmId"] = $"CrmId_{identifier}";
            user = await user.UpdateAsync();
        }

        /// <summary>
        /// Create Profile with 'Nickname' containing a value.
        /// Successful.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task CreateProfileWithNickName()
        {
            var client = new OktaClient(
                new OktaClientConfiguration
                {
                    OrgUrl = _orgUrl,
                    Token = _token
                });


            var identifier = DateTime.Now.Ticks.ToString();
            var email = $"Test_{identifier}@test.com";

            var user = await client.Users.CreateUserAsync(
                // User with password
                new CreateUserWithPasswordOptions
                {
                    // User profile object
                    Profile = new UserProfile
                    {
                        FirstName = $"OktaSdk_FN_{identifier}",
                        LastName = $"OktaSdk_LN_{identifier}",
                        Email = email,
                        Login = email,
                        ["nickName"] = $"OnCreate_{identifier}"
                        //["CrmId"] = "13321"
                    },
                    Password = "D1sturB1ng!",
                    Activate = false,
                });
        }

        /// <summary>
        /// Create Profile with 'Nickname' containing a value.
        /// Update Profile.'Nickname' after create.
        /// Successful.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task CreateProfileUpdateNickName()
        {
            var client = new OktaClient(
                new OktaClientConfiguration
                {
                    OrgUrl = _orgUrl,
                    Token = _token
                });

            var identifier = DateTime.Now.Ticks.ToString();
            var email = $"Test_{identifier}@test.com";

            var user = await client.Users.CreateUserAsync(
                // User with password
                new CreateUserWithPasswordOptions
                {
                    // User profile object
                    Profile = new UserProfile
                    {
                        FirstName = $"OktaSdk_FN_{identifier}",
                        LastName = $"OktaSdk_LN_{identifier}",
                        Email = email,
                        Login = email,
                        ["nickName"] = $"OnCreate_{identifier}"
                        //["CrmId"] = "13321"
                    },
                    Password = "D1sturB1ng!",
                    Activate = false,
                });


            user.Profile["nickName"] = $"OnUpdate_{identifier}";
            user = await user.UpdateAsync();
        }

    }
}
