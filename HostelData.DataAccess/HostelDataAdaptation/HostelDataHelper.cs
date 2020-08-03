using HostelData.Core.Data.Ado.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelData.DataAccess.HostelDataAdaptation
{
    public class HostelDataHelper : BaseConnectionHelper
    {
        public HostelDataHelper()
        {
            ConnectionString = "Data Source=DESKTOP-TEIOJN0\\MSSQLSERVER01; Initial Catalog=HostelDataDb; Integrated Security=true";
        }
    }
}
