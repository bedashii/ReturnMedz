using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HSPlayer
{
    public partial class CardsForm : Form
    {
        Processors.CardsProcessor _processor;

        public CardsForm()
        {
            InitializeComponent();
            Load += CardsForm_Load;
        }

        private void CardsForm_Load(object sender, EventArgs e)
        {
            _processor = new Processors.CardsProcessor();
            _processor.Refresh();
            DataSourceSet_All(false);
        }

        void DataSourceSet_All(bool resetOnly = true)
        {
            if (ListBoxHeroes.Items.Count > 0 && ListBoxHeroes.SelectedIndex > -1)
                DataSourceSet_BindingSourceCardsList((int)ListBoxHeroes.SelectedValue, resetOnly);
            else
                DataSourceSet_BindingSourceCardsList(0, resetOnly);

            DataSourceSet_BindingSourceHeroesList(resetOnly);
        }

        void DataSourceSet_BindingSourceHeroesList(bool resetOnly = true)
        {
            if (resetOnly == false)
            {
                BindingSourceHeroesList.DataSource = _processor.HeroesList;
            }

            BindingSourceHeroesList.ResetBindings(false);
        }


        void DataSourceSet_BindingSourceCardsList(int hero, bool resetOnly = true)
        {
            if (resetOnly == false)
            {
                if (hero == 0)
                    BindingSourceCardsList.DataSource = _processor.CardsList;
                else
                    BindingSourceCardsList.DataSource = _processor.CardsList.FindAll(x => x.Hero == hero);
            }

            BindingSourceCardsList.ResetBindings(false);
        }

        private void ListBoxHeroes_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_processor != null && _processor.HeroesList.Count > 0 && ListBoxHeroes.SelectedIndex > -1)
            {
                if (ListBoxHeroes.SelectedIndex == 0)
                    DataSourceSet_BindingSourceCardsList(0, false);
                else
                    DataSourceSet_BindingSourceCardsList((int)ListBoxHeroes.SelectedValue, false);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            _processor.Save();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            _processor.Refresh();
            DataSourceSet_All();
        }

        private void ButtonDecks_Click(object sender, EventArgs e)
        {
            var decksForm = new DecksForm();
            decksForm.ShowDialog();
        }

        private void ButtonBuilder_Click(object sender, EventArgs e)
        {
            var deckBuilderForm = new DeckBuilderForm();
            deckBuilderForm.ShowDialog();
        }
    }
}
