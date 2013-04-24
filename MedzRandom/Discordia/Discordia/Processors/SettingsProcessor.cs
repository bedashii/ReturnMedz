using DiscordiaGenLib.GenLib.Lists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discordia.Processors
{
    public class SettingsProcessor
    {
        private BackgroundWorker _bg;

        private SystemConfigList _moviePaths;
        public SystemConfigList MoviePaths
        {
            get
            {
                if (_moviePaths == null)
                    _moviePaths = new SystemConfigList();
                return _moviePaths;
            }
            set
            {
                _moviePaths = value;
            }
        }

        public delegate void WorkCompleteHandler();
        public event WorkCompleteHandler MoviePathsWorkComplete;

        public SettingsProcessor()
        {
            if (_bg == null)
            {
                _bg = new BackgroundWorker();
                _bg.DoWork += delegate { getDirectories(); };
                _bg.RunWorkerCompleted += delegate { MoviePathsWorkComplete.Invoke(); };
            }
            _bg.RunWorkerAsync();
        }

        void getDirectories()
        {
            MoviePaths.GetByKey("MoviePath");
        }
    }
}
