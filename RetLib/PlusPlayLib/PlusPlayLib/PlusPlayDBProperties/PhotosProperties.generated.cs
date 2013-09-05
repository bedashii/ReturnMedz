using System;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/

namespace PlusPlayDBGenLib.Properties
{
    public partial class PhotosProperties : PropertiesBase
    {
		partial void OnIDChanging();
		partial void OnIDChanged();
		protected int _iD;
		public virtual int ID
		{
			get { return _iD; }
			set
			{
				OnIDChanging();
				_iD = value;
				base.AnyPropertyChanged = true;
				OnIDChanged();
			}
		}

		partial void OnGalleryChanging();
		partial void OnGalleryChanged();
		protected int _gallery;
		public virtual int Gallery
		{
			get { return _gallery; }
			set
			{
				OnGalleryChanging();
				_gallery = value;
				base.AnyPropertyChanged = true;
				OnGalleryChanged();
			}
		}

		partial void OnPhotoFileChanging();
		partial void OnPhotoFileChanged();
		protected string _photoFile;
		public virtual string PhotoFile
		{
			get { return _photoFile; }
			set
			{
				OnPhotoFileChanging();
				_photoFile = value;
				base.AnyPropertyChanged = true;
				OnPhotoFileChanged();
			}
		}

    }
}