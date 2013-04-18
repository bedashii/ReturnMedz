using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlusPlay
{
    public partial class PlusPlayForm : Form
    {
        PlusPlayProcessor _processor;

        public PlusPlayForm()
        {
            InitializeComponent();
            _processor = new PlusPlayProcessor();
            _processor.SetModelList();

            InitialModelLoad();
        }

        private void InitialModelLoad()
        {
            ListBoxModelGallerySelection.SetListBoxMain(_processor.GetModelList());

            ButtonImport.SetButtonImage(@"C:\Users\bedashii\Documents\Visual Studio 2012\Projects\PlusPlay\PlusPlay\icons\Import.png");
            ButtonSave.SetButtonImage(@"C:\Users\bedashii\Documents\Visual Studio 2012\Projects\PlusPlay\PlusPlay\icons\Save.png");
            ButtonDiscard.SetButtonImage(@"C:\Users\bedashii\Documents\Visual Studio 2012\Projects\PlusPlay\PlusPlay\icons\Discard.png");

            ButtonImport.ButtonPressed += ButtonImport_ButtonPressed;
            ButtonSave.ButtonPressed += ButtonSave_ButtonPressed;
            ButtonDiscard.ButtonPressed += ButtonDiscard_ButtonPressed;

            WUIControlBoxPlusPlay.ControlActivated += WUIControlBoxPlusPlay_ControlActivated;
        }

        void WUIControlBoxPlusPlay_ControlActivated(WUIControls.WUIControlBoxCommand Command)
        {
            switch (Command)
            {
                case WUIControls.WUIControlBoxCommand.Min:
                    this.WindowState = FormWindowState.Minimized;
                    break;
                case WUIControls.WUIControlBoxCommand.Max:
                    this.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
                    break;
                default:
                    this.Close();
                    break;
            }
        }

        void ButtonDiscard_ButtonPressed()
        {
            throw new NotImplementedException();
        }

        void ButtonSave_ButtonPressed()
        {
            throw new NotImplementedException();
        }

        void ButtonImport_ButtonPressed()
        {
            throw new NotImplementedException();
        }

        public PlusPlayLib.List.ModelList ListBoxModelGallerySelection_ListBoxMain_Set()
        {
            if (_processor.ModelCount > 0)
                return _processor.GetModelList();
            else
                return null;
        }

        public PlusPlayLib.List.GalleryList ListBoxModelGallerySelection_ListBoxSub_Set(PlusPlayLib.Bus.Model Model)
        {
            TextBoxModel.Text = Model.ModelName;
            TextBoxGallery.Clear();

            return _processor.GetGalleryList(Model);
        }

        private void ListBoxModelGallerySelection_SubListBox_SelectedValueChanged(PlusPlayLib.Bus.Gallery Gallery)
        {
            TextBoxGallery.Text = Gallery.GalleryName;

            try
            {
                PicturePanelMain.SetGallery(Gallery, false);
            }
            catch (Exception) { }
        }
    }
}
