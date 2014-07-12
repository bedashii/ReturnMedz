using System;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/

namespace PlusPlayDBGenLib.Properties
{
    public partial class GalleriesProperties : PropertiesBase
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

		partial void OnModelChanging();
		partial void OnModelChanged();
		protected int _model;
		public virtual int Model
		{
			get { return _model; }
			set
			{
				OnModelChanging();
				_model = value;
				base.AnyPropertyChanged = true;
				OnModelChanged();
			}
		}

		partial void OnGalleryNameChanging();
		partial void OnGalleryNameChanged();
		protected string _galleryName;
		public virtual string GalleryName
		{
			get { return _galleryName; }
			set
			{
				OnGalleryNameChanging();
				_galleryName = value;
				base.AnyPropertyChanged = true;
				OnGalleryNameChanged();
			}
		}

		partial void OnGalleryDirectoryChanging();
		partial void OnGalleryDirectoryChanged();
		protected string _galleryDirectory;
		public virtual string GalleryDirectory
		{
			get { return _galleryDirectory; }
			set
			{
				OnGalleryDirectoryChanging();
				_galleryDirectory = value;
				base.AnyPropertyChanged = true;
				OnGalleryDirectoryChanged();
			}
		}

		partial void OnCoverPhotoChanging();
		partial void OnCoverPhotoChanged();
		protected string _coverPhoto;
		public virtual string CoverPhoto
		{
			get { return _coverPhoto; }
			set
			{
				OnCoverPhotoChanging();
				_coverPhoto = value;
				base.AnyPropertyChanged = true;
				OnCoverPhotoChanged();
			}
		}

    }
}