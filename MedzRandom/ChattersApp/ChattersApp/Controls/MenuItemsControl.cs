﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChattersApp.Controls
{
    public partial class MenuItemsControl : UserControl
    {
        ChattersLib.ChattersDBLists.MenuItemList menuItemList = null;
        ChattersLib.ChattersDBLists.MenuList menuList = null;
        ChattersLib.ChattersDBLists.MenuList menuListFilter = null;

        public MenuItemsControl()
        {
            InitializeComponent();

            menuList = new ChattersLib.ChattersDBLists.MenuList();
            menuList.GetAll();

            menuListFilter = new ChattersLib.ChattersDBLists.MenuList();
            menuListFilter.Insert(0, new ChattersLib.ChattersDBBusiness.Menu() { ID = 0, Title = "All" });

            menuList.ForEach(x =>
                {
                    menuListFilter.Add(x);
                });

            menuList.Insert(0, new ChattersLib.ChattersDBBusiness.Menu() { ID = 0, Title = "None" });

            menuListBindingSource.DataSource = menuList;
            menuListBindingSourceFilter.DataSource = menuListFilter;

            menuItemList = new ChattersLib.ChattersDBLists.MenuItemList();
            menuItemList.GetAll();
            ConvertToView();

            menuItemListBindingSource.DataSource = menuItemList;
        }

        private void MenuItemsControl_Load(object sender, EventArgs e)
        {
            menuList = new ChattersLib.ChattersDBLists.MenuList();
            menuList.GetAll();

            menuListFilter = new ChattersLib.ChattersDBLists.MenuList();
            menuListFilter.Insert(0, new ChattersLib.ChattersDBBusiness.Menu() { ID = 0, Title = "All" });

            menuList.ForEach(x =>
            {
                menuListFilter.Add(x);
            });

            menuList.Insert(0, new ChattersLib.ChattersDBBusiness.Menu() { ID = 0, Title = "None" });

            menuListBindingSource.DataSource = menuList;
            menuListBindingSourceFilter.DataSource = menuListFilter;

            menuItemList = new ChattersLib.ChattersDBLists.MenuItemList();
            menuItemList.GetAll();
            ConvertToView();

            menuItemListBindingSource.DataSource = menuItemList;

            refresh();
        }

        private void ConvertToSave()
        {
            menuItemList.ForEach(x =>
            {
                x.Description = x.Description.Replace("\r\n", "<BR>");
                x.Description = x.Description.Replace("\u2022", "&bull;");

            });
        }

        private void ConvertToView()
        {
            menuItemList.ForEach(x =>
            {
                x.Description = x.Description.Replace("<BR>", "\r\n");
                x.Description = x.Description.Replace("&bull;", "\u2022");
            });
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ConvertToSave();
            menuItemList.UpdateAll();

            menuItemList.GetAll();
            ConvertToView();

            menuItemListBindingSource.DataSource = menuItemList;

            refresh();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            int menu = 0;
            if (menuItemListBindingSource.Current != null)
                menu = ((ChattersLib.ChattersDBBusiness.MenuItem)menuItemListBindingSource.Current).Menu;
            menuItemList.Add((ChattersLib.ChattersDBBusiness.MenuItem)menuItemListBindingSource.AddNew());

            ((ChattersLib.ChattersDBBusiness.MenuItem)menuItemListBindingSource.Current).Menu = menu;
        }

        private void dataGridViewMenuItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewMenuItems.Columns["buttonDelete"].Index)
            {
                if (MessageBox.Show("Are you sure you wish to delete the selected Menu Item?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Delete Current row.
                    ChattersLib.ChattersDBBusiness.MenuItem mi = ((ChattersLib.ChattersDBBusiness.MenuItem)dataGridViewMenuItems.Rows[e.RowIndex].DataBoundItem);
                    if (mi.RecordsExists)
                        mi.Delete();

                    menuItemList.Remove(mi);

                    menuItemListBindingSource.ResetBindings(false);
                }
            }
        }

        private void menuItemListBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (menuItemListBindingSource.Current != null)
            {
                ChattersLib.ChattersDBBusiness.MenuItem mi = (ChattersLib.ChattersDBBusiness.MenuItem)menuItemListBindingSource.Current;

                if (mi.Menu != null)
                {
                    ChattersLib.ChattersDBBusiness.Menu m = menuList.Find(x => x.ID == mi.Menu);
                    if (m != null)
                        comboBoxMenu.SelectedItem = m;
                }
            }
        }

        private void comboBoxMenu_SelectedValueChanged(object sender, EventArgs e)
        {
            if (menuItemListBindingSource.Current != null)
            {
                ChattersLib.ChattersDBBusiness.MenuItem mi = (ChattersLib.ChattersDBBusiness.MenuItem)menuItemListBindingSource.Current;

                if (comboBoxMenu.SelectedItem != null)
                {
                    mi.Menu = Convert.ToInt32(comboBoxMenu.SelectedValue);
                    menuItemListBindingSource.ResetBindings(false);
                }
            }
        }

        private void comboBoxMenuListFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            if (comboBoxMenuListFilter.SelectedItem != null)
            {
                menuItemListBindingSource.DataSource = getMenuItems(comboBoxMenuListFilter.SelectedValue.ToString(), textBoxSearch.Text);
            }
            else
                menuItemListBindingSource.DataSource = getMenuItems("All", textBoxSearch.Text);
            menuItemListBindingSource.ResetBindings(false);
        }

        private ChattersLib.ChattersDBLists.MenuItemList getMenuItems(string menu, string menuItem)
        {
            ChattersLib.ChattersDBLists.MenuItemList mil = new ChattersLib.ChattersDBLists.MenuItemList();
            menuItemList.ForEach(x =>
            {
                if ((menu == "All" || x.MenuTitle == menu) && (menuItem == "" || x.Title.Contains(menuItem)))
                    mil.Add(x);
            });

            return mil;
        }

        internal void ResetMenus()
        {
            menuList = new ChattersLib.ChattersDBLists.MenuList();
            menuList.GetAll();
            menuList.Insert(0, new ChattersLib.ChattersDBBusiness.Menu() { ID = 0, Title = "None" });

            menuListBindingSource.DataSource = menuList;
        }

        private void buttonBullet_Click(object sender, EventArgs e)
        {
            int selectionIndex = textBoxDescription.SelectionStart;
            textBoxDescription.Text = textBoxDescription.Text.Insert(selectionIndex, "\u2022");
            textBoxDescription.SelectionStart = selectionIndex + "\u2022".Length;
        }
    }
}