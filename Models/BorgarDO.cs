using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Models
{
    public class BorgarDO
    {
        [PrimaryKey, AutoIncrement]
        public int ODBorgarID { get; set; }
        public string NombreOD { get; set; }
        public string DescripcionOD { get; set; }
        public string ConQueso { get; set; }
        public DateTime Fecha { get; set; }
        [Ignore]
        public string BorgarplusDesc => $"{NombreOD}: {DescripcionOD}";
    }
}
