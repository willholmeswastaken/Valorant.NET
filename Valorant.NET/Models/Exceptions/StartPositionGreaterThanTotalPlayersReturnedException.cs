using System;
namespace Valorant.NET.Models.Exceptions
{
    public class StartPositionGreaterThanTotalPlayersReturnedException : Exception
    {
        public StartPositionGreaterThanTotalPlayersReturnedException(int startIndex, int totalPlayersReturned)
            : base($"A starting index of {startIndex} is greater than the total players returned {totalPlayersReturned}.")
        {
            StartIndex = startIndex;
            TotalPlayersReturned = totalPlayersReturned;
        }

        public int StartIndex { get; set; }

        public int TotalPlayersReturned { get; set; }
    }
}
