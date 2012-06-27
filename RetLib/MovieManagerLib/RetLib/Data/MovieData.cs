using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetLib.Data
{
    public partial class MovieData : Properties.MovieProperties
    {
        private string _selectColumnNames = "M.[ID], M.[Title], M.[Subtitle], M.[SequenceNumber], M.[Synopsis], M.[ReleaseDate], M.[RunningTime], M.[IMDBRating], M.[Format], M.[Quality], M.[Genre1], M.[Genre2], M.[Genre3]";
        private DataHelper dataHelper;

        public MovieData()
        {
            dataHelper = new DataHelper();
        }

        internal void SetRowProperties(DataRow dr, Properties.MovieProperties row)
        {
            row.ID = Convert.ToInt32(dr["ID"]);
            row.Title = Convert.ToString(dr["Title"]);
            row.Subtitle = Convert.ToString(dr["Subtitle"]);

            if ((dr["SequenceNumber"]) == DBNull.Value)
                row.SequenceNumber = null;
            else
                row.SequenceNumber = Convert.ToInt32(dr["SequenceNumber"]);

            if ((dr["Synopsis"]) == DBNull.Value)
                row.Synopsis = null;
            else
                row.Synopsis = (Convert.ToString(dr["Synopsis"]));

            if ((dr["ReleaseDate"]) == DBNull.Value)
                row.ReleaseDate = new DateTime();
            else
                row.ReleaseDate = (Convert.ToDateTime(dr["ReleaseDate"]));

            if ((dr["RunningTime"]) == DBNull.Value)
                row.RunningTime = null;
            else
                row.RunningTime = (Convert.ToInt16(dr["RunningTime"]));

            if ((dr["IMDBRating"]) == DBNull.Value)
                row.IMDBRating = null;
            else
                row.IMDBRating = (Convert.ToDecimal(dr["IMDBRating"]));

            row.FormatType = (Convert.ToInt32(dr["FormatType"]));
            row.QualityType = (Convert.ToInt32(dr["QualityType"]));
            row.Genre1 = (Convert.ToInt32(dr["Genre1"]));

            if ((dr["Genre2"]) == DBNull.Value)
                row.Genre2 = null;
            else
                row.Genre2 = (Convert.ToInt32(dr["Genre2"]));

            if ((dr["Genre3"]) == DBNull.Value)
                row.Genre3 = null;
            else
                row.Genre3 = (Convert.ToInt32(dr["Genre3"]));

            row.Exists = true;
            row.HasChanged = false;
        }

        internal DataTable GetData(string orderBy)
        {
            string q = "SELECT ";
            if (dataHelper.MaxRows != 0)
                q += " TOP " + dataHelper.MaxRows.ToString() + " ";
            q += _selectColumnNames + "\n";
            q += "FROM dbo.Movies AS M\n";
            if (orderBy != "")
                q += "ORDER BY " + orderBy;

            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
        }

        private DataTable GetByGenreData(int genre)
        {
            string q = "SELECT ";
            if (dataHelper.MaxRows != 0)
                q += " TOP " + dataHelper.MaxRows.ToString() + " ";
            q += _selectColumnNames + "\n";
            q += "FROM Movies AS M\n";
            q += "WHERE M.Genre = " + genre.ToString();

            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
        }

        private UpdateProperties UpdateData()
        {
            string q = "UPDATE dbo.Movies SET [Title] = @Title, [Subtitle] = @Subtitle, [SequenceNumber] = @SequenceNumber, [Synopsis] = @Synopsis, [ReleaseDate] = @ReleaseDate, [RunningTime] = @RunningTime, [IMDBRating] = @IMDBRating, [FormatType] = @FormatType, [QualityType] = @QualityType, [Genre1] = @Genre1, [Genre2] = @Genre2, [Genre3] = @Genre3\n";
            q += "WHERE ID = @ID\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@Title", SqlDbType.VarChar, 50).Value = Title;

            if (Subtitle == null)
                cmd.Parameters.Add("@Subtitle", SqlDbType.VarChar, 50).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Subtitle", SqlDbType.VarChar, 50).Value = Subtitle;

            if (SequenceNumber == null)
                cmd.Parameters.Add("@SequenceNumber", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@SequenceNumber", SqlDbType.Int).Value = SequenceNumber;

            cmd.Parameters.Add("@Synopsis", SqlDbType.VarChar, 200).Value = Synopsis;

            if (ReleaseDate == null)
                cmd.Parameters.Add("@ReleaseDate", SqlDbType.DateTime).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ReleaseDate", SqlDbType.DateTime).Value = ReleaseDate;

            if (RunningTime == null)
                cmd.Parameters.Add("@RunningTime", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@RunningTime", SqlDbType.Int).Value = RunningTime;

            if (IMDBRating == null)
                cmd.Parameters.Add("@IMDBRating", SqlDbType.Decimal).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@IMDBRating", SqlDbType.Decimal).Value = IMDBRating;

            cmd.Parameters.Add("@FormatType", SqlDbType.Int).Value = FormatType;
            cmd.Parameters.Add("@QualityType", SqlDbType.Int).Value = QualityType;
            cmd.Parameters.Add("@Genre1", SqlDbType.Int).Value = Genre1;

            if (Genre2 == null)
                cmd.Parameters.Add("@Genre2", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Genre2", SqlDbType.Int).Value = Genre2;

            if (Genre3 == null)
                cmd.Parameters.Add("@Genre3", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Genre3", SqlDbType.Int).Value = Genre3;

            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            base.HasChanged = false;
            return up;
        }

        private UpdateProperties InsertData()
        {
            string q = "INSERT INTO dbo.Movies ( [Title] , [Subtitle] , [SequenceNumber] , [Synopsis] , [ReleaseDate] , [RunningTime] , [IMDBRating] = , [FormatType] , [QualityType] , [Genre1] , [Genre2] , [Genre3] )\n";
            q += "VALUES  ( @Title, @Subtitle, @SequenceNumber, @Synopsis, @ReleaseDate, @RunningTime, @IMDBRating, @FormatType, @QualityType, @Genre1, @Genre2, @Genre3)\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";
            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@Title", SqlDbType.VarChar, 50).Value = Title;

            if (Subtitle == null)
                cmd.Parameters.Add("@Subtitle", SqlDbType.VarChar, 50).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Subtitle", SqlDbType.VarChar, 50).Value = Subtitle;

            if (SequenceNumber == null)
                cmd.Parameters.Add("@SequenceNumber", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@SequenceNumber", SqlDbType.Int).Value = SequenceNumber;

            cmd.Parameters.Add("@Synopsis", SqlDbType.VarChar, 200).Value = Synopsis;

            if (ReleaseDate == null)
                cmd.Parameters.Add("@ReleaseDate", SqlDbType.DateTime).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ReleaseDate", SqlDbType.DateTime).Value = ReleaseDate;

            if (RunningTime == null)
                cmd.Parameters.Add("@RunningTime", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@RunningTime", SqlDbType.Int).Value = RunningTime;

            if (IMDBRating == null)
                cmd.Parameters.Add("@IMDBRating", SqlDbType.Decimal).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@IMDBRating", SqlDbType.Decimal).Value = IMDBRating;

            cmd.Parameters.Add("@FormatType", SqlDbType.Int).Value = FormatType;
            cmd.Parameters.Add("@QualityType", SqlDbType.Int).Value = QualityType;
            cmd.Parameters.Add("@Genre1", SqlDbType.Int).Value = Genre1;

            if (Genre2 == null)
                cmd.Parameters.Add("@Genre2", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Genre2", SqlDbType.Int).Value = Genre2;

            if (Genre3 == null)
                cmd.Parameters.Add("@Genre3", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Genre3", SqlDbType.Int).Value = Genre3;

            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            ID = up.Identity;

            base.Exists = true; //After instert Exist must be true
            base.HasChanged = false; //After instert Change is false since it is a new record

            return up;
        }

        internal void DeleteItem(int id)
        {
            string q = "DELETE FROM dbo.Movies \n";
            q += "WHERE ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

            dataHelper.ExecuteNonQuery(cmd);
        }

        internal void LoadItemData(int iD)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.Movies m\n";
            q += "WHERE m.ID = @ID\n";

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

        internal void LoadByGenre(Lists.MovieList list, int genre)
        {
            PopulateList(list, GetByGenreData(genre));
        }
    }
}
