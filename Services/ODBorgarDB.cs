using SQLite;
using SQLiteDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Services
{
    public class ODBorgarDB : InterfaceBDD
    {
        private SQLiteAsyncConnection conn;

        private async Task ReadySteadyGO()
        {
            if (conn == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "borgar.db3");
                conn = new SQLiteAsyncConnection(dbPath);
                await conn.CreateTableAsync<BorgarDO>();
            }
        }

        public async Task<int> AddBorgarDO(BorgarDO borgarDO)
        {
            await ReadySteadyGO();
            return await conn.InsertAsync(borgarDO);
        }

        public async Task<int> DeleteBorgarDO(BorgarDO borgarDO)
        {
            await ReadySteadyGO();
            return await conn.DeleteAsync(borgarDO);
        }

        public async Task<List<BorgarDO>> GetBorgarListDO()
        {
            await ReadySteadyGO();
            var borgarList = await conn.Table<BorgarDO>().ToListAsync();
            return borgarList;
        }

        public async Task<int> UpdateBorgarDO(BorgarDO borgarDO)
        {
            await ReadySteadyGO();
            return await conn.UpdateAsync(borgarDO);
        }
    }
}
