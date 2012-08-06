using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.Data
{
    public partial class AgeRatingTypeData : Properties.AgeRatingTypeProperties
    {
        private string _selectColumnNames = "A.[ID], A.[AgeRating], A.[AgeRatingDescription]";
        private DataHelper dataHelper;

        public AgeRatingTypeData()
        {
            dataHelper = new DataHelper();
        }

        internal void SetRowProperties(DataRow dr, Properties.AgeRatingTypeProperties row)
        {
            row.ID = Convert.ToByte(dr["ID"]);
            row.AgeRating = Convert.ToString(dr["AgeRating"]);
            row.AgeRatingDescription = Convert.ToString(dr["AgeRatingDescription"]);
            row.Exists = true;
            row.HasChanged = false;
        }

        internal DataTable GetData(string orderBy)
        {
            string q = "SELECT ";
            if (dataHelper.MaxRows != 0)
                q += " TOP " + dataHelper.MaxRows.ToString() + " ";
            q += _selectColumnNames + "\n";
            q += "FROM dbo.AgeRatingType AS A\n";
            if (orderBy != "")
                q += "ORDER BY " + orderBy;

            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
        }

        private UpdateProperties UpdateData()
        {
            string q = "UPDATE dbo.AgeRatingType SET [ID] = @ID, [AgeRating] = @AgeRating, [AgeRatingDescription] = @AgeRatingDescription\n";
            q += "WHERE ID = @ID\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.TinyInt).Value = ID;
            cmd.Parameters.Add("@AgeRating", SqlDbType.VarChar, 10).Value = AgeRating;

            cmd.Parameters.Add("@AgeRatingDescription", SqlDbType.VarChar, 50).Value = AgeRatingDescription;


            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            base.HasChanged = false;
            return up;
        }

        private UpdateProperties InsertData()
        {
            string q = "INSERT INTO dbo.AgeRatingType ( [ID], [AgeRating], [AgeRatingDescription] )\n";
            q += "VALUES ( @ID, @AgeRating, @AgeRatingDescription )\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";
            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.TinyInt).Value = ID;
            cmd.Parameters.Add("@AgeRating", SqlDbType.VarChar, 10).Value = AgeRating;

            cmd.Parameters.Add("@AgeRatingDescription", SqlDbType.VarChar, 50).Value = AgeRatingDescription;


            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            ID = Convert.ToByte(up.Identity);

            base.Exists = true; //After instert Exist must be true
            base.HasChanged = false; //After instert Change is false since it is a new record

            return up;
        }

        internal void DeleteItem(byte id)
        {
            string q = "DELETE FROM dbo.AgeRatingType\n";
            q += "WHERE ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.TinyInt).Value = id;

            dataHelper.ExecuteNonQuery(cmd);
        }

        internal void LoadItemData(byte iD)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.AgeRatingType A\n";
            q += "WHERE A.ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.TinyInt).Value = iD;

            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.Exists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }

        internal void PopulateList(List<Business.AgeRatingType> list, DataTable dt)
        {
            list.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                Business.AgeRatingType p = new Business.AgeRatingType();
                SetRowProperties(dr, p);
                list.Add(p);
            }
        }

        internal void LoadAll(List<Business.AgeRatingType> list)
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