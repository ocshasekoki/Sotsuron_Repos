using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadFile
{

    public static FileInfo[] FileListLoad(string cardname)
    {
        DirectoryInfo dir = new DirectoryInfo(Application.streamingAssetsPath + "/card/");
        return dir.GetFiles(cardname + ".json");
    }

    public static Card StatusLoad(string cardname)
    {
        Card card = new Card();
        string json = File.ReadAllText(Application.streamingAssetsPath + "/card/" + cardname);
        JsonUtility.FromJsonOverwrite(json,card);
        card.Dump();
        return card;
    }
}
