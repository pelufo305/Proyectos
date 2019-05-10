
using System.Collections.Generic;
using System.Runtime.Serialization;
using XpertGroupBusiness.Models;

namespace XpertGroupBusiness.Models
{
    public class FlatFile
    {
        [DataMember]
        public List<Classification> Items { get; set; }
      
    }
}
