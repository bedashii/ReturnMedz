using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BadReferenceFinder
{
    /// <summary>
    /// Interaction logic for ReferencesWindow.xaml
    /// </summary>
    public partial class ReferencesWindow : Window
    {
        public string ProjectPath { get; set; }

        public ReferencesWindow()
        {
            InitializeComponent();
        }

        public ReferencesWindow(string projectPath)
        {
            InitializeComponent();

            ProjectPath = projectPath;
            Refresh();
        }

        private List<ReferenceObj> referenceList;

        public void Refresh()
        {
            referenceList = new List<ReferenceObj>();
            if (File.Exists(ProjectPath))
            {
                StreamReader sr = new StreamReader(ProjectPath);

                string line = sr.ReadLine();

                while (!string.IsNullOrEmpty(line))
                {
                    if (line.Contains("ProjectReference Include=" + '"'))
                    {
                        int startIndex = line.IndexOf("ProjectReference Include=" + '"') +
                                         ("ProjectReference Include=" + '"').Length;
                        int endIndex = line.IndexOf('"', startIndex);

                        string baseStr = ProjectPath.Substring(0, ProjectPath.LastIndexOf("\\"));
                        string referenceStr = line.Substring(startIndex, endIndex - startIndex);

                        while (referenceStr.StartsWith("..\\"))
                        {
                            baseStr = baseStr.Substring(0, baseStr.LastIndexOf("\\"));
                            referenceStr = referenceStr.Substring(3);
                        }

                        referenceList.Add(new ReferenceObj(baseStr + "\\" + referenceStr));
                    }
                    line = sr.ReadLine();
                }
            }

            DataGridReferences.ItemsSource = referenceList;
        }
    }
}

public class ReferenceObj
{
    public string Name { get; set; }
    public string FullPath { get; set; }
    public bool Exists { get; set; }

    public ReferenceObj(string path)
    {
        FullPath = path;

        try
        {
            FullPath = System.IO.Path.GetFullPath(FullPath);
        }
        catch (Exception ex)
        {

        }

        FileInfo fi = new FileInfo(FullPath);
        if (fi.Exists)
        {
            Name = fi.Name;
            Exists = fi.Exists;
        }
        else
            Name = path;
    }
}