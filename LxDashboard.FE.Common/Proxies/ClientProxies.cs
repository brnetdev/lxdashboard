

/*
This code is generated. Do not change here any code, it will by overwirtten. 

*/

using System.ServiceModel;
using LxDashboard.BE.Contracts;
using LxDashboard.BE.Contracts.Services;

namespace LxDashboard.FE.Common.Proxies 
{
	
	
	public partial class AuthServiceProxy : ClientBase<IAuthService>, IAuthService
	{
		
			public AuthServiceProxy() : base("AuthService") {}
		
				
			public System.String Authenticate(System.String login, System.String password)
			{	
				return Channel.Authenticate(login, password);
			}	
				
			public void Logout(System.String authSessionId)
			{	
				Channel.Logout(authSessionId);
			}	
				
			public void AddUser(System.String login, System.String password)
			{	
				Channel.AddUser(login, password);
			}	
				
			public System.String IsAuthenticated(System.String authSessionId)
			{	
				return Channel.IsAuthenticated(authSessionId);
			}	
				
	}
	
	public partial class SprintServiceProxy : ClientBase<ISprintService>, ISprintService
	{
		
			public SprintServiceProxy() : base("SprintServiceConfig") {}
		
				
			public void Add(LxDashboard.BE.Contracts.Data.Sprint sprint)
			{	
				Channel.Add(sprint);
			}	
				
	}
	
	
}

