using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPermissions.Menu
{
    public interface IMenuReader
    {
        Task<Dictionary<int, string>> ParseMenuAsync(string filePath);
    }
}
