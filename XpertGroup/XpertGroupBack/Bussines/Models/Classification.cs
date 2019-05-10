using System.Runtime.Serialization;

namespace Bussines.Models
{
    [DataContract]
    public class Classification
    {
        [DataMember]
       public string Type { get; set; }
        [DataMember]
       public string Value { get; set; }
    }
}
