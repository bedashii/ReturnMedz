using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlusPlay.UIControls
{
    public delegate PlusPlayLib.List.ModelList UIListBoxDouble_SetListBoxMain();
    public delegate PlusPlayLib.List.GalleryList UIListBoxDouble_SetListBoxSub(PlusPlayLib.Bus.Model Model);
    public delegate void UIListBoxDouble_SubSelectedValueChanged(PlusPlayLib.Bus.Gallery Gallery);

    public partial class UIListBoxDouble : UserControl
    {
        public event UIListBoxDouble_SetListBoxMain ListBoxMain_Set;
        public event UIListBoxDouble_SetListBoxSub ListBoxSub_Set;
        public event UIListBoxDouble_SubSelectedValueChanged SubListBox_SelectedValueChanged;

        int _downPosition;
        bool _mouseDown;

        public UIListBoxDouble()
        {
            InitializeComponent();
            SplitContainerMain.Panel2Collapsed = true;
        }

        public void SetListBoxMain(PlusPlayLib.List.ModelList items)
        {
            //if (items.Count > 0)
            //{
            //    ListBoxMain.Items.Clear();

            //    foreach (PlusPlayLib.Bus.Model item in items)
            //        ListBoxMain.Items.Add(item);

            //    ListBoxMain.SelectedIndex = 0;
            //}

            modelListBindingSource.DataSource = items;
        }

        void SetListBoxSub(PlusPlayLib.List.GalleryList items)
        {
            //if (items.Count > 0)
            //{
            //    ListBoxSub.Items.Clear();

            //    foreach (string item in items)
            //        ListBoxSub.Items.Add(item);

            //    ListBoxSub.SelectedIndex = 0;
            //}
            galleryListBindingSource.DataSource = items;
        }

        #region ControlEvents

        private void ListBoxMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ListBoxMain.SelectedItem != null)
            {
                SplitContainerMain.Panel1Collapsed = true;
                SetListBoxSub(ListBoxSub_Set((PlusPlayLib.Bus.Model) ListBoxMain.SelectedItem));
            }
        }

        private void ListBoxMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ListBoxMain.SelectedItem != null)
            {
                SplitContainerMain.Panel1Collapsed = true;
                SetListBoxSub(ListBoxSub_Set((PlusPlayLib.Bus.Model)ListBoxMain.SelectedItem));
            }
        }

        private void ListBoxSub_MouseDown(object sender, MouseEventArgs e)
        {
            _downPosition = e.X;
            _mouseDown = true;
        }

        private void ListBoxSub_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseDown && (_downPosition - e.X > 60))
            {
                SetListBoxMain(ListBoxMain_Set());
                SplitContainerMain.Panel2Collapsed = true;
            }
        }

        private void ListBoxSub_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
        }

        private void ListBoxSub_Leave(object sender, EventArgs e)
        {
            _mouseDown = false;
        }

        private void ListBoxSub_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ListBoxSub.SelectedIndex > -1)
                SubListBox_SelectedValueChanged((PlusPlayLib.Bus.Gallery)ListBoxSub.SelectedItem);
        }

        #endregion ControlEvents
    }
}
