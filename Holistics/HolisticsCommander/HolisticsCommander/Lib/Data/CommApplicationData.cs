using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;

namespace HolisticsCommander.Lib.Data
{
    public partial class CommApplicationData : Properties.CommApplicationProperties
    {
        DataHelper _d;
        List<Business.CommApplication> _workingList;

        public CommApplicationData()
        {
            _d = new DataHelper();
            _d.XQuery += DataHelper_ExecuteQuery;
        }

        void DataHelper_ExecuteQuery(SqlCeDataReader Reader)
        {
            PopulateList(Reader, _workingList);
        }


        internal void InsertCommApp(Business.CommApplication item)
        {
            using (var cmd = new SqlCeCommand("INSERT INTO CommApps (Name, Path) VALUES (@Name, @Path)"))
            {
                cmd.Parameters.AddWithValue("@Name", System.Data.SqlDbType.NVarChar).Value = item.Name;
                cmd.Parameters.AddWithValue("@Path", System.Data.SqlDbType.NVarChar).Value = item.Path;
                item._recordExists = true;
                _d.ExecuteNonQuery(cmd);
            }
        }

        internal void UpdateCommApp(Business.CommApplication item)
        {
            using (var cmd = new SqlCeCommand("UPDATE CommApps SET Name = @Name, Path = @Path WHERE ID = @ID"))
            {
                cmd.Parameters.AddWithValue("@ID", System.Data.SqlDbType.Int).Value = item.ID;
                cmd.Parameters.AddWithValue("@Name", System.Data.SqlDbType.NVarChar).Value = item.Name;
                cmd.Parameters.AddWithValue("@Path", System.Data.SqlDbType.NVarChar).Value = item.Path;
                _d.ExecuteNonQuery(cmd);
            }
        }

        internal void LoadCommApps(List<Business.CommApplication> list)
        {
            using (var cmd = new SqlCeCommand("SELECT * FROM CommApps"))
            {
                _workingList = list;
                _d.ExecuteQuery(cmd);
            }
        }

        internal void DeleteItem(Business.CommApplication item)
        {
            using (var cmd = new SqlCeCommand("DELETE FROM CommApps WHERE ID = @ID"))
            {
                cmd.Parameters.AddWithValue("@ID", System.Data.SqlDbType.Int).Value = item.ID;
                _d.ExecuteNonQuery(cmd);
            }
        }

        private void PopulateList(SqlCeDataReader reader, List<Business.CommApplication> list)
        {
            while (reader.Read())
            {
                var cap = new Business.CommApplication();
                cap.ID = Convert.ToInt32(reader["ID"]);
                cap.Name = reader["Name"].ToString();
                cap.Path = reader["Path"].ToString();
                cap._recordExists = true;
                cap._hasChanged = false;
                list.Add(cap);
            }
        }

        internal void UpdateCommApp(List.CommApplicationList commApplicationList)
        {
            foreach (Business.CommApplication c in commApplicationList)
                if (c.RecordExists)
                    UpdateCommApp(c);
                else
                {
                    InsertCommApp(c);
                }
        }
    }
}
