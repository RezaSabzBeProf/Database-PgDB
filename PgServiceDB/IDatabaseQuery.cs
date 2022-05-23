using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgServiceDB
{
    public interface IDatabaseQuery
    {
        void Add(Tabel tabel, List<string> data);

        List<string[]> GetAll(Tabel tabel);

        void Delete(Tabel tabel, string id);

        string[] GetOne(Tabel tabel, string id);

        void Update(Tabel tabel, string id, List<string> data);
    }
}
