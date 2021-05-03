using System;
namespace Valorant.NET.Models.Exceptions
{
    public class LastPositionIndexLessThanStartingException : Exception
    {
        public LastPositionIndexLessThanStartingException(int startIndex, int lastindex)
            : base($"A starting index of {startIndex} is greater than the last index {lastindex}.")
        {
            StartIndex = startIndex;
            LastIndex = lastindex;
        }

        public int StartIndex { get; set; }

        public int LastIndex { get; set; }
    }
}
