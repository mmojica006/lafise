using CRUD.BusinessLayer.Interfaces;
using CRUD.DataLayer.Entities;
using CRUD.DataLayer.Implementation;
using System.Collections.Generic;
using System.Linq;

namespace CRUD.BusinessLayer.Implementation
{
    public class Tipo : ITipo
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        private List<TipoEmployee> lstAdd = new List<TipoEmployee>();
        private TipoEmployee objAdd = new TipoEmployee();

        public string TipoDelete(int id)
        {
            var objAdd = this.unitOfWork.GeTipoRepository.GetByID(id);
            this.unitOfWork.GeTipoRepository.Delete(objAdd);
            int deleteData = this.unitOfWork.Save();
            if (deleteData > 0)
            {
                return "Successfully deleted of Address records";
            }
            else
            {
                return "Deletion faild";
            }
        }

        public IEnumerable<TipoEmployee> TipoGet()
        {
            lstAdd = unitOfWork.GeTipoRepository.Get().ToList();

            return lstAdd;
        }

        public string TipoInsert(TipoEmployee entity)
        {
            this.unitOfWork.GeTipoRepository.Insert(entity);
            int inserData = this.unitOfWork.Save();

            if (inserData > 0)
            {
                return "Successfully Inserted of address records";
            }
            else
            {
                return "Insertion faild";
            }
        }

        public string TipoUpdate(TipoEmployee entity)
        {
            objAdd = unitOfWork.GeTipoRepository.GetByID(entity.TipoEmployeeId);

            if (objAdd != null)
            {
                objAdd.Descripcion = entity.Descripcion;

            }
            this.unitOfWork.GeTipoRepository.Attach(objAdd);
            int result = this.unitOfWork.Save();

            if (result > 0)
            {
                return "Sucessfully updated of tipo records";
            }
            else
            {
                return "Updation faild";
            }
        }
    }
}
