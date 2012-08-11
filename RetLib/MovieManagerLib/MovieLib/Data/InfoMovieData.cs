using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.Data
{
    public partial class InfoMovieData : Properties.InfoMovieProperties
    {
        private string _selectColumnNames = "I.[ID], I.[Name], I.[IMDbID], I.[Genre1], I.[Genre2], I.[Genre3], I.[Runtime], I.[Rating], I.[ReleaseYear], I.[AgeRating], I.[Plot], I.[Storyline], I.[Poster]";
        private DataHelper dataHelper;

        public InfoMovieData()
        {
            dataHelper = new DataHelper();
        }

        internal void SetRowProperties(DataRow dr, Properties.InfoMovieProperties row)
        {
            row.ID = Convert.ToInt32(dr["ID"]);
            row.Name = Convert.ToString(dr["Name"]);
            if ((dr["IMDbID"]) == DBNull.Value)
                row.IMDbID = null;
            else
                row.IMDbID = Convert.ToString(dr["IMDbID"]);

            if ((dr["Genre1"]) == DBNull.Value)
                row.Genre1 = null;
            else
                row.Genre1 = Convert.ToInt16(dr["Genre1"]);

            if ((dr["Genre2"]) == DBNull.Value)
                row.Genre2 = null;
            else
                row.Genre2 = Convert.ToInt16(dr["Genre2"]);

            if ((dr["Genre3"]) == DBNull.Value)
                row.Genre3 = null;
            else
                row.Genre3 = Convert.ToInt16(dr["Genre3"]);

            if ((dr["Runtime"]) == DBNull.Value)
                row.Runtime = null;
            else
                row.Runtime = Convert.ToString(dr["Runtime"]);

            if ((dr["Rating"]) == DBNull.Value)
                row.Rating = null;
            else
                row.Rating = Convert.ToDecimal(dr["Rating"]);

            if ((dr["ReleaseYear"]) == DBNull.Value)
                row.ReleaseYear = null;
            else
                row.ReleaseYear = Convert.ToInt32(dr["ReleaseYear"]);

            if ((dr["AgeRating"]) == DBNull.Value)
                row.AgeRating = null;
            else
                row.AgeRating = Convert.ToByte(dr["AgeRating"]);

            if ((dr["Plot"]) == DBNull.Value)
                row.Plot = null;
            else
                row.Plot = Convert.ToString(dr["Plot"]);

            if ((dr["Storyline"]) == DBNull.Value)
                row.Storyline = null;
            else
                row.Storyline = Convert.ToString(dr["Storyline"]);

            if ((dr["Poster"]) == DBNull.Value)
                row.Poster = null;
            else
                row.Poster = Convert.ToString(dr["Poster"]);

            row.Exists = true;
            row.HasChanged = false;
        }

        internal DataTable GetData(string orderBy)
        {
            string q = "SELECT ";
            if (dataHelper.MaxRows != 0)
                q += " TOP " + dataHelper.MaxRows.ToString() + " ";
            q += _selectColumnNames + "\n";
            q += "FROM dbo.InfoMovie AS I\n";
            if (orderBy != "")
                q += "ORDER BY " + orderBy;

            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
        }

        private UpdateProperties UpdateData()
        {
            string q = "UPDATE dbo.InfoMovie SET [ID] = @ID, [Name] = @Name, [IMDbID] = @IMDbID, [Genre1] = @Genre1, [Genre2] = @Genre2, [Genre3] = @Genre3, [Runtime] = @Runtime, [Rating] = @Rating, [ReleaseYear] = @ReleaseYear, [AgeRating] = @AgeRating, [Plot] = @Plot, [Storyline] = @Storyline, [Poster] = @Poster\n";
            q += "WHERE ID = @ID\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 150).Value = Name;


            if (IMDbID == null)
                cmd.Parameters.Add("@IMDbID", SqlDbType.VarChar, 15).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@IMDbID", SqlDbType.VarChar, 15).Value = IMDbID;

            if (Genre1 == null)
                cmd.Parameters.Add("@Genre1", SqlDbType.SmallInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Genre1", SqlDbType.SmallInt).Value = Genre1;


            if (Genre2 == null)
                cmd.Parameters.Add("@Genre2", SqlDbType.SmallInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Genre2", SqlDbType.SmallInt).Value = Genre2;


            if (Genre3 == null)
                cmd.Parameters.Add("@Genre3", SqlDbType.SmallInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Genre3", SqlDbType.SmallInt).Value = Genre3;


            if (Runtime == null)
                cmd.Parameters.Add("@Runtime", SqlDbType.VarChar, 10).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Runtime", SqlDbType.VarChar, 10).Value = Runtime;

            if (Rating == null)
                cmd.Parameters.Add("@Rating", SqlDbType.Decimal).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Rating", SqlDbType.Decimal).Value = Rating;


            if (ReleaseYear == null)
                cmd.Parameters.Add("@ReleaseYear", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ReleaseYear", SqlDbType.Int).Value = ReleaseYear;


            if (AgeRating == null)
                cmd.Parameters.Add("@AgeRating", SqlDbType.TinyInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@AgeRating", SqlDbType.TinyInt).Value = AgeRating;


            if (Plot == null)
                cmd.Parameters.Add("@Plot", SqlDbType.VarChar, 300).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Plot", SqlDbType.VarChar, 300).Value = Plot;

            if (Storyline == null)
                cmd.Parameters.Add("@Storyline", SqlDbType.VarChar, 600).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Storyline", SqlDbType.VarChar, 600).Value = Storyline;

            if (Poster == null)
                cmd.Parameters.Add("@Poster", SqlDbType.VarChar, 1000).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Poster", SqlDbType.VarChar, 1000).Value = Poster;

            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            base.HasChanged = false;
            return up;
        }

        private UpdateProperties InsertData()
        {
            string q = "INSERT INTO dbo.InfoMovie ( [ID], [Name], [IMDbID], [Genre1], [Genre2], [Genre3], [Runtime], [Rating], [ReleaseYear], [AgeRating], [Plot], [Storyline], [Poster] )\n";
            q += "VALUES ( @ID, @Name, @IMDbID, @Genre1, @Genre2, @Genre3, @Runtime, @Rating, @ReleaseYear, @AgeRating, @Plot, @Storyline, @Poster )\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";
            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 150).Value = Name;


            if (IMDbID == null)
                cmd.Parameters.Add("@IMDbID", SqlDbType.VarChar, 15).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@IMDbID", SqlDbType.VarChar, 15).Value = IMDbID;

            if (Genre1 == null)
                cmd.Parameters.Add("@Genre1", SqlDbType.SmallInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Genre1", SqlDbType.SmallInt).Value = Genre1;


            if (Genre2 == null)
                cmd.Parameters.Add("@Genre2", SqlDbType.SmallInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Genre2", SqlDbType.SmallInt).Value = Genre2;


            if (Genre3 == null)
                cmd.Parameters.Add("@Genre3", SqlDbType.SmallInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Genre3", SqlDbType.SmallInt).Value = Genre3;


            if (Runtime == null)
                cmd.Parameters.Add("@Runtime", SqlDbType.VarChar, 10).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Runtime", SqlDbType.VarChar, 10).Value = Runtime;

            if (Rating == null)
                cmd.Parameters.Add("@Rating", SqlDbType.Decimal).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Rating", SqlDbType.Decimal).Value = Rating;


            if (ReleaseYear == null)
                cmd.Parameters.Add("@ReleaseYear", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ReleaseYear", SqlDbType.Int).Value = ReleaseYear;


            if (AgeRating == null)
                cmd.Parameters.Add("@AgeRating", SqlDbType.TinyInt).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@AgeRating", SqlDbType.TinyInt).Value = AgeRating;


            if (Plot == null)
                cmd.Parameters.Add("@Plot", SqlDbType.VarChar, 300).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Plot", SqlDbType.VarChar, 300).Value = Plot;

            if (Storyline == null)
                cmd.Parameters.Add("@Storyline", SqlDbType.VarChar, 600).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Storyline", SqlDbType.VarChar, 600).Value = Storyline;

            if (Poster == null)
                cmd.Parameters.Add("@Poster", SqlDbType.VarChar, 1000).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Poster", SqlDbType.VarChar, 1000).Value = Poster;

            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            ID = up.Identity;

            base.Exists = true; //After instert Exist must be true
            base.HasChanged = false; //After instert Change is false since it is a new record

            return up;
        }

        internal void DeleteItem(int id)
        {
            string q = "DELETE FROM dbo.InfoMovie\n";
            q += "WHERE ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

            dataHelper.ExecuteNonQuery(cmd);
        }

        internal void LoadItemData(int iD)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.InfoMovie I\n";
            q += "WHERE I.ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = iD;

            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.Exists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }

        internal void PopulateList(List<Business.InfoMovie> list, DataTable dt)
        {
            list.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                Business.InfoMovie p = new Business.InfoMovie();
                SetRowProperties(dr, p);
                list.Add(p);
            }
        }

        internal void LoadAll(List<Business.InfoMovie> list)
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