using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using System;
using System.Linq;

namespace SelfContainedSolutionTest.Plugins.EarlyBound
{
    public partial class EarlyBoundContext
        : Microsoft.Xrm.Sdk.Client.OrganizationServiceContext, IEarlyBoundContext
    {
        public EarlyBoundContext(IOrganizationService service) : base(service)
        {
        }

        public IQueryable<SolutionComponent> SolutionComponentSet => CreateQuery<SolutionComponent>();

        public IQueryable<Solution> SolutionSet => CreateQuery<Solution>();

        public IQueryable<msdyn_solutioncomponentsummary> msdyn_solutioncomponentsummarySet => CreateQuery<msdyn_solutioncomponentsummary>();

        public void AddSolutionComponent(Guid? componentId, OptionSetValue componentType, string solutionUniqueName)
        {
            var request = new AddSolutionComponentRequest
            {
                AddRequiredComponents = true,
                ComponentId = (Guid)componentId,
                ComponentType = componentType.Value,
                SolutionUniqueName = solutionUniqueName
            };
            Execute(request);
        }

        public void RemoveSolutionComponent(Guid? componentId, OptionSetValue componentType, string solutionUniqueName)
        {
            var request = new RemoveSolutionComponentRequest
            {
                ComponentId = (Guid)componentId,
                ComponentType = componentType.Value,
                SolutionUniqueName = solutionUniqueName
            };
            Execute(request);
        }
    }
}