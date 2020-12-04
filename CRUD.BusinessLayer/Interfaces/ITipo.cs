using System.Collections.Generic;
using CRUD.DataLayer.Entities;

namespace CRUD.BusinessLayer.Interfaces
{
    public interface ITipo
    {
        IEnumerable<TipoEmployee> TipoGet();
        string TipoInsert(TipoEmployee entity);
        string TipoUpdate(TipoEmployee entity);
        string TipoDelete(int id);
    }
}
