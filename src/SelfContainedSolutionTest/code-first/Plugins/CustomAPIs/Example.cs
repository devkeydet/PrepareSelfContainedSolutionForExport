using Microsoft.Xrm.Sdk;
using SelfContainedSolutionTest.Plugins.Base;
using SelfContainedSolutionTest.Plugins.EarlyBound;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace SelfContainedSolutionTest.Plugins.CustomAPIs
{
    public class Example : PluginBase
    {
        [ExcludeFromCodeCoverage]
        public Example()
                : base(typeof(Example))
        {
            // TODO: Implement your custom configuration handling.
        }

        public Example(IEarlyBoundContext earlyBoundContext)
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

                var solutionComponents = EarlyBoundContext.SolutionComponentSet.Take(5);

                var entityCollection = new EntityCollection
                {
                    EntityName = SolutionComponent.EntityLogicalName
                };

                foreach (var item in solutionComponents)
                {
                    var entity = new Entity(SolutionComponent.EntityLogicalName);
                    entity["componenttype"] = item.ComponentType;
                    entity["solutioncomponentid"] = item.SolutionComponentId;
                    entity["objectid"] = item.ObjectId;
                    entity["solutionid"] = item.SolutionId;
                    entityCollection.Entities.Add(entity);
                }

                //TODO: Would prefer early bound code for dev productivity, but need to figure out why this is causing the following exception:
                //  System.Runtime.Serialization.SerializationException: Element 'http://schemas.microsoft.com/xrm/2011/Contracts:Entity' contains data from a type that maps to the name 'SelfContainedSolutionTest.Plugins.EarlyBound:SolutionComponent'.The deserializer has no knowledge of any type that maps to this name.Consider changing the implementation of the ResolveName method on your DataContractResolver to return a non - null value for name 'SolutionComponent' and namespace 'SelfContainedSolutionTest.Plugins.EarlyBound'
                //var query =
                //    from sc in EarlyBoundContext.SolutionComponentSet
                //    select new SolutionComponent
                //    {
                //        ObjectId = sc.ObjectId,
                //        SolutionComponentId = sc.SolutionComponentId,
                //        ComponentType = sc.ComponentType
                //    };
                //var entityCollection = new EntityCollection(query.ToList<Entity>());

                pluginContext.OutputParameters["Test"] = entityCollection;
            });
        }
    }
}