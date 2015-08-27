using System;
using System.Windows.Forms;

namespace HSPlayer
{
    public partial class DecksForm : Form
    {
        Processors.DecksProcessor _processor;

        public DecksForm()
        {
            InitializeComponent();
            Load += DecksForm_Load;
        }

        private void DecksForm_Load(object sender, EventArgs e)
        {
            _processor = new Processors.DecksProcessor();
            DataSourceSet_All(false);
        }

        void DataSourceSet_All(bool resetOnly = true)
        {
            DataSourceSet_BindingSourceDecksList(resetOnly);

            if (_processor != null && ListBoxDecks.Items.Count > 0 && ListBoxDecks.SelectedIndex > -1)
                DataSourceSet_BindingSourceDeckCardsList((int)ListBoxDecks.SelectedValue, resetOnly);
        }

        void DataSourceSet_BindingSourceDecksList(bool resetOnly = true)
        {
            if (resetOnly == false)
            {
                BindingSourceDecksList.DataSource = _processor.DecksList;
            }

            BindingSourceDecksList.ResetBindings(false);
        }

        void DataSourceSet_BindingSourceDeckCardsList(int deck, bool resetOnly = true)
        {
            if (resetOnly == false)
            {
                BindingSourceDeckCardsList.DataSource = _processor.DeckCardsList.FindAll(x => x.Deck == deck);
            }

            BindingSourceDeckCardsList.ResetBindings(false);
        }

        private void ListBoxDecks_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_processor != null && ListBoxDecks.Items.Count > 0 && ListBoxDecks.SelectedIndex > -1)
            {
                DataSourceSet_BindingSourceDeckCardsList((int)ListBoxDecks.SelectedValue, false);
            }
        }
    }
}
