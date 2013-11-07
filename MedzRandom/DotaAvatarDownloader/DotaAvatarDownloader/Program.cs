using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DotaDbGenLib.Lists;

namespace DotaAvatarDownloader
{
    class Program
    {
        private static string _directory = "Avatars";
        private static int _avatarFetchCount = 100;

        static void Main(string[] args)
        {
            DotaDbGenLib.Lists.PlayersList _players = new PlayersList();
            _players.GetAll(0, _avatarFetchCount);

            int counter = 0;

            if (!Directory.Exists(_directory))
                Directory.CreateDirectory(_directory);

            do
            {
                counter += _players.Count;

                _players.ForEach(x =>
                                     {
                                         if (x != null && x.RecordExists && x.AvatarFull != null)
                                         {
                                             int index = x.AvatarFull.LastIndexOf('/');
                                             if (index != -1)
                                             {
                                                 string path = x.AvatarFull.Substring(index + 1);
                                                 try
                                                 {
                                                     if (!File.Exists(_directory + "\\" + path))
                                                     {
                                                         DownloadRemoteImageFile(x.AvatarFull, _directory + "\\" + path);
                                                         Console.WriteLine(path + " downloaded!");
                                                     }
                                                     else
                                                     {
                                                         Console.WriteLine(path + " exists!");
                                                     }
                                                 }
                                                 catch (Exception ex)
                                                 {
                                                     Console.WriteLine(ex.Message);
                                                 }
                                             }
                                         }
                                     });

                _players.Clear();
                _players.GetAll(counter, _avatarFetchCount);
            } while (_players.Count > 0);
        }

        private static void DownloadRemoteImageFile(string uri, string fileName)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Check that the remote file was found. The ContentType
            // check is performed since a request for a non-existent
            // image file might be redirected to a 404-page, which would
            // yield the StatusCode "OK", even though the image was not
            // found.
            if ((response.StatusCode == HttpStatusCode.OK ||
                response.StatusCode == HttpStatusCode.Moved ||
                response.StatusCode == HttpStatusCode.Redirect) &&
                response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
            {

                // if the remote file was found, download oit
                using (Stream inputStream = response.GetResponseStream())
                using (Stream outputStream = File.OpenWrite(fileName))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    do
                    {
                        bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                        outputStream.Write(buffer, 0, bytesRead);
                    } while (bytesRead != 0);
                }
            }
        }
    }
}
