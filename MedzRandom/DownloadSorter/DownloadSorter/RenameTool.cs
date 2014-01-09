using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace DownloadSorter
{
    public partial class RenameTool : Form
    {
        private List<CustomFile> _customFiles;
        private List<string> _removalWords;
        private List<string> RemovalWords
        {
            get
            {
                if (_removalWords == null)
                    _removalWords = new List<string>();
                return _removalWords;
            }
            set
            {
                _removalWords = value;
                applyRenameFilters();
            }
        }

        private void applyRenameFilters()
        {
            // Reset File names before applying filters.
            CustomFiles.ForEach(x => { x.NewFileName = x.FileName; });

            removeCharacters(new char[] { '-', '.', '[', ']' });

            removeDoubleSpaces();
            trimCustomFiles();

            removeNewsHostID();

            removeCustomWords2();

            capitalizeWords();

            removeDoubleSpaces();
            trimCustomFiles();

            bindingSourceCustomFile.ResetBindings(false);
        }

        private void removeCustomWords2()
        {
            List<string> wordsToRemove = new List<string>();
            checkedListBoxRemovalWords.CheckedItems.OfType<string>().ToList().ForEach(x =>
                {
                    wordsToRemove.Add(x.ToLower());
                });

            CustomFiles.ForEach(x =>
            {
                string newFileName = "";
                x.NewFileName.Split(' ').ToList().ForEach(word =>
                    {
                        // To Lower
                        if (!wordsToRemove.Contains(word.ToLower()))
                        {
                            if (newFileName == "")
                                newFileName += word;
                            else
                                newFileName += ' ' + word;
                        }
                        else
                        {
                            // Remove words
                        }
                    });
                x.NewFileName = newFileName;
            });
        }

        private void trimCustomFiles()
        {
            CustomFiles.ForEach(x =>
                {
                    x.NewFileName = x.NewFileName.Trim();
                });
        }

        private void capitalizeWords()
        {
            CustomFiles.ForEach(x =>
                {
                    string newFileName = "";
                    x.NewFileName.Split(' ').ToList().ForEach(y =>
                        {
                            if (newFileName == "")
                            {
                                for (int i = 0; i < y.Length; i++)
                                {
                                    if (i == 0)
                                    {
                                        newFileName += y[i].ToString().ToUpper();
                                    }
                                    else
                                    {
                                        newFileName += y[i].ToString().ToLower();
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < y.Length; i++)
                                {
                                    if (i == 0)
                                    {
                                        newFileName += ' ' + y[i].ToString().ToUpper();
                                    }
                                    else
                                    {
                                        newFileName += ' ' + y[i].ToString().ToLower();
                                    }
                                }
                            }
                        });
                });
        }

        private void removeNewsHostID()
        {
            //CustomFiles.ForEach(x =>
            //    {
            //        if (x.NewFileName.ToLower().Contains("newshost"))
            //        {
            //            x.NewFileName = x.NewFileName.Substring(0, x.NewFileName.Length - 5);
            //            x.NewFileName = Regex.Replace(x.NewFileName, "newshost", string.Empty, RegexOptions.IgnoreCase);
            //        }
            //    });

            CustomFiles.ForEach(x =>
                {
                    if (x.NewFileName.ToLower().Contains("newshost"))
                        x.NewFileName = Regex.Replace(x.NewFileName, "newshost", string.Empty, RegexOptions.IgnoreCase);

                    string newFileName = "";
                    x.NewFileName.Split(' ').ToList().ForEach(y =>
                        {
                            if (y.Length == 4)
                            {
                                int isInt = 0;
                                if ((Int32.TryParse(y, out isInt)))
                                {
                                    if (isInt < DateTime.Now.AddYears(-50).Year || isInt > DateTime.Now.AddYears(50).Year)
                                    {
                                        // Ignore - aka remove
                                    }
                                    else
                                    {
                                        if (newFileName == "")
                                            newFileName += y;
                                        else
                                            newFileName += ' ' + y;
                                    }
                                }
                                else
                                {
                                    if (newFileName == "")
                                        newFileName += y;
                                    else
                                        newFileName += ' ' + y;
                                }
                            }
                            else
                            {
                                if (newFileName == "")
                                    newFileName += y;
                                else
                                    newFileName += ' ' + y;
                            }
                        });

                    x.NewFileName = newFileName;

                });
        }

        private void removeDoubleSpaces()
        {
            CustomFiles.ForEach(x =>
                {
                    int len = 0;
                    while (x.NewFileName.Length != len)
                    {
                        len = x.NewFileName.Length;
                        x.NewFileName = x.NewFileName.Replace("  ", " ");
                    }
                });
        }

        private void removeCharacters(char[] removalChars)
        {
            CustomFiles.ForEach(x =>
                {
                    foreach (char c in removalChars)
                    {
                        x.NewFileName = x.NewFileName.Replace(c, ' ');
                    }
                });
        }

        public List<CustomFile> CustomFiles
        {
            get
            {
                if (_customFiles == null)
                    _customFiles = new List<CustomFile>();
                return _customFiles;
            }
            set
            {
                _customFiles = value;
                applyRenameFilters();
                if (_customFiles.Count != 0 && bindingSourceCustomFile.List.Count == 0)
                    checkBoxShowOnlyFilesToBeRenamed_CheckedChanged(null, null);
                bindingSourceCustomFile.ResetBindings(false);
            }
        }

        public RenameTool()
        {
            InitializeComponent();

            checkedListBoxRemovalWords.Sorted = true;

            loadRemovalWords();
        }

        private void loadRemovalWords()
        {
            if (!File.Exists("RenameRemovalWords.txt"))
            {
                FileStream fs = File.Create("RenameRemovalWords.txt");
				fs.Close();
                FileInfo fi = new FileInfo("RenameRemovalWords.txt");
                MessageBox.Show(fi.FullName + " created.");
                fi = null;
            }

            RemovalWords.Clear();

            StreamReader sr = null;
            try
            {
                sr = new StreamReader("RenameRemovalWords.txt");
                string line = sr.ReadLine();
                while (line != null)
                {
                    _removalWords.Add(line);
                    line = sr.ReadLine();
                }
            }
            finally
            {
                sr.Close();
            }

            RemovalWords = SortByLength(RemovalWords, false).ToList();

            checkedListBoxRemovalWords.Items.Clear();
            checkedListBoxRemovalWords.Items.AddRange(RemovalWords.ToArray());
            selectAllCheckBoxes(true);
        }

        private void selectAllCheckBoxes(bool CheckThem)
        {
            for (int i = 0; i <= (checkedListBoxRemovalWords.Items.Count - 1); i++)
            {
                if (CheckThem)
                {
                    checkedListBoxRemovalWords.SetItemCheckState(i, CheckState.Checked);
                }
                else
                {
                    checkedListBoxRemovalWords.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }

        private void saveRemovalWords()
        {
            StreamWriter sw = new StreamWriter("RenameRemovalWords.txt", false);
            RemovalWords.ForEach(x =>
                {
                    sw.WriteLine(x);
                });
            sw.Close();
        }

        static IEnumerable<string> SortByLength(IEnumerable<string> words, bool ascending)
        {
            IEnumerable<string> sorted;
            if (ascending)
                sorted = from s in words orderby s.Length ascending select s;
            else
                sorted = from s in words orderby s.Length descending select s;
            return sorted;
        }

        private void rename()
        {
            CustomFiles.ForEach(x =>
            {
                if (x.Rename)
                {
                    x.FileName = x.NewFileName;
                }
            });
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            List<string> cantMoveFiles = new List<string>();
            CustomFiles.ForEach(x =>
            {
                if (x.FileName != x.NewFileName)
                {
                    if (x.Rename)
                    {
                        //string dest = x.FullPath.Replace(x.FileName, x.NewFileName);
                        string dest = x.FullPath.Substring(0, x.FullPath.Length - (x.FileName.Length + x.Extention.Length)) + x.NewFileName + x.Extention;
                        if (!File.Exists(dest))
                            File.Move(x.FullPath, dest);
                        else
                            cantMoveFiles.Add(dest);
                    }
                }
            });

            if (cantMoveFiles.Count != 0)
            {
                string message = "The following files could not be moved because they already exist.";
                cantMoveFiles.ForEach(x => message += Environment.NewLine + x);
                MessageBox.Show(message);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void buttonAddRemovalWord_Click(object sender, EventArgs e)
        {
            if (textBoxAddRemovalWord.Text != "")
            {
                RemovalWords.Clear();
                checkedListBoxRemovalWords.Items.OfType<string>().ToList().ForEach(x => { RemovalWords.Add(x); });

                if (RemovalWords.Find(x => x.ToLower() == textBoxAddRemovalWord.Text.ToLower()) == null)
                {
                    RemovalWords.Add(textBoxAddRemovalWord.Text);

                    RemovalWords = SortByLength(RemovalWords, false).ToList();

                    saveRemovalWords();

                    checkedListBoxRemovalWords.Items.Add(textBoxAddRemovalWord.Text);
                    int newWord = checkedListBoxRemovalWords.Items.IndexOf(textBoxAddRemovalWord.Text);
                    if (newWord != -1)
                        checkedListBoxRemovalWords.SetItemChecked(newWord, true);

                    textBoxAddRemovalWord.Text = "";

                    bindingSourceCustomFile.ResetBindings(false);
                }
                else
                    MessageBox.Show("Removal word already exists.");
            }
            else
            {
                MessageBox.Show("Can't add nothing..." + Environment.NewLine + Environment.NewLine + "... well technically I can but that's just stupid...");
            }
        }

        private void checkedListBoxRemovalWords_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkedListBoxRemovalWords.ItemCheck -= checkedListBoxRemovalWords_ItemCheck;
            checkedListBoxRemovalWords.SetItemCheckState(e.Index, e.NewValue);
            applyRenameFilters();
            checkedListBoxRemovalWords.ItemCheck += checkedListBoxRemovalWords_ItemCheck;
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            CustomFiles.ForEach(x =>
                {
                    x.Rename = true;
                });
            bindingSourceCustomFile.ResetBindings(false);
        }

        private void buttonDeselectAll_Click(object sender, EventArgs e)
        {
            CustomFiles.ForEach(x =>
            {
                x.Rename = false;
            });
            bindingSourceCustomFile.ResetBindings(false);
        }

        private void buttonInvertSelection_Click(object sender, EventArgs e)
        {
            CustomFiles.ForEach(x =>
            {
                x.Rename = !x.Rename;
            });
            bindingSourceCustomFile.ResetBindings(false);
        }

        private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (dataGridView.Columns[e.ColumnIndex].Name == "fileNameDataGridViewTextBoxColumn")
                {
                    CustomFile cf = CustomFiles.Find(x => x.FileName == e.Value.ToString());
                    if (cf != null && cf.HighlightedText.Count > 0)
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;

                        for (int i = 0; i < cf.FileName.Length; i++)
                        {
                            bool highlight = false;
                            cf.HighlightedText.ForEach(x =>
                                {
                                    if (i > x.Value && i < x.Value + x.Key.Length)
                                        highlight = true;
                                });
                            SizeF size = e.Graphics.MeasureString(cf.FileName.Substring(0, i + 1), e.CellStyle.Font);
                            PointF point = new PointF(e.CellBounds.Location.X + size.Width, e.CellBounds.Location.Y);

                            if (!highlight)
                                e.Graphics.DrawString(cf.FileName[i].ToString(),
                                    e.CellStyle.Font,
                                    new SolidBrush(Color.Black),
                                    point);
                            else
                                e.Graphics.DrawString(cf.FileName[i].ToString(),
                                e.CellStyle.Font,
                                new SolidBrush(Color.Red),
                                point);

                        }
                        e.Handled = true;
                    }
                }
            }
        }

        private void checkBoxShowOnlyFilesToBeRenamed_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowOnlyFilesToBeRenamed.Checked)
                bindingSourceCustomFile.DataSource = CustomFiles.FindAll(x => x.FileName != x.NewFileName);
            else
                bindingSourceCustomFile.DataSource = CustomFiles;
            bindingSourceCustomFile.ResetBindings(false);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkedListBoxRemovalWords.SelectedItem != null)
                checkedListBoxRemovalWords.Items.Remove(checkedListBoxRemovalWords.SelectedItem);

            saveRemovalWords();

            applyRenameFilters();
        }
    }
}