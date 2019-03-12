using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA.Service.Dto
{
    public class AppSettingsDto
    {
        #region Connection strings

        public string WAConnectionString { get; set; }
        public string WAEdmxConnectionString { get; set; }

        #endregion
    }
}
