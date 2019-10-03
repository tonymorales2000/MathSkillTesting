using System;
using System.Collections.Generic;
using System.Text;

namespace RequestTracker
{
    public class RequestDurationTracker: IRequestTracker
    {
        private string IpAddress { get; set; }
        private DateTime TimeLastRequest { get; set; }
        private string PreviousMathProblem { get; set; }
        private int TwoMinutes => 2;
        private IDictionary<string, IDictionary<DateTime, string>> TrackerMap = new Dictionary<string, IDictionary<DateTime, string>>();

        public void AddToTracker(string ipAddress, string mathProblem)
        {
            var timeNow = DateTime.Now;
            IDictionary<DateTime, string> equationTimeMap = new Dictionary< DateTime, string> ();
            equationTimeMap.Add(timeNow, mathProblem);
            if(!TrackerMap.ContainsKey(ipAddress))
                TrackerMap.Add(ipAddress, equationTimeMap);
        }

        public string GetPreviousMathTest(string ipAddress)
        {
            string mathTest = "";
            if (TrackerMap.ContainsKey(ipAddress))
            {
                
                var keys = TrackerMap[ipAddress].Keys;
                foreach (var key in keys)
                {
                    mathTest = TrackerMap[ipAddress][key];
                }
            }
            return mathTest;
        }

        public bool IsRequestExpired(string ipAddress)
        {
            if (TrackerMap.ContainsKey(ipAddress))
            {
                var timeNow = DateTime.Now;
               var keys = TrackerMap[ipAddress].Keys;
                foreach(var key in keys)
                {

                    TimeSpan ts = timeNow - key;
                    if (ts.TotalMinutes > TwoMinutes)
                    {
                        TrackerMap.Remove(ipAddress);
                        return true;
                    }
                    return false;
                }
            }
            return true;
        }
    }
}
