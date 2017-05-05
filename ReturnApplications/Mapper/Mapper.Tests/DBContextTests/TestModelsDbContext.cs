using System.Collections.Generic;
using System.Linq;
using MapperLibs.Models;
using MapperLibs.Models.DBContexts;
using NUnit.Framework;

namespace Mapper.Tests.DBContextTests
{
    [TestFixture]
    public class ModelsDbContext
    {
        const string MAP_NAME_HANAMURA = "Hanamura";
        const string MAP_NAME_KINGSROW = "King's Row";
        const string MAP_NAME_ILLIOS = "Illios";

        [Test]
        public Map maps_create_save_delete()
        {
            using (var db = new MapContext())
            {
                var hanamuraMap = CreateMap(1, MAP_NAME_HANAMURA, 1);

                db.Maps.Add(hanamuraMap);
                db.SaveChanges();

                var q = QuerySelectAllMaps(db);

                Assert.IsTrue(q.FirstOrDefault().Name.Equals(MAP_NAME_HANAMURA));

                return hanamuraMap;
            }
        }

        [Test]
        public void maps_delete()
        {
            using (var db = new MapContext())
            {
                var hanamuraMap = maps_create_save_delete();

                var otherMaps = new List<Map> {
                    CreateMap(2, MAP_NAME_KINGSROW, 2),
                    CreateMap(3, MAP_NAME_ILLIOS, 3)
                };

                db.Maps.AddRange(otherMaps);
                db.SaveChanges();

                var q = QuerySelectAllMaps(db);

                foreach (var map in q)
                {
                    Assert.IsTrue(otherMaps.Any(m => m.Name.Equals(map.Name)) || map.Name.Equals(MAP_NAME_HANAMURA));
                }

                db.Maps.Remove(hanamuraMap);
                db.SaveChanges();

                q = QuerySelectAllMaps(db);

                foreach (var map in q)
                {
                    Assert.IsTrue(otherMaps.Any(m => m.Name.Equals(map.Name)));
                }

                foreach (var map in q)
                {
                    Assert.IsFalse(map.Name.Equals(MAP_NAME_HANAMURA));
                }
            }
        }

        private static IOrderedQueryable<Map> QuerySelectAllMaps(MapContext db)
        {
            var q = from m in db.Maps
                    orderby m.Id
                    select m;
            return q;
        }

        private static Map CreateMap(int id, string name, int type)
        {
            return new Map()
            {
                Id = id,
                Name = name,
                Type = type
            };
        }
    }
}
