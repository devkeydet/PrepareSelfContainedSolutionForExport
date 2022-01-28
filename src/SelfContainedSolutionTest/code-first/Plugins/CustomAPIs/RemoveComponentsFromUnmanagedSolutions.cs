using Microsoft.Xrm.Sdk;
using System;
using System.Linq;

namespace SelfContainedSolutionTest.Plugins.CustomAPIs
{

    public class RemoveComponentsFromUnmanagedSolutions : PluginBase
    {
        public RemoveComponentsFromUnmanagedSolutions()
                : base(typeof(RemoveComponentsFromUnmanagedSolutions))
        {
            // TODO: Implement your custom configuration handling.
        }        

        protected override void ExecuteDataversePlugin(ILocalPluginContext localContext)
        {
            if (localContext == null)
            {
                throw new InvalidPluginExecutionException(nameof(localContext));
            }
            // Obtain the tracing service
            ITracingService tracingService = localContext.TracingService;

            try
            {
                // Obtain the execution context from the service provider.  
                IPluginExecutionContext pluginContext = (IPluginExecutionContext)localContext.PluginExecutionContext;

                // Obtain the organization service reference for web service calls.  
                IOrganizationService currentUserService = localContext.CurrentUserService;

                var EarlyBoundContext = _earlyBoundContext ?? new EarlyBoundContext(currentUserService);

                var solutionComponents = EarlyBoundContext.SolutionComponentSet.Take(5);

                var entityCollection = new EntityCollection
                {
                    EntityName = "solutioncomponent"
                };

                foreach (var item in solutionComponents)
                {
                    var entity = new Entity("solutioncomponent");
                    entity["componenttype"] = item.ComponentType;
                    entity["solutioncomponentid"] = item.SolutionComponentId;
                    entity["objectid"] = item.ObjectId;
                    entityCollection.Entities.Add(entity);
                }

                pluginContext.OutputParameters["Test"] = entityCollection;
            }
            // Only throw an InvalidPluginExecutionException. Please Refer https://go.microsoft.com/fwlink/?linkid=2153829.
            catch (Exception ex)
            {
                tracingService?.Trace("An error occurred executing Plugin SelfContainedSolutionRemoveComponentsFromUnmanagedSolutions.Plugins.RemoveComponentsFromUnmanagedSolutions : {0}", ex.ToString());
                throw new InvalidPluginExecutionException("An error occurred executing Plugin SelfContainedSolutionRemoveComponentsFromUnmanagedSolutions.Plugins.RemoveComponentsFromUnmanagedSolutions .", ex);
            }
        }
    }
}