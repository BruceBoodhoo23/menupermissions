using MenuPermissions.Interfaces;
using MenuPermissions.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPermissions.Commands
{
    public class UserMapperCommand : ICommand
    {
        private readonly IUserMapper _userMapper;
        private readonly string _userFilePath;
        private readonly Dictionary<int, string> _menus;
        private IAsyncEnumerable<UserResultModel> _userResults;

        public UserMapperCommand(IUserMapper userMapper, string userFilePath, Dictionary<int, string> menus)
        {
            _userMapper = userMapper ?? throw new ArgumentNullException(nameof(userMapper));
            _userFilePath = userFilePath ?? throw new ArgumentNullException(nameof(userFilePath));
            _menus = menus ?? throw new ArgumentNullException(nameof(menus));
        }

        public IAsyncEnumerable<UserResultModel> GetUserResults() => _userResults;

        public async Task ExecuteAsync()
        {
            await foreach (var userResult in _userMapper.MapPermissionsToMenusAsync(_userFilePath, _menus))
            {                
                _userResults = _userMapper.MapPermissionsToMenusAsync(_userFilePath, _menus);
            }
        }

        //public async Task ExecuteAsync()
        //{
        //    _userResults = await _userMapper.MapPermissionsToMenusAsync(_userFilePath, _menus);
        //}
    }

}
