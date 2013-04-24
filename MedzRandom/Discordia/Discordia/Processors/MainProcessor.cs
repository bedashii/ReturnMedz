﻿using Discordia.UI;
using DiscordiaGenLib.GenLib.Lists;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discordia
{
    public class MainProcessor
    {
        public MainProcessor()
        {
        }

        SystemConfigList _moviePaths;
        List<FileInfo> _files;

        public List<MovieControl> Scan()
        {
            getMoviePaths();

            getAllFiles();

            findMovies();

            fetchMovieInfo();

            updateDatabase();

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

        private List<string> movieFileTypes = new List<string>() { ".mkv",".avi" };

        private void findMovies()
        {
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
            
        }

        private void updateDatabase()
        {

        }
    }
}