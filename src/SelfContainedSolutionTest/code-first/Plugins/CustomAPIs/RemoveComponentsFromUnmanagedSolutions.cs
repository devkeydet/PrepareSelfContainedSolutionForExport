using Microsoft.Xrm.Sdk;
using SelfContainedSolutionTest.Plugins.Base;
using SelfContainedSolutionTest.Plugins.EarlyBound;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace SelfContainedSolutionTest.Plugins.CustomAPIs
{
    public class RemoveComponentsFromUnmanagedSolutions : PluginBase
    {
        [ExcludeFromCodeCoverage]
        public RemoveComponentsFromUnmanagedSolutions()
                : base(typeof(RemoveComponentsFromUnmanagedSolutions))
        {
            // TODO: Implement your custom configuration handling.
        }

        public RemoveComponentsFromUnmanagedSolutions(IEarlyBoundContext earlyBoundContext)
                : base(typeof(AddAllRequiredSolutionComponents), earlyBoundContext)
        {
            // TODO: Implement your custom configuration handling.
        }

        protected override void Execute(ILocalPluginContext localContext)
        {
            Execute(() =>
            {
                // Obtain the execution context from the service provider.
                var pluginContext = localContext.PluginExecutionContext;

                var entityCollection = (EntityCollection)pluginContext.InputParameters["SolutionComponents"];

                var solutionComponents = (
                    from entity in entityCollection.Entities
                    select entity.ToEntity<SolutionComponent>()
                ).ToList();

                var solutionComponentsGroupedBySolution = solutionComponents.GroupBy(sc => sc.SolutionId);

                foreach (var grouping in solutionComponentsGroupedBySolution)
                {
                    var solutionId = grouping.First().SolutionId.Id;

                    var solutionUniqueName = EarlyBoundContext.SolutionSet.Where(s => s.Id == solutionId).First().UniqueName;
                    foreach (var sc in grouping)
                    {
                        EarlyBoundContext.RemoveSolutionComponent(sc.ObjectId, sc.ComponentType, solutionUniqueName);
                    }
                }
            });
        }
    }
}