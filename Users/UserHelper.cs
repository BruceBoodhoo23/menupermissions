using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPermissions.Users
{
    static class UserHelper
    {
        public static UserModel ParseUser(string userLine)
        {
            var splitStr = userLine.Split(' ', 2);

            return new UserModel
            {
                UserName = splitStr[0],
                Permissions = splitStr[1].Replace(" ", "")
            };
        }
    }
}
