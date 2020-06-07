using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qlTiecCuoi.Models
{
    public class _MonAn
    {
        List<MonAn> listmonan = new List<MonAn>();
        public IEnumerable<MonAn> monans
        {
            get { return listmonan; }
        }
        public void add(MonAn m)
        {
            var item = listmonan.FirstOrDefault(s => s.IDMonAn == m.IDMonAn);
            if (item == null)
            {
                listmonan.Add(m);
            }
        }
        public void delete(int id)
        {
            listmonan.RemoveAll(m => m.IDMonAn == id);
        }
    }
}