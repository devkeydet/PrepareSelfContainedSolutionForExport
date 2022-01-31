using SelfContainedSolutionTest.Plugins.Base;
using SelfContainedSolutionTest.Plugins.EarlyBound;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace SelfContainedSolutionTest.Plugins.CustomAPIs
{
    public class GetSolutionComponentName : PluginBase
    {
        [ExcludeFromCodeCoverage]
        public GetSolutionComponentName()
                : base(typeof(Example))
        {
            // TODO: Implement your custom configuration handling.
        }

        public GetSolutionComponentName(IEarlyBoundContext earlyBoundContext)
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
                var objectId = (string)pluginContext.InputParameters["ObjectId"];

                var solutionComponentName = EarlyBoundContext.msdyn_solutioncomponentsummarySet.Where(s => s.msdyn_objectid == objectId).First().msdyn_displayname;

                pluginContext.OutputParameters["DisplayName"] = solutionComponentName;
            });
        }
    }
}