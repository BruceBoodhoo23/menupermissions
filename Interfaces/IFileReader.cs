using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPermissions.Interfaces
{
    internal interface IFileReader
    {
        Task<Dictionary<int, string>> ReadAllLinesAsync(string filePath);
    }
}
