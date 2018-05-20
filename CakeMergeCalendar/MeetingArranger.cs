using System;
using System.Collections.Generic;
using System.Text;

namespace CakeMergeCalendar
{

    public class Meeting
    {
        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public Meeting(int startTime, int endTime)
        {
            // Number of 30 min blocks past 9:00 am
            StartTime = startTime;
            EndTime = endTime;
        }

        public override string ToString()
        {
            return $"({StartTime}, {EndTime})";
        }

        public Meeting Merge(Meeting other)
        {
            var startTime = Math.Min(StartTime, other.StartTime);
            var endTime = Math.Max(EndTime, other.EndTime);

            return new Meeting(startTime, EndTime);
        }

        public bool CanMerge(Meeting other)
        {
            return ((StartTime >= other.StartTime && StartTime <= other.EndTime) ||
                (StartTime <= other.StartTime && StartTime >= other.EndTime));
        }
    }
}
