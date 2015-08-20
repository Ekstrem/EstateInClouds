using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DomainLayer.BusinessProcess
{
    public interface IBusinessProceessRole
    {
        int ProcentCoustForService { get; set; }
        int MoneyCostForService { get; set; }
    }
}
