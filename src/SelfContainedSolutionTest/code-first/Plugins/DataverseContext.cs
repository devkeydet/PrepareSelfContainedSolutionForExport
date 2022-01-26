using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using SelfContainedSolutionTest.Plugins.Models;
using System;
using System.Linq;

namespace SelfContainedSolutionTest.Plugins
{
	internal class DataverseContext : Microsoft.Xrm.Sdk.Client.OrganizationServiceContext
	{
		public DataverseContext(IOrganizationService service) : base(service)
		{
		}

		public IQueryable<SolutionComponent> SolutionComponentSet
		{
			get
			{
				return this.CreateQuery<SolutionComponent>();
			}
		}

		public IQueryable<Solution> SolutionSet
		{
			get
			{
				return this.CreateQuery<Solution>();
			}
		}

		public void AddSolutionComponent(Guid? componentId, OptionSetValue componentType, string solutionUniqueName)
		{
			var request = new AddSolutionComponentRequest
			{
				AddRequiredComponents = true,
				ComponentId = (Guid)componentId,
				ComponentType = componentType.Value,
				SolutionUniqueName = solutionUniqueName
			};
			this.Execute(request);
		}

		public void RemoveSolutionComponent(Guid? componentId, OptionSetValue componentType, string solutionUniqueName)
		{
			var request = new RemoveSolutionComponentRequest
			{
				ComponentId = (Guid)componentId,
				ComponentType = componentType.Value,
				SolutionUniqueName = solutionUniqueName
			};
			this.Execute(request);
		}
	}
}
