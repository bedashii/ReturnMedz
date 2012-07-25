/* Another column needs to be added to age restriction (A something like they way there's an ExtensionType and then ExtensionDescription.
 * Before, that can be completed however PropGen needs to fixed as this is a great opportunity to see if it works 100%.
 * Build a stand-alone control for searching for a movie and displaying the results.
 * Once ^^ is built, the movie add control can be started using the result set of ^^ control.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReturnMovieManagerWF.Controls
{
    public partial class PreferencesControl : UserControl
    {
        private Processors.PreferencesProcessor _processor;
        private ButtonPanelObject BPOAgeRating;
        private ButtonPanelObject BPOAudioQuality;
        private ButtonPanelObject BPOExtension;
        private ButtonPanelObject BPOGenre;
        private ButtonPanelObject BPOVideoQuality;
        private List<ButtonPanelObject> BPOList;

        public PreferencesControl()
        {
            InitializeComponent();
            _processor = new Processors.PreferencesProcessor();
            SetButtonPanelObjects();
        }

        private void SetButtonPanelObjects()
        {
            BPOAgeRating = new ButtonPanelObject(ButtonAgeRatingEdit, ButtonAgeRatingCancel, ButtonAgeRatingDelete,ButtonAgeRatingSave, DGVAgeRatingType);
            BPOAudioQuality = new ButtonPanelObject(ButtonAudioQualityEdit, ButtonAudioQualityCancel, ButtonAudioQualityDelete, ButtonAudioQualitySave, DGVAudoQualityType);
            BPOExtension = new ButtonPanelObject(ButtonExtensionEdit, ButtonExtensionCancel, ButtonExtensionDelete, ButtonExtensionSave, DGVExtensionType);
            BPOGenre = new ButtonPanelObject(ButtonGenreEdit, ButtonGenreCancel, ButtonGenreDelete, ButtonGenreSave, DGVGenreType);
            BPOVideoQuality = new ButtonPanelObject(ButtonVideoQualityEdit, ButtonVideoQualityCancel, ButtonVideoQualityDelete, ButtonVideoQualitySave, DGVVideoQualityType);

            BPOList = new List<ButtonPanelObject>();
            BPOList.Add(BPOAgeRating);
            BPOList.Add(BPOAudioQuality);
            BPOList.Add(BPOExtension);
            BPOList.Add(BPOGenre);
            BPOList.Add(BPOVideoQuality);

            foreach (ButtonPanelObject bpo in BPOList)
                SetEditMode(false, bpo);
        }

        private void LoadDataSources()
        {
            ageRatingTypeBindingSource.DataSource = _processor.AgeRatingTypeList;
            audioQualityTypeBindingSource.DataSource = _processor.AudioQualityTypeList;
            extensionTypeBindingSource.DataSource = _processor.ExtensionTypeList;
            genreTypesBindingSource.DataSource = _processor.GenreTypesList;
            videoQualityTypeBindingSource.DataSource = _processor.VideoQualityTypeList;

            _processor.RefreshAllLists();

            ageRatingTypeBindingSource.ResetBindings(false);
            audioQualityTypeBindingSource.ResetBindings(false);
            extensionTypeBindingSource.ResetBindings(false);
            genreTypesBindingSource.ResetBindings(false);
            videoQualityTypeBindingSource.ResetBindings(false);
        }

        private void SetEditMode(bool editMode, ButtonPanelObject bpo)
        {
            if (editMode)
            {
                bpo.ButtonEdit.Enabled = false;
                bpo.ButtonCancel.Enabled = bpo.ButtonSave.Enabled = true;
                bpo.DataGridView.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                bpo.DataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }
            else
            {
                bpo.ButtonEdit.Enabled = true;
                bpo.ButtonCancel.Enabled = bpo.ButtonSave.Enabled = false;
                bpo.DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
                bpo.DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (b.Name.Contains("AgeRating"))
                SetEditMode(true, BPOAgeRating);
            else if (b.Name.Contains("AudioQuality"))
                SetEditMode(true, BPOAudioQuality);
            else if (b.Name.Contains("Extension"))
                SetEditMode(true, BPOExtension);
            else if (b.Name.Contains("Genre"))
                SetEditMode(true, BPOGenre);
            else if (b.Name.Contains("VideoQuality"))
                SetEditMode(true, BPOVideoQuality);
        }

        private void ButtonSaveCancel_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (b.Name.Contains("Save"))
                _processor.UpdateLists(b.Name);

            if (b.Name.Contains("AgeRating"))
                SetEditMode(false, BPOAgeRating);
            else if (b.Name.Contains("AudioQuality"))
                SetEditMode(false, BPOAudioQuality);
            else if (b.Name.Contains("Extension"))
                SetEditMode(false, BPOExtension);
            else if (b.Name.Contains("Genre"))
                SetEditMode(false, BPOGenre);
            else if (b.Name.Contains("VideoQuality"))
                SetEditMode(false, BPOVideoQuality);
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Really?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                Button b = (Button)sender;
                DataGridView dgv = BPOList.Find(x => x.ButtonDelete.Name == b.Name).DataGridView;

                _processor.DeleteItem(b.Name, Convert.ToInt32(dgv[0, dgv.SelectedRows[0].Index].Value));

                LoadDataSources();
            }
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadDataSources();
        }

        private void PreferencesControl_Load(object sender, EventArgs e)
        {
            //_processor = new Processors.PreferencesProcessor();
            //SetButtonPanelObjects();
            //LoadDataSources();
        }
    }

    public class ButtonPanelObject
    {
        public ButtonPanelObject(Button buttonEdit, Button buttonCancel, Button buttonDelete, Button buttonSave, DataGridView dataGridView)
        {
            ButtonEdit = buttonEdit;
            ButtonCancel = buttonCancel;
            ButtonDelete = buttonDelete;
            ButtonSave = buttonSave;
            DataGridView = dataGridView;
        }

        public Button ButtonEdit { get; set; }
        public Button ButtonCancel { get; set; }
        public Button ButtonDelete { get; set; }
        public Button ButtonSave { get; set; }
        public DataGridView DataGridView { get; set; }
    }
}
