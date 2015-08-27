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

        void CardsForm_Load(object sender, EventArgs e)
        {
            _processor = new Processors.CardsProcessor();
            DataSourceSet_BindingSourcecardsListBindingSource1(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSourceSet_BindingSourcecardsListBindingSource1();
        }


        void DataSourceSet_BindingSourcecardsListBindingSource1(bool resetOnly = true)
        {
            _processor.Refresh();

            if (resetOnly == false)
            {
                cardsListBindingSource1.DataSource = _processor.CardsList;
            }

            cardsListBindingSource1.ResetBindings(false);
        }

        private void TimerRefresh_Tick(object sender, EventArgs e)
        {
            DataSourceSet_BindingSourcecardsListBindingSource1();
        }

    }
}
