using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MovieLib;
using System.IO;

namespace MovieManagerLibTests
{
    [TestFixture]
    public class TestFileProperties
    {
        [Test]
        public void AreEqual_GivenFile_GetFullFileName()
        {
            MovieLib.Magic.File movieMagic = new MovieLib.Magic.File();
            movieMagic.Open(System.Configuration.ConfigurationSettings.AppSettings.Get("FullFileName"));
            Assert.AreEqual("The Perfect Roomate (2011).mkv", movieMagic.FullFileName, movieMagic.FullFileName);
        }

        [Test]
        public void AreEqual_GivenFile_GetFileName()
        {
            MovieLib.Magic.File movieMagic = new MovieLib.Magic.File();
            movieMagic.Open(System.Configuration.ConfigurationSettings.AppSettings.Get("FullFileName"));
            Assert.AreEqual("The Perfect Roomate (2011)", movieMagic.FileName, movieMagic.FileName);
        }

        [Test]
        public void AreEqual_GivenFile_GetExtension()
        {
            MovieLib.Magic.File movieMagic = new MovieLib.Magic.File();
            movieMagic.Open(System.Configuration.ConfigurationSettings.AppSettings.Get("FullFileName"));
            Assert.AreEqual("mkv", movieMagic.Extension, movieMagic.Extension);
        }

        [Test]
        public void AreEqual_GivenFileName_GetFormat()
        {
            MovieLib.Magic.File movieMagic = new MovieLib.Magic.File();
            movieMagic.Open(System.Configuration.ConfigurationSettings.AppSettings.Get("FullFileName"));
            Assert.AreEqual("Matroska", movieMagic.Format, movieMagic.Format);
        }

        [Test]
        public void AreEqual_GivenFileName_GetVideoCodecs()
        {
            MovieLib.Magic.File movieMagic = new MovieLib.Magic.File();
            movieMagic.Open(System.Configuration.ConfigurationSettings.AppSettings.Get("FullFileName"));
            Assert.AreEqual("AVC", movieMagic.VideoCodecs[0], movieMagic.VideoCodecs[0]);
        }

        [Test]
        public void AreEqual_GivenFileName_GetAudioCodecs()
        {
            MovieLib.Magic.File movieMagic = new MovieLib.Magic.File();
            movieMagic.Open(System.Configuration.ConfigurationSettings.AppSettings.Get("FullFileName"));
            Assert.AreEqual("DTS", movieMagic.AudioCodecs[0], movieMagic.AudioCodecs[0]);
        }

        [Test]
        public void AreEqual_GivenFileName_GetAudioLanguages()
        {
            MovieLib.Magic.File movieMagic = new MovieLib.Magic.File();
            movieMagic.Open(System.Configuration.ConfigurationSettings.AppSettings.Get("FullFileName"));
            Assert.AreEqual("English", movieMagic.AudioLanguages[0], movieMagic.AudioLanguages[0]);
        }

        [Test]
        public void AreEqual_GivenFileName_GetFileSize()
        {
            MovieLib.Magic.File movieMagic = new MovieLib.Magic.File();
            movieMagic.Open(System.Configuration.ConfigurationSettings.AppSettings.Get("FullFileName"));
            Assert.AreEqual(36579838, movieMagic.FileSizeB, movieMagic.FileSizeB);
            Assert.AreEqual(34, movieMagic.FileSizeMB, movieMagic.FileSizeMB.ToString());
            Assert.AreEqual(0, movieMagic.FileSizeGB, movieMagic.FileSizeGB.ToString());
        }

        [Test]
        public void AreEqual_GivenFileName_GetDuration()
        {
            MovieLib.Magic.File movieMagic = new MovieLib.Magic.File();
            movieMagic.Open(System.Configuration.ConfigurationSettings.AppSettings.Get("FullFileName"));
            Assert.AreEqual(61043, movieMagic.DurationMS, movieMagic.DurationMS.ToString());
            Assert.AreEqual(1, movieMagic.DurationM, movieMagic.DurationM.ToString());
        }

        [Test]
        public void AreEqual_GivenFileName_GetBitRateOverall()
        {
            MovieLib.Magic.File movieMagic = new MovieLib.Magic.File();
            movieMagic.Open(System.Configuration.ConfigurationSettings.AppSettings.Get("FullFileName"));
            Assert.AreEqual(4793976, movieMagic.BitRateOverallbps, movieMagic.BitRateOverallbps.ToString());
            Assert.AreEqual(4.79, movieMagic.BitRateOverallmbps, movieMagic.BitRateOverallmbps.ToString());
        }
    }
}
