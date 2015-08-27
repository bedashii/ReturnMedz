using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TempDataGenLib.Business;


/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/


namespace TempDataGenLib.Data
{
    public partial class CardsData : Properties.CardsProperties
    {
        private DataProcessHelper dataHelper = new DataProcessHelper();

        private string _selectColumnNames = "C.[ID], C.[Hero], C.[Name], C.[Cost], C.[Attack], C.[Duration], C.[MinAdditionalDamage], C.[MaxExtraDamage], C.[AdditionalCost]";

        public CardsData()
        {
        }
        
        internal void LoadItemData(int iD)
        {
            string q = "SELECT " + _selectColumnNames + " FROM dbo.Cards C\n";
            q += "WHERE C.ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Value = iD;
            DataTable dt = dataHelper.ExecuteQuery(cmd);
            if (dt.Rows.Count == 0)
                base.RecordExists = false;
            else
                SetRowProperties(dt.Rows[0], this);
        }
        
        
        
        

        internal void LoadAll(List<Cards> list)
        {
            PopulateList(list, this.GetData(""));
        }

        internal void LoadAll(List<Cards> list, string orderBy)
        {
            PopulateList(list, this.GetData(orderBy));
        }
        
        internal void DeleteItem(int iD)
        {
            string q = "DELETE FROM dbo.Cards \n";
            q += "WHERE ID = @ID\n";

            SqlCommand cmd = dataHelper.CreateCommand(q);
            
            cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Value = iD;
            
            dataHelper.ExecuteNonQuery(cmd);
        }        
/* FOR LATER REFACTORING:
        private void AddPrimaryKeyParameters(SqlCommand cmd, int iD)
        {
            cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Value = iD;
        }
*/        
        internal void SetRowProperties(DataRow dr, Properties.CardsProperties row)
        {
            try
            {
				row.ID = Convert.ToInt32(dr["ID"]);
				row.Hero = Convert.ToInt32(dr["Hero"]);
				row.Name = Convert.ToString(dr["Name"]);
				row.Cost = Convert.ToInt16(dr["Cost"]);
				row.Attack = Convert.ToInt16(dr["Attack"]);
				row.Duration = Convert.ToInt16(dr["Duration"]);
				row.MinAdditionalDamage = Convert.ToInt16(dr["MinAdditionalDamage"]);
				row.MaxExtraDamage = Convert.ToInt16(dr["MaxExtraDamage"]);
				row.AdditionalCost = Convert.ToInt16(dr["AdditionalCost"]);

                row.RecordExists = true;
                row.AnyPropertyChanged = false;
            }
            catch (Exception ex)
            {
                DataProcessHelper.ClearConnectionPools(ex);
                throw;
            }
        }
        internal DataTable GetData(string orderBy)
        {
            string q = "SELECT ";
            if (dataHelper.MaxRows != 0)
                q += " TOP " + dataHelper.MaxRows.ToString() + " ";
            q += _selectColumnNames + "\n";
            q += "FROM dbo.Cards AS C\n";
            if (orderBy != "")
                q += "ORDER BY " + orderBy;

            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));
        }

        private UpdateProperties UpdateData()
        {

            string q = "UPDATE dbo.Cards SET [Hero] = @Hero, [Name] = @Name, [Cost] = @Cost, [Attack] = @Attack, [Duration] = @Duration, [MinAdditionalDamage] = @MinAdditionalDamage, [MaxExtraDamage] = @MaxExtraDamage, [AdditionalCost] = @AdditionalCost\n";
            q += "WHERE ID = @ID\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";

            SqlCommand cmd = dataHelper.CreateCommand(q);

            cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Value = ID;
			cmd.Parameters.Add("@Hero", SqlDbType.Int, 4).Value = Hero;
			cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = Name;
			cmd.Parameters.Add("@Cost", SqlDbType.SmallInt, 2).Value = Cost;
			cmd.Parameters.Add("@Attack", SqlDbType.SmallInt, 2).Value = Attack;
			cmd.Parameters.Add("@Duration", SqlDbType.SmallInt, 2).Value = Duration;
			cmd.Parameters.Add("@MinAdditionalDamage", SqlDbType.SmallInt, 2).Value = MinAdditionalDamage;
			cmd.Parameters.Add("@MaxExtraDamage", SqlDbType.SmallInt, 2).Value = MaxExtraDamage;
			cmd.Parameters.Add("@AdditionalCost", SqlDbType.SmallInt, 2).Value = AdditionalCost;
			
            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            base.AnyPropertyChanged = false; //After update Change is false since it's changes have been applied to the database
            return up;
        }

        private UpdateProperties InsertData()
        {
            string q = "INSERT INTO dbo.Cards ( [Hero], [Name], [Cost], [Attack], [Duration], [MinAdditionalDamage], [MaxExtraDamage], [AdditionalCost] )\n";
            q += "VALUES  ( @Hero, @Name, @Cost, @Attack, @Duration, @MinAdditionalDamage, @MaxExtraDamage, @AdditionalCost )\n";
            q += "SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'";
            SqlCommand cmd = dataHelper.CreateCommand(q);
            
            cmd.Parameters.Add("@Hero", SqlDbType.Int, 4).Value = Hero;
			cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = Name;
			cmd.Parameters.Add("@Cost", SqlDbType.SmallInt, 2).Value = Cost;
			cmd.Parameters.Add("@Attack", SqlDbType.SmallInt, 2).Value = Attack;
			cmd.Parameters.Add("@Duration", SqlDbType.SmallInt, 2).Value = Duration;
			cmd.Parameters.Add("@MinAdditionalDamage", SqlDbType.SmallInt, 2).Value = MinAdditionalDamage;
			cmd.Parameters.Add("@MaxExtraDamage", SqlDbType.SmallInt, 2).Value = MaxExtraDamage;
			cmd.Parameters.Add("@AdditionalCost", SqlDbType.SmallInt, 2).Value = AdditionalCost;
			
            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);
            ID = Convert.ToInt32(up.Identity);


            base.RecordExists = true; //After instert Exist must be true
            base.AnyPropertyChanged = false; //After instert Change is false since it is a new record

            return up;
        }

        private void PopulateList(List<Business.Cards> list, DataTable dt)
        {
            list.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                Business.Cards p = new Business.Cards();
                SetRowProperties(dr, p);
                list.Add(p);
            }
        }

        public virtual void ValidateFields()
        {}

        public virtual void Update()
        {
            ValidateFields();
            Data.UpdateProperties up = this.UpdateData();
            if (up.RowsAffected == 0)
                throw new Exception(string.Format("Cards record {0} was not updated successfully. Reason unknown.", GetPrimaryKeyValues()));
        }

        public virtual void Insert()
        {
            ValidateFields();
            this.InsertData();
        }
        
        public virtual void InsertOrUpdate()
        {
            if (this.RecordExists)
                this.Update();
            else
                this.Insert();
        }        

        public string GetPrimaryKeyValues()
        {
            string pkValues = "PK:[";
            pkValues += "ID=" + ID.ToString();
            return pkValues + "]";
        }}
}
