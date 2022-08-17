using System.Collections.Generic;
using UnityEngine.Analytics;

namespace Mobile2D
{
    internal class UnityAnalyticTools : IAnalyticTools
    {
        public void SendMessage(string nameEvent)
        {
            Analytics.CustomEvent(nameEvent);
        }

        public void SendMessage(string nameEvent, (string, object) data)
        {
            var eventData = new Dictionary<string, object>{ [data.Item1] = data.Item2 };
            Analytics.CustomEvent(nameEvent, eventData);
        }
    }
}