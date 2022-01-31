using Microsoft.Xrm.Sdk;
using System;
using System.Linq;

namespace SelfContainedSolutionTest.Plugins.EarlyBound
{
    public interface IEarlyBoundContext
    {
        IQueryable<SolutionComponent> SolutionComponentSet { get; }
        IQueryable<Solution> SolutionSet { get; }

        IQueryable<msdyn_solutioncomponentsummary> msdyn_solutioncomponentsummarySet { get; }

        void AddSolutionComponent(Guid? componentId, OptionSetValue componentType, string solutionUniqueName);

        void RemoveSolutionComponent(Guid? componentId, OptionSetValue componentType, string solutionUniqueName);
    }
}