using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPermissions.Users
{
    public interface IUserMapper
    {
        IAsyncEnumerable<UserResultModel> MapPermissionsToMenusAsync(string userFile, Dictionary<int, string> menus);
    }

}
