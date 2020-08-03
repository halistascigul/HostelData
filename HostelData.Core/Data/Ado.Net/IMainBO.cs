using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelData.Core.Data.Ado.Net
{
    public interface IMainBO<T>
    {
        T GetById(int id);
        List<T> GetList();
        bool Insert(T model);
        bool Delete(int id);
        bool Update(T model);
    }
}
