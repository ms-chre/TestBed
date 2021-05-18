using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConsoleApp.FinalData
{
    public class DataItemComparator : IEqualityComparer<ParsedData>
    {
        public bool Equals([AllowNull] ParsedData x, [AllowNull] ParsedData y)
        {
            return x.Name.Equals(y.Name);
        }

        public int GetHashCode([DisallowNull] ParsedData obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
