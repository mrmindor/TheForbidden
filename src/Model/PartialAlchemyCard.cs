using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class AlchemyCard
    {
        public ICollection<AlchemyCost> Costs { get { return AlchemyCosts.OrderBy(c => c.Order).ToList(); } }
    }
}
