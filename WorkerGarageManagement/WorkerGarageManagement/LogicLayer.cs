using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerGarageManagement
{
    class LogicLayer
    {
        public HangXe[] GetBikes()
        {
            WorkerFileEntities db = new WorkerFileEntities();
            HangXe[] result = db.HangXes.ToArray();
            db.Dispose();
            return result;
        }
    }
}
