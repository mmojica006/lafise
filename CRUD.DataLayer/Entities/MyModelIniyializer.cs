using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DataLayer.Entities
{
    /// <summary>
    /// Initializer Database 
    /// </summary>
    public class MyModelIniyializer: DropCreateDatabaseAlways<MyModel>
    {
        protected override void Seed(MyModel context)
        {
            IList<TipoEmployee> defaultStandards = new List<TipoEmployee>();

            defaultStandards.Add(new TipoEmployee() { Descripcion = "Natural" });
            defaultStandards.Add(new TipoEmployee() { Descripcion = "Jurídico" });

            context.TipoEmployee.AddRange(defaultStandards);

            base.Seed(context);
        }
    }
}
