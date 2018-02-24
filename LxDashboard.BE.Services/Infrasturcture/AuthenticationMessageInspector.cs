using LxDashboard.BE.Contracts.Faults;
using LxDashboard.BE.Contracts.Services;
using LxDashboard.BE.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Threading;
using System.Web;

namespace LxDashboard.BE.Services.Infrasturcture
{
    public class AuthenticationMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            var messageBuff = request.CreateBufferedCopy(int.MaxValue);
            var message = messageBuff.CreateMessage();
            var authSessionIdHeader = nameof(LxDashboard.BE.Contracts.Message<object>.AuthSessionId);
            if (message.Headers.FindHeader(authSessionIdHeader, "") == -1)
            {
                throw new FaultException("Invalid message format");
            }

            var authSessId = message.Headers.GetHeader<string>("AuthSessionId", "");

            // Strzal do authservice
            string ident = "";
            using (var factory = new ChannelFactory<IAuthService>("AuthServiceClient"))
            {
                var proxy = factory.CreateChannel();
                ident = proxy.IsAuthenticated(authSessId);
            }
            if (string.IsNullOrEmpty(ident))
            {
                throw new FaultException<NotAuthenticatedFault>(new NotAuthenticatedFault());
            }

            var identity = new GenericIdentity(ident);            

            var principal = new GenericPrincipal(identity, new string[1] { "User" });
            Thread.CurrentPrincipal = principal;

            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            throw new NotImplementedException();
        }
    }
}