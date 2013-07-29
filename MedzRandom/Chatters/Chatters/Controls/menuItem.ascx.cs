using System;
using System.Drawing;

namespace Chatters.Controls
{
    public partial class menuItem : System.Web.UI.UserControl
    {
        public string Title
        {
            get
            {
                return labelTitle.Text;
            }
            set
            {
                labelTitle.Text = value;
            }
        }

        public string Price
        {
            get
            {
                return labelPrice.Text;
            }
            set
            {
                labelPrice.Text = value;
            }
        }

        public string Description
        {
            get
            {
                return labelDescription.Text;
            }
            set
            {
                labelDescription.Text = value;
            }
        }

        public string ImagePlaceHolder
        {
            get { return imagePlaceHolder.ImageUrl; }
            set { imagePlaceHolder.ImageUrl = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}