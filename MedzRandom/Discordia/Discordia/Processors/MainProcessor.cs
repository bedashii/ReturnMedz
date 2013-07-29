using Discordia.UI;
using DiscordiaGenLib.GenLib.Lists;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordiaGenLib.GenLib;

namespace Discordia
{
    public class MainProcessor
    {
        public MainProcessor()
        {
            TMDBHelper.TMDB = new WatTmdb.V3.Tmdb("72cdccd9229e5896d3df21c8c96b3016");
        }

        SystemConfigList _moviePaths;
        List<FileInfo> _files;

        public List<MovieControl> Scan()
        {
            DateTime now = DateTime.Now;
            getMoviePaths();
            string getMoviePathsDuration = (DateTime.Now - now).TotalSeconds.ToString();
            now = DateTime.Now;
            getAllFiles();
            string getAllFilesDuration = (DateTime.Now - now).TotalSeconds.ToString();
            now = DateTime.Now;
            findMovies();
            string findMoviesDuration = (DateTime.Now - now).TotalSeconds.ToString();
            now = DateTime.Now;
            fetchMovieInfo();
            string fetchMovieInfoDuration = (DateTime.Now - now).TotalSeconds.ToString();
            now = DateTime.Now;
            updateDatabase();
            string updateDatabaseDuration = (DateTime.Now - now).TotalSeconds.ToString();
            now = DateTime.Now;
            updateUI();
            string updateUIDuration = (DateTime.Now - now).TotalSeconds.ToString();
            return _movieControls;
        }

        private void getMoviePaths()
        {
            if (_moviePaths == null)
                _moviePaths = new SystemConfigList();
            else
                _moviePaths.Clear();
            _moviePaths.GetByKey("MoviePath");
        }

        private void getAllFiles()
        {
            if (_files == null)
                _files = new List<FileInfo>();
            else
                _files.Clear();

            _moviePaths.ForEach(systemConfig =>
                {
                    addFilesRecursive(systemConfig.ConfigValue);
                });
        }

        private void addFilesRecursive(string path)
        {
            Directory.GetFiles(path).ToList().ForEach(x =>
                {
                    _files.Add(new FileInfo(x));
                });
            Directory.GetDirectories(path).ToList().ForEach(x =>
                {
                    addFilesRecursive(x);
                });
        }

        private List<MovieControl> _movieControls;

        private List<string> movieFileTypes = new List<string>() { ".mkv", ".avi" };

        private void findMovies()
        {
            // This should have just been a method to find the movie files
            // But When you create a movie control it finds the movie info for itself...

            List<FileInfo> movieFiles = new List<FileInfo>();

            _files.ForEach(file =>
                {
                    if (movieFileTypes.Contains(file.Extension))
                    {
                        movieFiles.Add(file);
                    }
                });

            _movieControls = new List<MovieControl>();

            movieFiles.ForEach(movieFile =>
                {
                    _movieControls.Add(new MovieControl(movieFile.FullName));
                });
        }

        private void fetchMovieInfo()
        {
            _movieControls.ForEach(x =>
                {
                    x.FindMovieInfo();
                });
        }

        private void updateDatabase()
        {
            _movieControls.ForEach(x =>
            {
                x.Save();
            });
        }

        private void updateUI()
        {
            _movieControls.ForEach(x =>
            {
                x.UpdateUI();
            });
        }
    }
}