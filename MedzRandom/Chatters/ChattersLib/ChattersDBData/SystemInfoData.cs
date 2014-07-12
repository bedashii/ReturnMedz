using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using ChattersLib.ChattersDBProperties;

namespace ChattersLib.ChattersDBData
{
    public class SystemInfoData : SystemInfoProperties
    {
        internal DataHelper dataHelper = new DataHelper();

        internal void LoadItemData(int id)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM SystemInfo WHERE ID = @ID";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@ID", OleDbType.Integer).Value = id;

            DataTable dt = dataHelper.ExecuteReader(cmd);

            if (dt.Rows.Count > 0)
            {
                ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                SIKey = dt.Rows[0]["SIKey"].ToString();
                SIValue = dt.Rows[0]["SIValue"].ToString();

                RecordsExists = true;
                AnyPropertyChanged = false;
            }
            else
                RecordsExists = false;
        }

        internal void LoadItemData(string key)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM SystemInfo WHERE SIKey = @Key";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@Key", OleDbType.VarChar).Value = key;

            DataTable dt = dataHelper.ExecuteReader(cmd);

            if (dt.Rows.Count > 0)
            {
                ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                SIKey = dt.Rows[0]["SIKey"].ToString();
                SIValue = dt.Rows[0]["SIValue"].ToString();

                RecordsExists = true;
                AnyPropertyChanged = false;
            }
            else
                RecordsExists = false;
        }

        internal void GetAll(List<ChattersDBBusiness.SystemInfo> list)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM SystemInfo";
            cmd.CommandType = CommandType.Text;

            DataTable dt = dataHelper.ExecuteReader(cmd);

            PopulateList(list, dt);
        }

        void PopulateList(List<ChattersDBBusiness.SystemInfo> list, DataTable reader)
        {
            foreach (DataRow dr in reader.Rows)
            {
                ChattersDBBusiness.SystemInfo systemInfo = new ChattersDBBusiness.SystemInfo();

                if (dr["ID"] != DBNull.Value)
                    systemInfo.ID = Convert.ToInt32(dr["ID"]);
                if (dr["SIKey"] != DBNull.Value)
                    systemInfo.SIKey = dr["SIKey"].ToString();
                if (dr["SIValue"] != DBNull.Value)
                    systemInfo.SIValue = dr["SIValue"].ToString();

                systemInfo.RecordsExists = true;
                systemInfo.AnyPropertyChanged = false;

                list.Add(systemInfo);
            }
        }

        internal void Insert()
        {
            OleDbCommand cmd = new OleDbCommand();

            string q = "INSERT INTO SystemInfo(SIKey,SIValue)\n";
            q += "Values(@SIKey,@SIValue)";

            cmd.CommandText = q;

            cmd.Parameters.Add("@SIKey", OleDbType.WChar, 255).Value = SIKey ?? "";
            cmd.Parameters.Add("@SIValue", OleDbType.WChar, 255).Value = SIValue ?? "";

            dataHelper.ExecuteNonReader(cmd);

            RecordsExists = true;
            AnyPropertyChanged = false;
        }

        internal void Update()
        {
            OleDbCommand cmd = new OleDbCommand();

            string q = "UPDATE SystemInfo SET\n";
            q += "SIKey = @SIKey,\n";
            q += "SIValue = @SIValue\n";
            q += "WHERE ID = @ID";

            cmd.CommandText = q;

            cmd.Parameters.Add("@SIKey", OleDbType.WChar, 255).Value = SIKey ?? "";
            cmd.Parameters.Add("@SIValue", OleDbType.WChar, 255).Value = SIValue ?? "";

            cmd.Parameters.Add("@ID", OleDbType.Integer).Value = ID;

            dataHelper.ExecuteNonReader(cmd);

            RecordsExists = true;
            AnyPropertyChanged = false;
        }

        public void Delete()
        {
            OleDbCommand cmd = new OleDbCommand();

            string q = "DELETE FROM SystemInfo\n";
            q += "WHERE ID = @ID";

            cmd.CommandText = q;

            cmd.Parameters.Add("@ID", OleDbType.Integer).Value = ID;

            dataHelper.ExecuteNonReader(cmd);
        }

        internal void GetAll(string likeKey, ChattersDBLists.SystemInfoList systemInfoList)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM SystemInfo WHERE SIKey LIKE '%" + likeKey + "%'";

            cmd.CommandType = CommandType.Text;

            DataTable dt = dataHelper.ExecuteReader(cmd);

            PopulateList(systemInfoList, dt);
        }

        internal void GetByKey(string key, ChattersDBLists.SystemInfoList systemInfoList)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM SystemInfo WHERE SIKey = @Key";

            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@Key", OleDbType.VarChar).Value = key;

            DataTable dt = dataHelper.ExecuteReader(cmd);

            PopulateList(systemInfoList, dt);
        }
    }
}