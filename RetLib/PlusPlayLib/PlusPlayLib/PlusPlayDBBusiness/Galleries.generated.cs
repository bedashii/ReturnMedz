using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlusPlayDBGenLib.Lists;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/


namespace PlusPlayDBGenLib.Business
{
    public partial class Galleries : Data.GalleriesData
    {
        #region ALL FOREIGN TABLE MEMBERS
        private static ModelsList _modelMemberList = new ModelsList();
		private Models _modelMember;
		[System.Xml.Serialization.XmlIgnore]
		public Models ModelMember
		{
		    get
		    {
		        if (_modelMember == null || _modelMember.ID != this.Model)
		            _modelMember = _modelMemberList.GetByPrimaryKey(this.Model);
		        return _modelMember;
		    }
		    set { _modelMember = value; }
		}

		        
        #endregion

        public Galleries(int iD)
        {
            PrepareBeforeConstruction();
            this.LoadItem(iD);
            FinishAfterConstruction();
        }

        public Galleries(Properties.GalleriesProperties properties)
        {
            PrepareBeforeConstruction();
            this.SetProperties(properties);
            FinishAfterConstruction();
        }
       
        public Galleries(int model, string galleryName, string coverPhoto)
        {
            PrepareBeforeConstruction();
            
			this.Model = model;
			this.GalleryName = galleryName;
			this.CoverPhoto = coverPhoto;
			
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
        
        private void SetProperties(Properties.GalleriesProperties properties)
        {
            this.ID = properties.ID;
			this.Model = properties.Model;
			this.GalleryName = properties.GalleryName;
			this.CoverPhoto = properties.CoverPhoto;
			this.RecordExists = properties.RecordExists;

        }
    }
}
