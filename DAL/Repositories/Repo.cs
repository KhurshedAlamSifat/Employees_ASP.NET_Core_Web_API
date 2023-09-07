using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class Repo
    {
        internal EmployeeContext db;
        internal Repo()
        {
            db = new EmployeeContext();
        }
    }
}
