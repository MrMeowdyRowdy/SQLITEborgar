using SQLiteDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Services
{
    public interface InterfaceBDD
    {
        Task<List<BorgarDO>> GetBorgarListDO();
        Task<int> AddBorgarDO(BorgarDO studentModel);
        Task<int> DeleteBorgarDO(BorgarDO studentModel);
        Task<int> UpdateBorgarDO(BorgarDO studentModel);
    }
}
