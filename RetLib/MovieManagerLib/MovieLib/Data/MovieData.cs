using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.Data
{
    public partial class MovieData : Properties.MovieProperties
    {
        private string _selectColumnNames = "M.[ID], M.[Name], M.[GenreMain], M.[GenreSub], M.[Runtime], M.[IMDBRating], M.[YearOfRelease], M.[AgeRating], M.[PlotSummary]";
        private DataHelper dataHelper;

        public MovieData()
        {
            dataHelper = new DataHelper();
        }

        internal void SetRowProperties(DataRow dr, Properties.MovieProperties row)
        {
            row.ID = Convert.ToInt32(dr["ID"]);
            row.Name = Convert.ToString(dr["Name"]);
            row.GenreMain = Convert.ToInt16(dr["GenreMain"]);
            if ((dr["GenreSub"]) == DBNull.Value)
                row.GenreSub = null;
            else
                row.GenreSub = Convert.ToInt16(dr["GenreSub"]);

            row.Runtime = Convert.ToByte(dr["Runtime"]);
            if ((dr["IMDBRating"]) == DBNull.Value)
                row.IMDBRating = null;
            else
                row.IMDBRating = Convert.ToDecimal(dr["IMDBRating"]);

            if ((dr["YearOfRelease"]) == DBNull.Value)
                row.YearOfRelease = null;
            else
                row.YearOfRelease = Convert.ToDateTime(dr["YearOfRelease"]);

            if ((dr["AgeRating"]) == DBNull.Value)
                row.AgeRating = null;
            else
                row.AgeRating = Convert.ToByte(dr["AgeRating"]);

            if ((dr["PlotSummary"]) == DBNull.Value)
                row.PlotSummary = null;
            else
                row.PlotSummary = Convert.ToString(dr["PlotSummary"]);

            row.Exists = true;
            row.HasChanged = false;
        }

        internal DataTable GetData(string orderBy)
        {
            string q = "SELECT ";
            if (dataHelper.MaxRows != 0)
                q += " TOP " + dataHelper.MaxRows.ToString() + " ";
            q += _selectColumnNames + "\n";
            q += "FROM dbo.Movie AS M\n";
            if (orderBy != "")
                q += "ORDER BY " + orderBy;

            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
        }

        private UpdateProperties UpdateData()
        {
            string q = "UPDATE dbo.Movie SET [ID] = @ID, [Name] = @Name, [GenreMain] = @GenreMain, [GenreSub] = @GenreSub, [Runtime] = @Runtime, [IMDBRating] = @IMDBRating, [YearOfRelease] = @YearOfRelease, [AgeRating] = @AgeRating, [PlotSummary] = @PlotSummary\n";
            q += "WHERE ID = @ID\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 150).Value = Name;

            cmd.Parameters.Add("@GenreMain", SqlDbType.SmallInt).Value = GenreMain;

            if (GenreSub == null)
                cmd.Parameters.Add("@GenreSub", SqlDbType.SmallInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@GenreSub", SqlDbType.SmallInt).Value = GenreSub;

            cmd.Parameters.Add("@Runtime", SqlDbType.TinyInt).Value = Runtime;

            if (IMDBRating == null)
                cmd.Parameters.Add("@IMDBRating", SqlDbType.Decimal).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@IMDBRating", SqlDbType.Decimal).Value = IMDBRating;


            if (YearOfRelease == null)
                cmd.Parameters.Add("@YearOfRelease", SqlDbType.DateTime).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@YearOfRelease", SqlDbType.DateTime).Value = YearOfRelease;


            if (AgeRating == null)
                cmd.Parameters.Add("@AgeRating", SqlDbType.TinyInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@AgeRating", SqlDbType.TinyInt).Value = AgeRating;


            if (PlotSummary == null)
                cmd.Parameters.Add("@PlotSummary", SqlDbType.VarChar, 300).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@PlotSummary", SqlDbType.VarChar, 300).Value = PlotSummary;

            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            base.HasChanged = false;
            return up;
        }

        private UpdateProperties InsertData()
        {
            string q = "INSERT INTO dbo.Movie ( [ID], [Name], [GenreMain], [GenreSub], [Runtime], [IMDBRating], [YearOfRelease], [AgeRating], [PlotSummary] )\n";
            q += "VALUES ( @ID, @Name, @GenreMain, @GenreSub, @Runtime, @IMDBRating, @YearOfRelease, @AgeRating, @PlotSummary )\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";
            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 150).Value = Name;

            cmd.Parameters.Add("@GenreMain", SqlDbType.SmallInt).Value = GenreMain;

            if (GenreSub == null)
                cmd.Parameters.Add("@GenreSub", SqlDbType.SmallInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@GenreSub", SqlDbType.SmallInt).Value = GenreSub;

            cmd.Parameters.Add("@Runtime", SqlDbType.TinyInt).Value = Runtime;

            if (IMDBRating == null)
                cmd.Parameters.Add("@IMDBRating", SqlDbType.Decimal).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@IMDBRating", SqlDbType.Decimal).Value = IMDBRating;


            if (YearOfRelease == null)
                cmd.Parameters.Add("@YearOfRelease", SqlDbType.DateTime).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@YearOfRelease", SqlDbType.DateTime).Value = YearOfRelease;


            if (AgeRating == null)
                cmd.Parameters.Add("@AgeRating", SqlDbType.TinyInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@AgeRating", SqlDbType.TinyInt).Value = AgeRating;


            if (PlotSummary == null)
                cmd.Parameters.Add("@PlotSummary", SqlDbType.VarChar, 300).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@PlotSummary", SqlDbType.VarChar, 300).Value = PlotSummary;

            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            ID = up.Identity;

            base.Exists = true; //After instert Exist must be true
            base.HasChanged = false; //After instert Change is false since it is a new record

            return up;
        }
        internal void DeleteItem(int id)
        {
            string q = "DELETE FROM dbo.Movie\n";
            q += "WHERE ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

            dataHelper.ExecuteNonQuery(cmd);
        }
        internal void LoadItemData(int iD)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.Movie M\n";
            q += "WHERE M.ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = iD;

            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.Exists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }
        internal void PopulateList(List<Business.Movie> list, DataTable dt)
        {
            list.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                Business.Movie p = new Business.Movie();
                SetRowProperties(dr, p);
                list.Add(p);
            }
        }
        internal void LoadAll(List<Business.Movie> list)
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