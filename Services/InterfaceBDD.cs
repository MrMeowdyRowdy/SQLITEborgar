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
        Task<int> AddBorgarDO(BorgarDO borgarModel);
        Task<int> DeleteBorgarDO(BorgarDO borgarModel);
        Task<int> UpdateBorgarDO(BorgarDO borgarModel);
    }
}
