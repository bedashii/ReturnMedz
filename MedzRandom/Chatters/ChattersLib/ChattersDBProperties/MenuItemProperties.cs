
namespace ChattersLib.ChattersDBProperties
{
    public class MenuItemProperties : PropertiesBase
    {
        private int id;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                if (id != value)
                {
                    id = value;

                    if (RecordsExists)
                        AnyPropertyChanged = true;
                }
            }
        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (title != value)
                {
                    title = value;
                    if (RecordsExists)
                        AnyPropertyChanged = true;
                }
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (description != value)
                {
                    description = value;
                    if (RecordsExists)
                        AnyPropertyChanged = true;
                }
            }
        }

        private decimal price;
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (price != value)
                {
                    price = value;
                    if (RecordsExists)
                        AnyPropertyChanged = true;
                }
            }
        }

        private int menu;
        public int Menu
        {
            get
            {
                return menu;
            }
            set
            {
                if (menu != value)
                {
                    menu = value;
                    if (RecordsExists)
                        AnyPropertyChanged = true;
                }
            }
        }
    }
}