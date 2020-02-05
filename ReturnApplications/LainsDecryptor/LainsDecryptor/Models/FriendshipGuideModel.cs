using System;
using System.Collections.Generic;

namespace LainsDecryptor.Models
{
    public class FriendshipGuideModel
    {
        public string Person { get; set; }
        public string Level { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
        public List<string> Instructions { get; set; } = new List<string>();
    }

    public class CompletedFriendshipGuideModel
    {
        public string Person { get; set; }
        public List<EventsGuide> Events { get; set; } = new List<EventsGuide>();

        public void AddGuide(FriendshipGuideModel guide)
        {
            var eventsGuide = new EventsGuide()
            {
                Level = guide.Level,
                Day = guide.Day,
                Time = guide.Time,
                Location = guide.Location,
                Instructions = guide.Instructions
            };

            Events.Add(eventsGuide);
        }
    }

    public class EventsGuide
    {
        public string Level { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
        public List<string> Instructions { get; set; } = new List<string>();
    }
}
