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
    public partial class DeckBuilderForm : Form
    {
        const int _neutralHero = 10;
        Processors.DeckBuilderProcessor _processor;

        public DeckBuilderForm()
        {
            InitializeComponent();
            Load += DecksForm_Load;
        }

        private void DecksForm_Load(object sender, EventArgs e)
        {
            _processor = new Processors.DeckBuilderProcessor();
            DataSourceSet_All(false);
        }

        void DataSourceSet_All(bool resetOnly = true)
        {
            DataSourceSet_BindingSourceHeroesList(resetOnly);

            if (_processor != null && ComboBoxHeroesList.Items.Count > 0 && ComboBoxHeroesList.SelectedIndex > -1)
                DataSourceSet_BindingSourceCardsList((int)ComboBoxHeroesList.SelectedValue, false);
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
                BindingSourceCardsList.DataSource = _processor.CardsList.FindAll(x => x.Hero == hero || x.Hero == _neutralHero);
            }

            BindingSourceCardsList.ResetBindings(false);
        }

        private void ComboBoxHeroesList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_processor != null && ComboBoxHeroesList.Items.Count > 0 && ComboBoxHeroesList.SelectedIndex > -1)
                DataSourceSet_BindingSourceCardsList((int)ComboBoxHeroesList.SelectedValue, false);
        }

        private void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //DataSourceSet_BindingSourceCardsList(TextBoxSearch.Text,  )
            }
        }

        //private bool ComboBoxHeroesListBoxPassCondition
    }
}
