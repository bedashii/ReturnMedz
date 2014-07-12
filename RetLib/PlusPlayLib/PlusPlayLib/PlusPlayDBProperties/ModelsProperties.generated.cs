using System;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/

namespace PlusPlayDBGenLib.Properties
{
    public partial class ModelsProperties : PropertiesBase
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

		partial void OnModelNameChanging();
		partial void OnModelNameChanged();
		protected string _modelName;
		public virtual string ModelName
		{
			get { return _modelName; }
			set
			{
				OnModelNameChanging();
				_modelName = value;
				base.AnyPropertyChanged = true;
				OnModelNameChanged();
			}
		}

		partial void OnModelDirectoryChanging();
		partial void OnModelDirectoryChanged();
		protected string _modelDirectory;
		public virtual string ModelDirectory
		{
			get { return _modelDirectory; }
			set
			{
				OnModelDirectoryChanging();
				_modelDirectory = value;
				base.AnyPropertyChanged = true;
				OnModelDirectoryChanged();
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