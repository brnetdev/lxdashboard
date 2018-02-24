using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LxDashboard.BE.Contracts
{
    [MessageContract]
    public class Message<T>
    {
        [MessageHeader]
        public string AuthSessionId { get; set; }

        [MessageBodyMember]
        public T MessageBody { get; set; }
    }
}
