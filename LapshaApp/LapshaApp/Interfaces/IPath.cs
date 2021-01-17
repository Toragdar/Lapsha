using System;
using System.Collections.Generic;
using System.Text;

namespace LapshaApp
{
    public interface IPath
    {
        string GetDatabasePath(string filename);
    }
}
