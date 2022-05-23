using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PgServiceDB
{
    public class DataBaseUpdate
    {
        public static void Update(DbCore core)
        {
            string dbPath = Path.Combine(core.DbAddress, core.DbName);
            foreach(var item in core.Tabels)
            {
                string tabelPath = Path.Combine(dbPath, item.Name);
                Directory.CreateDirectory(tabelPath);
                foreach(var cal in item.Columns)
                {
                    Directory.CreateDirectory(Path.Combine(tabelPath, cal.Name));
                }
            }
        }
    }
}
