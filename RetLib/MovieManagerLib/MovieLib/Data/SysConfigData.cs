using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.Data
{
    public partial class SysConfigData : Properties.SysConfigProperties
    {
        private string _selectColumnNames = "S.[ID], S.[Setting], S.[Config]";
        private DataHelper dataHelper;

        public SysConfigData()
        {
            dataHelper = new DataHelper();
        }

        internal void SetRowProperties(DataRow dr, Properties.SysConfigProperties row)
        {
            row.ID = Convert.ToInt32(dr["ID"]);
            if ((dr["Setting"]) == DBNull.Value)
                row.Setting = null;
            else
                row.Setting = Convert.ToString(dr["Setting"]);

            if ((dr["Config"]) == DBNull.Value)
                row.Config = null;
            else
                row.Config = Convert.ToString(dr["Config"]);

            row.Exists = true;
            row.HasChanged = false;
        }

        internal DataTable GetData(string orderBy)
        {
            string q = "SELECT ";
            if (dataHelper.MaxRows != 0)
                q += " TOP " + dataHelper.MaxRows.ToString() + " ";
            q += _selectColumnNames + "\n";
            q += "FROM dbo.SysConfig AS S\n";
            if (orderBy != "")
                q += "ORDER BY " + orderBy;

            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
        }

        private UpdateProperties UpdateData()
        {
            string q = "UPDATE dbo.SysConfig SET [ID] = @ID, [Setting] = @Setting, [Config] = @Config\n";
            q += "WHERE ID = @ID\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            if (Setting == null)
                cmd.Parameters.Add("@Setting", SqlDbType.VarChar, 100).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Setting", SqlDbType.VarChar, 100).Value = Setting;

            if (Config == null)
                cmd.Parameters.Add("@Config", SqlDbType.VarChar, 500).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Config", SqlDbType.VarChar, 500).Value = Config;

            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            base.HasChanged = false;
            return up;
        }

        private UpdateProperties InsertData()
        {
            string q = "INSERT INTO dbo.SysConfig ( [ID], [Setting], [Config] )\n";
            q += "VALUES ( @ID, @Setting, @Config )\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";
            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            if (Setting == null)
                cmd.Parameters.Add("@Setting", SqlDbType.VarChar, 100).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Setting", SqlDbType.VarChar, 100).Value = Setting;

            if (Config == null)
                cmd.Parameters.Add("@Config", SqlDbType.VarChar, 500).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Config", SqlDbType.VarChar, 500).Value = Config;

            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            ID = up.Identity;

            base.Exists = true; //After instert Exist must be true
            base.HasChanged = false; //After instert Change is false since it is a new record

            return up;
        }

        internal void DeleteItem(int id)
        {
            string q = "DELETE FROM dbo.SysConfig\n";
            q += "WHERE ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

            dataHelper.ExecuteNonQuery(cmd);
        }

        internal void LoadItemData(int iD)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.SysConfig S\n";
            q += "WHERE S.ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = iD;

            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.Exists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }

        internal void LoadItemData(string setting)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.SysConfig S\n";
            q += "WHERE S.Setting = @Setting\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            cmd.Parameters.Add("@Setting", SqlDbType.VarChar, 100).Value = setting;

            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.Exists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }

        internal void PopulateList(List<Business.SysConfig> list, DataTable dt)
        {
            list.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                Business.SysConfig p = new Business.SysConfig();
                SetRowProperties(dr, p);
                list.Add(p);
            }
        }

        internal void LoadAll(List<Business.SysConfig> list)
        {
            PopulateList(list, GetData(""));
        }

        public virtual void ValidateFields()
        { }

        public virtual void Update()
        {
            ValidateFields();
            Data.UpdateProperties up = this.UpdateData();
            if (up.RowsAffected == 0)
                throw new Exception(string.Format("Applications record {0} was not updated successfully. Reason unknown.", GetPrimaryKeyValues()));
        }

        public virtual void Insert()
        {
            ValidateFields();
            this.InsertData();
        }

        public virtual void InsertOrUpdate()
        {
            if (this.Exists)
                this.Update();
            else
                this.Insert();
        }

        public string GetPrimaryKeyValues()
        {
            string pkValues = "PK:[";
            pkValues += "ID=" + ID.ToString();
            return pkValues + "]";
        }
    }
}