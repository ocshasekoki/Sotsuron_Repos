using Data;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace FileIO
{
    public class LoadFile
    {

        public static FileInfo[] FileListLoad(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(Application.streamingAssetsPath + "/cards/");
            return dir.GetFiles(path + ".json");
        }

        public static Card CardStatusLoad(string cardname)
        {
            Card card = new Card();
            string json = File.ReadAllText(Application.streamingAssetsPath + "/cards/" + cardname + ".json");
            JsonUtility.FromJsonOverwrite(json, card);
            card.Dump();
            return card;
        }

        public static List<string> DeckStatusLoad(string charaname)
        {
            CharaData data = new CharaData();
            string json = File.ReadAllText(Application.streamingAssetsPath + "/Characters/" + charaname + ".json");
            JsonUtility.FromJsonOverwrite(json, data);
            data.Dump();
            return data.GetDeck();
        }

        public static CharaData CharacterStatusLoad(string charaname)
        {
            CharaData data = new CharaData();
            string json = File.ReadAllText(Application.streamingAssetsPath + "/Characters/" + charaname + ".json");
            JsonUtility.FromJsonOverwrite(json, data);
            data.Dump();
            return data;
        }

        public static void CharacterStatusSave(string charaname, CharaData data)
        {
            string str = JsonUtility.ToJson(data);
            string path = Application.streamingAssetsPath + "/" + charaname + ".json";
            File.WriteAllText(path, str);
        }
    }
}