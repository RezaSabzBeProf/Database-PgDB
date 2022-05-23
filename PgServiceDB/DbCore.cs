using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgServiceDB
{
    public class DbCore
    {
        public string DbName { get; set; }
        public string DbAddress { get; set; }
        public List<Tabel> Tabels { get; set; } = new List<Tabel>();
        public bool IsChanged { get; set; } = false;
        DatabaseQuery _dbQuery;
        public DbCore()
        {
            
        }
        public void Create()
        {
            if (IsChanged)
            {
                DataBaseUpdate.Update(this);
            }
            _dbQuery = new DatabaseQuery();
            _dbQuery.db = this;
        }
        public void Add(Tabel tabel, List<string> data)
        {
            _dbQuery.Add(tabel, data);
        }
        public List<string[]> GetAll(Tabel tabel)
        {
            var model = _dbQuery.GetAll(tabel);
            return model;
        }
        public void Delete(Tabel tabel,string id)
        {
            _dbQuery.Delete(tabel, id);
        }
        public string[] GetOne(Tabel tabel,string id)
        {
            var model = _dbQuery.GetOne(tabel, id);
            return model;
        }
        public void Update(Tabel tabel, string id, List<string> data)
        {
            _dbQuery.Update(tabel, id, data);
        }
    }
}
