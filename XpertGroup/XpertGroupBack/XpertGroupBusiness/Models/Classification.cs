using System.Runtime.Serialization;

namespace XpertGroupBusiness.Models
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
