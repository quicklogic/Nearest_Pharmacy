using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nearest_Pharmacy
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}
