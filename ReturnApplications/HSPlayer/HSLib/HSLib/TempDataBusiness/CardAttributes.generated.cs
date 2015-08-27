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
    public partial class CardAttributes : Data.CardAttributesData
    {
        #region ALL FOREIGN TABLE MEMBERS
        private static AttributeTypesList _attributeTypeMemberList = new AttributeTypesList();
		private AttributeTypes _attributeTypeMember;
		[System.Xml.Serialization.XmlIgnore]
		public AttributeTypes AttributeTypeMember
		{
		    get
		    {
		        if (_attributeTypeMember == null || _attributeTypeMember.ID != this.AttributeType)
		            _attributeTypeMember = _attributeTypeMemberList.GetByPrimaryKey(this.AttributeType);
		        return _attributeTypeMember;
		    }
		    set { _attributeTypeMember = value; }
		}

		        
        #endregion

        public CardAttributes(int iD)
        {
            PrepareBeforeConstruction();
            this.LoadItem(iD);
            FinishAfterConstruction();
        }

        public CardAttributes(Properties.CardAttributesProperties properties)
        {
            PrepareBeforeConstruction();
            this.SetProperties(properties);
            FinishAfterConstruction();
        }
       
        public CardAttributes(string name, string description, int attributeType)
        {
            PrepareBeforeConstruction();
            
			this.Name = name;
			this.Description = description;
			this.AttributeType = attributeType;
			
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
        
        private void SetProperties(Properties.CardAttributesProperties properties)
        {
            this.ID = properties.ID;
			this.Name = properties.Name;
			this.Description = properties.Description;
			this.AttributeType = properties.AttributeType;
			this.RecordExists = properties.RecordExists;

        }
    }
}
