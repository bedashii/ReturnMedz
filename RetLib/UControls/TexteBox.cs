using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crack
{
    public partial class TexteBox : UserControl
    {
        public override string Text
        {
            get
            {
                return TextBoxText.Text;
            }
            set
            {
                TextBoxText.Text = value;
            }
        }

        public string PreText
        {
            get
            {
                return LabelPreText.Text;
            }
            set
            {
                LabelPreText.Text = value;
            }
        }

        public EventHandler TextChanged;
        

        public TexteBox()
        {
            InitializeComponent();

            TextBoxText.Location = new Point(0, 0);
            LabelPreText.Location = new Point(4, 3);

            Size = new System.Drawing.Size(TextBoxText.Width, TextBoxText.Height);
            
        }

        private void TexteBox_Resize(object sender, EventArgs e)
        {
            TextBoxText.Size = new Size(Width, Height);
            Size = new Size(Width, TextBoxText.Height);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LabelPreText.Visible = TextBoxText.Text.Length == 0;
        }

        private void textBox1_SizeChanged(object sender, EventArgs e)
        {
            Size = new Size(Width, TextBoxText.Height);
        }


    }
}
