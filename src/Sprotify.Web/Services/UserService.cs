using System;
using System.Threading.Tasks;
using Sprotify.Web.Models;
using Sprotify.Web.Services.Core;

namespace Sprotify.Web.Services
{
    public class UserService : ApiServiceBase
    {
        public UserService(SprotifyHttpClient sprotifyclient) : base(sprotifyclient)
        {
        }

        public async Task EnsureUserExists(Guid userId, string name)
        {
            try
            {
                await Get<User>($"users/{userId}").ConfigureAwait(false);
            }
            catch (ResourceNotFoundException)
            {
                await Post<User>("users", new {id = userId, name = name}).ConfigureAwait(false);
            }
        }
    }
}