using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContratosService.Model
{
    public interface IDAL<T>
    {
        T save<T>(T objeto);
        T saveOrUpdate<T>(T objeto);
        T update<T>(T objeto);
        int delete<T>(T objeto);
        T selectId<T>(int id);
        IList<T> select<T>(T objeto);
        IList<T> selectPagina<T>(int primeiroResultado, int quantidadeResultados, T objeto);
    }
}
