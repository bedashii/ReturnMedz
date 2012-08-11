using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.Data
{
    public partial class AudioLanguagesData : Properties.AudioLanguagesProperties
    {
        private string _selectColumnNames = "A.[ID], A.[Description]";
        private DataHelper dataHelper;

        public AudioLanguagesData()
        {
            dataHelper = new DataHelper();
        }

        internal void SetRowProperties(DataRow dr, Properties.AudioLanguagesProperties row)
        {
            row.ID = Convert.ToInt16(dr["ID"]);
            row.Description = Convert.ToString(dr["Description"]);
            row.Exists = true;
            row.HasChanged = false;
        }

        internal DataTable GetData(string orderBy)
        {
            string q = "SELECT ";
            if (dataHelper.MaxRows != 0)
                q += " TOP " + dataHelper.MaxRows.ToString() + " ";
            q += _selectColumnNames + "\n";
            q += "FROM dbo.AudioLanguages AS A\n";
            if (orderBy != "")
                q += "ORDER BY " + orderBy;

            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
        }

        private UpdateProperties UpdateData()
        {
            string q = "UPDATE dbo.AudioLanguages SET [ID] = @ID, [Description] = @Description\n";
            q += "WHERE ID = @ID\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.SmallInt).Value = ID;
            cmd.Parameters.Add("@Description", SqlDbType.VarChar, 30).Value = Description;


            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            base.HasChanged = false;
            return up;
        }

        private UpdateProperties InsertData()
        {
            string q = "INSERT INTO dbo.AudioLanguages ( [ID], [Description] )\n";
            q += "VALUES ( @ID, @Description )\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";
            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.SmallInt).Value = ID;
            cmd.Parameters.Add("@Description", SqlDbType.VarChar, 30).Value = Description;


            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            ID = (short)up.Identity;

            base.Exists = true; //After instert Exist must be true
            base.HasChanged = false; //After instert Change is false since it is a new record

            return up;
        }

        internal void DeleteItem(short id)
        {
            string q = "DELETE FROM dbo.AudioLanguages\n";
            q += "WHERE ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.SmallInt).Value = id;

            dataHelper.ExecuteNonQuery(cmd);
        }

        internal void LoadItemData(short iD)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.AudioLanguages A\n";
            q += "WHERE A.ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.SmallInt).Value = iD;

            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.Exists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }

        internal void PopulateList(List<Business.AudioLanguages> list, DataTable dt)
        {
            list.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                Business.AudioLanguages p = new Business.AudioLanguages();
                SetRowProperties(dr, p);
                list.Add(p);
            }
        }

        internal void LoadAll(List<Business.AudioLanguages> list)
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