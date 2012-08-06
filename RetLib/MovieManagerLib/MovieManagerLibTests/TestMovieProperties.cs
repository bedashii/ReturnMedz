using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MovieLib;
using MovieLib.Magic;
using System.IO;

namespace MovieManagerLibTests
{
    [TestFixture]
    public class TestMovieProperties
    {
        [Test]
        public void AreEqual_GivenFile_GetFullFileName()
        {
            Magic magic = new Magic();
            magic.Open(System.Configuration.ConfigurationSettings.AppSettings.Get("FullFileName"));
            Assert.AreEqual("The Perfect Roomate", magic.Movie.OriginalName, magic.Movie.OriginalName);
        }

        [Test]
        public void AreEqual_GivenFile_GetMovieName2()
        {
            Magic magic = new Magic();
            magic.Open(System.Configuration.ConfigurationSettings.AppSettings.Get("MovieTest2"));
            Assert.AreEqual("Chronicle", magic.Movie.OriginalName, magic.Movie.OriginalName);
        }

        [Test]
        public void AreEqual_GivenFile_GetMovieName3()
        {
            Magic magic = new Magic();
            magic.Open(System.Configuration.ConfigurationSettings.AppSettings.Get("MovieTest3"));
            Assert.AreEqual("Men In Black II", magic.Movie.OriginalName, magic.Movie.OriginalName);
        }

        [Test]
        public void AreEqual_GivenOriginalTitle_GetMovieIMDBProperties()
        {
            Magic magic = new Magic();
            magic.Open(System.Configuration.ConfigurationSettings.AppSettings.Get("FullFileName"));
            Assert.AreEqual("The Perfect Roommate".ToLower(), magic.Movie.MovieName.ToLower());
            Assert.AreEqual("Thriller", magic.Movie.Genres[0]);
            Assert.AreEqual("90", magic.Movie.Runtime);
            Assert.AreEqual(3.6, magic.Movie.Rating);
            Assert.AreEqual(2011, magic.Movie.Year);
            Assert.AreEqual("TV_14", magic.Movie.MPAARating);
            Assert.AreEqual("Carrie Remington seems like any other struggling waitress who's had a run of bad luck including a recent divorce. Things seem to be improving when she moves in with Ashley Dunnfield...things take a turn when Ashley starts digging into her past and finds out that there is much she didn't know about her new roommate's sinister history.", magic.Movie.Storyline);
            Assert.AreEqual("Carrie Remington seems like any other struggling waitress who's had a run of bad luck including a recent divorce. Things seem to be improving when she moves in with Ashley Dunnfield...", magic.Movie.Plot);
        }
    }
}
