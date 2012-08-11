using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.Data
{
    public partial class MovieGenreData : Properties.MovieGenreProperties
    {
        private string _selectColumnNames = "MG.[Movie], MG.[Genre]";
        private DataHelper dataHelper;

        public MovieGenreData()
        {
            dataHelper = new DataHelper();
        }

        internal void SetRowProperties(DataRow dr, Properties.MovieGenreProperties row)
        {
            row.Movie = Convert.ToInt32(dr["Movie"]);
            row.Genre = Convert.ToByte(dr["Genre"]);
            row.Exists = true;
            row.HasChanged = false;
        }

        internal DataTable GetData(string orderBy)
        {
            string q = "SELECT ";
            if (dataHelper.MaxRows != 0)
                q += " TOP " + dataHelper.MaxRows.ToString() + " ";
            q += _selectColumnNames + "\n";
            q += "FROM dbo.MovieGenre AS MG\n";
            if (orderBy != "")
                q += "ORDER BY " + orderBy;

            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
        }

        private UpdateProperties UpdateData()
        {
            string q = "UPDATE dbo.MovieGenre SET [Genre] = @Genre\n";
            q += "WHERE Movie = @Movie\n";
            q += "SELECT SCOPE_IDENTITY() 'Movie', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Movie;
            cmd.Parameters.Add("@AgeRating", SqlDbType.SmallInt).Value = Genre;

            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            base.HasChanged = false;
            return up;
        }

        private UpdateProperties InsertData()
        {
            string q = "INSERT INTO dbo.MovieGenre ( [Movie], [Genre])\n";
            q += "VALUES ( @Movie, @Genre )\n";
            q += "SELECT SCOPE_IDENTITY() 'Movie', @@ROWCOUNT 'RowCount'";
            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@Movie", SqlDbType.Int).Value = Movie;
            cmd.Parameters.Add("@Genre", SqlDbType.SmallInt).Value = Genre;

            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            Movie = up.Identity;

            base.Exists = true; //After instert Exist must be true
            base.HasChanged = false; //After instert Change is false since it is a new record

            return up;
        }

        internal void DeleteItem(int movie, short genre)
        {
            string q = "DELETE FROM dbo.MovieGenre\n";
            q += "WHERE Movie = @Movie AND Genre = @Genre\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            cmd.Parameters.Add("@Movie", SqlDbType.Int).Value = movie;
            cmd.Parameters.Add("@Genre", SqlDbType.SmallInt).Value = genre;

            dataHelper.ExecuteNonQuery(cmd);
        }

        internal void LoadItemData(int movie, short genre)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.MovieGenre MG\n";
            q += "WHERE MG.Movie = @Movie and MG.Genre = @Genre\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            cmd.Parameters.Add("@Movie", SqlDbType.Int).Value = movie;
            cmd.Parameters.Add("@Genre", SqlDbType.SmallInt).Value = genre;

            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.Exists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }

        internal void PopulateList(List<Business.MovieGenre> list, DataTable dt)
        {
            list.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                Business.MovieGenre p = new Business.MovieGenre();
                SetRowProperties(dr, p);
                list.Add(p);
            }
        }

        internal void LoadAll(List<Business.MovieGenre> list)
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
                throw new Exception(string.Format("Applications record {0} was not updated successfully. Reason unknown."));
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
    }
}
