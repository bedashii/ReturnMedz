using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.Data
{
    public partial class ExtensionTypeData : Properties.ExtensionTypeProperties
    {
        private string _selectColumnNames = "E.[ID], E.[Extension], E.[ExtensionDescription]";
        private DataHelper dataHelper;

        public ExtensionTypeData()
        {
            dataHelper = new DataHelper();
        }

        internal void SetRowProperties(DataRow dr, Properties.ExtensionTypeProperties row)
        {
            row.ID = Convert.ToByte(dr["ID"]);
            row.Extension = Convert.ToString(dr["Extension"]);
            row.ExtensionDescription = Convert.ToString(dr["ExtensionDescription"]);
            row.Exists = true;
            row.HasChanged = false;
        }

        internal DataTable GetData(string orderBy)
        {
            string q = "SELECT ";
            if (dataHelper.MaxRows != 0)
                q += " TOP " + dataHelper.MaxRows.ToString() + " ";
            q += _selectColumnNames + "\n";
            q += "FROM dbo.ExtensionType AS E\n";
            if (orderBy != "")
                q += "ORDER BY " + orderBy;

            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
        }

        private UpdateProperties UpdateData()
        {
            string q = "UPDATE dbo.ExtensionType SET [ID] = @ID, [Extension] = @Extension, [ExtensionDescription] = @ExtensionDescription\n";
            q += "WHERE ID = @ID\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.TinyInt).Value = ID;
            cmd.Parameters.Add("@Extension", SqlDbType.VarChar, 10).Value = Extension;

            cmd.Parameters.Add("@ExtensionDescription", SqlDbType.VarChar, 100).Value = ExtensionDescription;


            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            base.HasChanged = false;
            return up;
        }

        private UpdateProperties InsertData()
        {
            string q = "INSERT INTO dbo.ExtensionType ( [ID], [Extension], [ExtensionDescription] )\n";
            q += "VALUES ( @ID, @Extension, @ExtensionDescription )\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";
            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.TinyInt).Value = ID;
            cmd.Parameters.Add("@Extension", SqlDbType.VarChar, 10).Value = Extension;

            cmd.Parameters.Add("@ExtensionDescription", SqlDbType.VarChar, 100).Value = ExtensionDescription;


            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            ID = Convert.ToByte(up.Identity);

            base.Exists = true; //After instert Exist must be true
            base.HasChanged = false; //After instert Change is false since it is a new record

            return up;
        }
        internal void DeleteItem(byte id)
        {
            string q = "DELETE FROM dbo.ExtensionType\n";
            q += "WHERE ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.TinyInt).Value = id;

            dataHelper.ExecuteNonQuery(cmd);
        }
        internal void LoadItemData(byte iD)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.ExtensionType E\n";
            q += "WHERE E.ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.TinyInt).Value = iD;

            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.Exists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }
        internal void PopulateList(List<Business.ExtensionType> list, DataTable dt)
        {
            list.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                Business.ExtensionType p = new Business.ExtensionType();
                SetRowProperties(dr, p);
                list.Add(p);
            }
        }
        internal void LoadAll(List<Business.ExtensionType> list)
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