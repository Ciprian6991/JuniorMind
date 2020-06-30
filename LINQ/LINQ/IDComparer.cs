using System.Collections.Generic;

namespace LINQ
{
    internal class IDComparer : IEqualityComparer<Feature>
    {
        public bool Equals(Feature first, Feature second)
        {
            return first.Id == second.Id;
        }

        public int GetHashCode(Feature feature)
        {
            return feature.Id.ToString().GetHashCode();
        }
    }
}