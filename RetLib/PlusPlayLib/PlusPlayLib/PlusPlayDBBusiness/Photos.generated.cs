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
    public partial class Photos : Data.PhotosData
    {
        #region ALL FOREIGN TABLE MEMBERS
        private static GalleriesList _galleryMemberList = new GalleriesList();
		private Galleries _galleryMember;
		[System.Xml.Serialization.XmlIgnore]
		public Galleries GalleryMember
		{
		    get
		    {
		        if (_galleryMember == null || _galleryMember.ID != this.Gallery)
		            _galleryMember = _galleryMemberList.GetByPrimaryKey(this.Gallery);
		        return _galleryMember;
		    }
		    set { _galleryMember = value; }
		}

		        
        #endregion

        public Photos(int iD)
        {
            PrepareBeforeConstruction();
            this.LoadItem(iD);
            FinishAfterConstruction();
        }

        public Photos(Properties.PhotosProperties properties)
        {
            PrepareBeforeConstruction();
            this.SetProperties(properties);
            FinishAfterConstruction();
        }
       
        public Photos(int gallery, string photoFile)
        {
            PrepareBeforeConstruction();
            
			this.Gallery = gallery;
			this.PhotoFile = photoFile;
			
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
        
        private void SetProperties(Properties.PhotosProperties properties)
        {
            this.ID = properties.ID;
			this.Gallery = properties.Gallery;
			this.PhotoFile = properties.PhotoFile;
			this.RecordExists = properties.RecordExists;

        }
    }
}
