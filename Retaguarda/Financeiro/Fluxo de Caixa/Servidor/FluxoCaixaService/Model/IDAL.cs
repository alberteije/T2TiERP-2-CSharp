using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluxoCaixaService.Model
{
    public interface IDAL<T>
    {
        int save<T>(T objeto);
        int saveOrUpdate<T>(T objeto);
        int update<T>(T objeto);
        int delete<T>(T objeto);
        T selectId<T>(int id);
        IList<T> select<T>(T objeto);
    }
}
