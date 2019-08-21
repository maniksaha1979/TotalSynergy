using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalSynergy.UI.BO
{
    public class ProjectContactVM
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid ContactId { get; set; }
        public string ProjectName { get; set; }
        public string ContactName { get; set; }
    }
}
