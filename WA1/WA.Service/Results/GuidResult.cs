using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.Service.Models;

namespace WA.Service.Results
{
    public class GuidResult
    {
        public CredentialModel CredentialModel { get; set; }
        public IList<ValidationResult> ValidationResults { get; set; }
    }
}
