using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalSynergy.DAL.Repositories
{
    public interface IDbFactory
    {
        TotalSynergyEntities Init();
    }
}
