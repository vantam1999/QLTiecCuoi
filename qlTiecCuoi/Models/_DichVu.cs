using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qlTiecCuoi.Models
{
    public class _DichVu
    {
        List<DIchVu> listdichvu = new List<DIchVu>();
        public IEnumerable<DIchVu> dichvus
        {
            get { return listdichvu; }
        }
        public void add(DIchVu d)
        {
            var item = listdichvu.FirstOrDefault(s => s.IDDichVu == d.IDDichVu);
            if (item == null)
            {
                listdichvu.Add(d);
            }
        }
        public void delete(int id)
        {
            listdichvu.RemoveAll(m => m.IDDichVu == id);
        }
    }
}