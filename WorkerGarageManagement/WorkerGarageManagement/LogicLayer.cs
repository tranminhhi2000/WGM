using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerGarageManagement
{
    class LogicLayer
    {
        public HangXe[] GetManufactures()
        {
            WorkerFileEntities db = new WorkerFileEntities();
            HangXe[] result = db.HangXes.ToArray();
            db.Dispose();
            return result;
        }

        public Xe[] GetBikes()
        {
            WorkerFileEntities db = new WorkerFileEntities();
            Xe[] result = db.Xes.ToArray();
            db.Dispose();
            return result;
        }

        public XeDeleted[] GetDeletedBike()
        {
            WorkerFileEntities db = new WorkerFileEntities();
            return db.XeDeleteds.ToArray();
        }

        public ChuXe[] Owners()
        {
            WorkerFileEntities db = new WorkerFileEntities();
            ChuXe[] result = db.ChuXes.ToArray();
            db.Dispose();
            return result;
        }

        public void AddBike(string bienSo, string tenXe, int hangXe, DateTime guiXe)
        {
            WorkerFileEntities db = new WorkerFileEntities();
            Xe xe = new Xe();
            xe.License_Plates = bienSo;
            xe.Name = tenXe;
            xe.Manufacture = hangXe;
            xe.Time_Parking = guiXe;
            db.Xes.Add(xe);
            db.SaveChanges();
            db.Dispose();
        }

        public void AddOwners(string cMND, string hoVaTen, DateTime ngaySinh, string bienSoXe)
        {
            WorkerFileEntities db = new WorkerFileEntities();
            ChuXe chuxe = new ChuXe();
            chuxe.CMND = cMND;
            chuxe.Name = hoVaTen;
            chuxe.Birthday = ngaySinh;
            chuxe.License_Plates = bienSoXe;
            db.ChuXes.Add(chuxe);
            db.SaveChanges();
            db.Dispose();
        }

        public string GetManufacture(int id)
        {
            WorkerFileEntities db = new WorkerFileEntities();
            string data = db.HangXes.Where(item => item.ID.Equals(id)).Select(item => item.Name).FirstOrDefault();
            db.Dispose();
            return data;
        }
        public void AddBikes(string bienSo, string tenXe, int hangXe, DateTime guiXe)
        {
            WorkerFileEntities db = new WorkerFileEntities();
            XeDeleted xed = new XeDeleted();
            xed.License_Plates = bienSo;
            xed.Name = tenXe;
            xed.Manufacture = hangXe;
            xed.Time_Parking = guiXe;
            db.XeDeleteds.Add(xed);
            db.SaveChanges();
            db.Dispose();
        }
        public int ReManufacure(string id)
        {
            WorkerFileEntities db = new WorkerFileEntities();
            int data = db.HangXes.Where(item => item.Name.Equals(id)).Select(item => item.ID).FirstOrDefault();
            db.Dispose();
            return data;
        }
        public void thayDoi(string bienSo, string tenXe, int hangXe, DateTime guiXe)
        {
            WorkerFileEntities db = new WorkerFileEntities();
            var soXe = db.Xes.Find(bienSo);
            soXe.Name = tenXe;
            soXe.Manufacture = hangXe;
            soXe.Time_Parking = guiXe;
            db.SaveChanges();
            db.Dispose();
        }

        public Xe GetBike(string bienSO)
        {
            WorkerFileEntities db = new WorkerFileEntities();
            return db.Xes.Find(bienSO);
        }

    }
}