using LainsDecryptor.Extensions;
using LainsDecryptor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LainsDecryptor.Services
{
    public class DecryptingService
    {
        ICollection<string> IgnoreList = Configs.IgnoreList;
        ICollection<FriendshipGuideModel> Guides = new List<FriendshipGuideModel>();
        public List<CompletedFriendshipGuideModel> CompletedGuides = new List<CompletedFriendshipGuideModel>();

        public List<HashHeadings> GetHashHeadings(string filePath)
        {
            var hashHeadings = new List<HashHeadings>();

            using (var sr = new StreamReader(filePath))
            {
                while (sr.Peek() != -1)
                {
                    var line = sr.ReadLine();

                    if (!IgnoreList.Contains(line))
                    {
                        var hashHeading = DecryptLine(line);

                        if (hashHeading != null)
                            hashHeadings.Add(hashHeading);
                    }
                }
            }



            return hashHeadings;
        }

        public void FriendshipGuides(string filePath)
        {
            using (var sr = new StreamReader(filePath))
            {
                var guide = new FriendshipGuideModel();
                var person = string.Empty;
                var level = string.Empty;
                var reading = false;
                var firstBreak = false;
                var previousLine = string.Empty;
                var guideCreated = false;
                var lineCount = 0;

                while (sr.Peek() != -1)
                {
                    var line = sr.ReadLine();

                    if (!IgnoreList.Contains(line))
                    {
                        if (line.Contains("<br>") && previousLine.Contains("<br>"))
                        {
                            reading = false;
                        }

                        if (reading)
                        {
                            if (!line.IsNullOrEmpty())
                            {
                                if (!line.StartsWith("-") && !line.StartsWith("#") && firstBreak && guideCreated == false)
                                {
                                    var headings = line.Split('|');

                                    guide = new FriendshipGuideModel()
                                    {
                                        Person = person,
                                        Level = level,
                                        Day = headings[0].Trim(),
                                        Time = headings[1].Trim(),
                                        Location = headings[2].Trim()
                                    };

                                    guideCreated = true;
                                }

                                if (line.StartsWith("### Level "))
                                    level = line.Substring(10, line.Length - 10);

                                if (line.StartsWith("### * NEW!"))
                                    level = line.Substring(19, line.Length - 19);

                                if (guideCreated && line.StartsWith("-"))
                                    guide.Instructions.Add(line);

                                if (line.Contains("<br>") && firstBreak)
                                {
                                    Guides.Add(guide);
                                    guide = new FriendshipGuideModel();
                                    level = null;
                                    guideCreated = false;
                                }

                                if (line.Contains("<br>") && firstBreak == false)
                                    firstBreak = true;


                            }
                        }

                        if (line.Contains("Friendship Guide"))
                        {
                            reading = true;
                            firstBreak = false;
                            person = line.Substring(2, line.IndexOf(" Fr") - 2);
                        }

                        previousLine = line.ToString();
                    }

                    if (line.Contains("# Side Characters"))
                        break;

                    lineCount++;
                }
            }

            FinalizeFriendshipGuide();
        }

        private void FinalizeFriendshipGuide()
        {
            foreach (var guide in Guides)
            {
                if (!CompletedGuides.Exists(x => x.Person.Equals(guide.Person)))
                {
                    CompletedGuides.Add(new CompletedFriendshipGuideModel()
                    {
                        Person = guide.Person,
                        PersonSystemName = GetPersonSystemName(guide.Person)
                    });
                }

                CompletedGuides.Find(x => x.Person.Equals(guide.Person)).AddGuide(guide);
            }
        }

        private string GetPersonSystemName(string person)
        {
            if (!person.Contains("&"))
                return person.Trim();
            else
            {
                return person.Replace("&", "And").Replace(" ", "");
            }
        }

        private HashHeadings DecryptLine(string line)
        {
            if (line.StartsWith("#"))
            {
                return new HashHeadings()
                {
                    HashType = line.Substring(0, line.LastIndexOf("#") + 1),
                    Heading = line.Substring(line.LastIndexOf("#") + 1, line.Length - line.LastIndexOf("#") - 1).Trim()
                };
            }

            return null;
        }
    }
}
