using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WM.SisControleMvc.Infra.Data.UoW
{
    public interface IUnitofWork
    {
        bool Commit();
    }
}
