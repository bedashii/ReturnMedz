using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TempDataGenLib.Lists;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/


namespace TempDataGenLib.Business
{
    public partial class AttributeTypes : Data.AttributeTypesData
    {
        #region ALL FOREIGN TABLE MEMBERS
        private static GameAreasList _gameAreaMemberList = new GameAreasList();
		private GameAreas _gameAreaMember;
		[System.Xml.Serialization.XmlIgnore]
		public GameAreas GameAreaMember
		{
		    get
		    {
		        if (_gameAreaMember == null || _gameAreaMember.ID != this.GameArea)
		            _gameAreaMember = _gameAreaMemberList.GetByPrimaryKey(this.GameArea);
		        return _gameAreaMember;
		    }
		    set { _gameAreaMember = value; }
		}

		        
        #endregion

        public AttributeTypes(int iD)
        {
            PrepareBeforeConstruction();
            this.LoadItem(iD);
            FinishAfterConstruction();
        }

        public AttributeTypes(Properties.AttributeTypesProperties properties)
        {
            PrepareBeforeConstruction();
            this.SetProperties(properties);
            FinishAfterConstruction();
        }
       
        public AttributeTypes(string name, string description, int gameArea)
        {
            PrepareBeforeConstruction();
            
			this.Name = name;
			this.Description = description;
			this.GameArea = gameArea;
			
            FinishAfterConstruction();
        }
        
        public void LoadItem(int iD)
        {
            this.ID = iD;
			
            base.LoadItemData(iD);
        }
        
        
        public void Refresh()
        {
            base.LoadItemData(this.ID);
        }
        
        private void SetProperties(Properties.AttributeTypesProperties properties)
        {
            this.ID = properties.ID;
			this.Name = properties.Name;
			this.Description = properties.Description;
			this.GameArea = properties.GameArea;
			this.RecordExists = properties.RecordExists;

        }
    }
}
