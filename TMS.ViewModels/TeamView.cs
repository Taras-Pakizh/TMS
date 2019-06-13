using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.ViewModels
{
    public class TeamView:IViewBase
    {
        public int Id { get; set; }

        //[DataMember]
        public ICollection<int> engineerIds { get; set; }

        //[DataMember]
        public int teamleadId { get; set; }
        
        public string name { get; set; }

        public int GetId()
        {
            return Id;
        }
    }
}
