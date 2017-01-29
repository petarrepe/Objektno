using System.Collections.Generic;
using KonobApp.Model.Models;

namespace Objektno.Models
{
    public class CaffeViewModel
    {
        public List<CaffeModel> openCaffe;

        internal CaffeViewModel()
        {
            var caffeRepository = DAL.Repositories.CaffeRepository.GetInstance();

            openCaffe = new List<CaffeModel>(caffeRepository.ListOpenCaffesWithFreeTables());
        }
    }
}