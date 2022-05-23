using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgServiceDB
{
    public class DatabaseQuery : IDatabaseQuery
    {
        public DbCore db { get; set; }
        public DatabaseQuery()
        {

        }
        public void Add(Tabel tabel, List<string> data)
        {
            string dbPath = Path.Combine(db.DbAddress, db.DbName);
            string tabelPath = Path.Combine(dbPath, tabel.Name);
            int count = 0;
            string IdGenerate = RandomStringGenerateor.GenerateUniqCode();
            foreach (var item in tabel.Columns)
            {
                string file = Path.Combine(tabelPath, item.Name, IdGenerate);
                File.WriteAllText(file, data[count]);
                count++;
            }
        }

        public void Delete(Tabel tabel, string id)
        {
            string dbPath = Path.Combine(db.DbAddress, db.DbName, tabel.Name);

            foreach (var item in tabel.Columns)
            {
                File.Delete(Path.Combine(dbPath, item.Name, id));
            }
        }

        public List<string[]> GetAll(Tabel tabel)
        {
            string dbPath = Path.Combine(db.DbAddress, db.DbName, tabel.Name);
            string[] type = new string[tabel.Columns.Count + 1];
            int x = tabel.Columns.Count;
            List<string[]> Data = new List<string[]>();

            DirectoryInfo d = new DirectoryInfo(Path.Combine(dbPath, tabel.Columns[0].Name));
            FileInfo[] Files = d.GetFiles();
            foreach (FileInfo file in Files)
            {
                string fullName = file.Name;
                string[] littleData = new string[tabel.Columns.Count + 1];
                littleData[0] = fullName;
                int count = 1;
                foreach (var item in tabel.Columns)
                {
                    littleData[count] = File.ReadAllText(Path.Combine(dbPath, item.Name, fullName));
                    count++;
                }
                Data.Add(littleData);
            }
            return Data;
        }

        public string[] GetOne(Tabel tabel, string id)
        {
            string dbPath = Path.Combine(db.DbAddress, db.DbName, tabel.Name);
            string[] Data = new string[tabel.Columns.Count + 1];
            int count = 1;
            Data[0] = id;
            foreach (var item in tabel.Columns)
            {
                string text = File.ReadAllText(Path.Combine(dbPath, item.Name, id));
                Data[count] = text;
                count++;
            }
            return Data;
        }

        public void Update(Tabel tabel, string id, List<string> data)
        {
            string dbPath = Path.Combine(db.DbAddress, db.DbName);
            string tabelPath = Path.Combine(dbPath, tabel.Name);
            int count = 0;
            foreach (var item in tabel.Columns)
            {
                string file = Path.Combine(tabelPath, item.Name, id);
                File.WriteAllText(file, data[count]);
                count++;
            }
        }
    }
}
