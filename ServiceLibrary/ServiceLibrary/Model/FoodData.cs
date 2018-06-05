using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace ServiceLibrary.Model
{
    [DataContract]
    public class FoodData
    {
        private string foodName;
        private string categoryName;

        [DataMember]
        public string FoodName { get => foodName; set => foodName = value; }
        [DataMember]
        public string CategoryName { get => categoryName; set => categoryName = value; }
    }   
}
