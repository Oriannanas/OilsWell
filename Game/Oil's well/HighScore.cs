using Microsoft.Xna.Framework.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Oils_well
{
    [Serializable]
    public struct HighScore
    {
        public string[] PlayerName;
        public int[] Score;

        public int Count;

        public HighScore(int count)
        {
            PlayerName = new string[count];
            Score = new int[count];

            Count = count;
        }
        // = "highscore.txt"
        


        public static void SaveHighScores(HighScore data, string filename)
        {

            // Open the file, creating it if necessary
            FileStream stream = File.Open(filename, FileMode.OpenOrCreate);

            try
            {
                stream.SetLength(0);
                // Convert the object to XML data and put it in the stream
                XmlSerializer serializer = new XmlSerializer(typeof(HighScore));
                serializer.Serialize(stream, data);
            }
            finally
            {
                // Close the file
                stream.Close();
            }
        }
        
        public static HighScore LoadHighScores(string filename)
        {
            HighScore data;

            FileStream stream = File.Open(filename, FileMode.OpenOrCreate, FileAccess.Read);

            try
            {
                // Convert the object to XML data and put it in the stream
                XmlSerializer serializer = new XmlSerializer(typeof(HighScore));
                data = (HighScore)serializer.Deserialize(stream);
            }
            finally
            {
                // Close the file
                stream.Close();
            }
            return data;
        }
    }
}
