
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Bussines.Models
{
    public class FlatFile
    {
        [DataMember]
        public List<Classification> Items { get; set; }
      
    }
}
