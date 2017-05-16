using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapper.Models;
using NUnit.Framework;

namespace MapperTests
{
    [TestFixture]
    public class DBContextTests
    {
        private const string HANAMURA = "Hanamura";

        [Test]
        public void add_save()
        {
            using (var db = new Mapper.Models.DBContexts.MapContext())
            {
                db.Maps.Add(
                    new Map()
                    {
                        Id = 1,
                        Name = HANAMURA,
                        Type = 2
                    });

                db.SaveChanges();

                var hanamuraMap = (from m 
                                  in db.Maps
                                  orderby m.Id
                                  select m).Take(1).FirstOrDefault();

                Assert.AreEqual(HANAMURA, hanamuraMap.Name);
            }
        }
    }
}
