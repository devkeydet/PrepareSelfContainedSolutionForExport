using Microsoft.Xrm.Sdk;
using SelfContainedSolutionTest.Plugins.Models;
using System;
using System.Linq;

namespace SelfContainedSolutionTest.Plugins
{
    public interface IEarlyBoundContext
    {
        IQueryable<SolutionComponent> SolutionComponentSet { get; }
        IQueryable<Solution> SolutionSet { get; }

        void AddSolutionComponent(Guid? componentId, OptionSetValue componentType, string solutionUniqueName);
        void RemoveSolutionComponent(Guid? componentId, OptionSetValue componentType, string solutionUniqueName);
    }
}