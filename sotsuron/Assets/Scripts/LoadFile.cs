using Data;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

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
        JsonUtility.FromJsonOverwrite(json,card);
        card.Dump();
        return card;
    }

    public static List<Card> DeckStatusLoad(string charaname)
    {
        CharaData data = new CharaData();
        string json = File.ReadAllText(Application.streamingAssetsPath + "/Characters/" + charaname+".json");
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

    public static void CharacterStatusSave(string charaname,CharaData data)
    {
        string str = JsonUtility.ToJson(data);
        Debug.Log(str);
    }
}
