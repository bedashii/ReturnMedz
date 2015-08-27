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
    public partial class CardCaptureForm : Form
    {
        Processors.CardCaptureProcessor _processor;

        public CardCaptureForm()
        {
            InitializeComponent();
            Load += CardCaptureForm_Load;
        }

        void CardCaptureForm_Load(object sender, EventArgs e)
        {
            _processor = new Processors.CardCaptureProcessor();
            DataSourceSet_All(false);
        }


        void DataSourceSet_All(bool resetOnly = true)
        {
            DataSourceSet_BindingSourceCardsList(resetOnly);
            DataSourceSet_BindingSourceCard(resetOnly);
        }

        void DataSourceSet_BindingSourceCardsList(bool resetOnly = true)
        {
            if (resetOnly == false)
            {
                cardsListBindingSource1.DataSource = _processor.CardsList;
            }

            cardsListBindingSource1.ResetBindings(false);
        }

        void DataSourceSet_BindingSourceCard(bool resetOnly = true)
        {
            if (resetOnly == false)
            {
                cardsBindingSource.DataSource = _processor.Card;
            }

            cardsBindingSource.ResetBindings(false);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            _processor.AddCard();
            DataSourceSet_All();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _processor.EditCard();
            DataSourceSet_All();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _processor.SaveCards();
            DataSourceSet_All();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _processor.CancelEdit();
            DataSourceSet_All();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter && e.Modifiers == Keys.None)
            //{
            //    _processor.SaveCards();
            //    DataSourceSet_All();
            //}
            //else if (e.KeyCode == Keys.Escape)
            //{
            //    _processor.CancelEdit();
            //    DataSourceSet_All();
            //}
            //else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            //{
            //    _processor.AddCard();
            //    DataSourceSet_BindingSourceCardsList();
            //}
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType() == typeof(TextBox))
                    (sender as TextBox).SelectAll();
                else if (sender.GetType() == typeof(NumericUpDown))
                    (sender as NumericUpDown).Select(0, 1);
            }
            catch (Exception)
            {
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _processor.DeleteCard((TempDataGenLib.Business.Cards)dataGridView1.SelectedRows[0].DataBoundItem);
            DataSourceSet_All();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            cardsBindingSource.DataSource = (TempDataGenLib.Business.Cards)dataGridView1.SelectedRows[0].DataBoundItem;
            cardsBindingSource.ResetBindings(false);
        }
    }
}
