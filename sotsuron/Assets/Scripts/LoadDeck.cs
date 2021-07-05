using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadDeck : MonoBehaviour
{
    [SerializeField] private GameObject cardlist = null;
    [SerializeField] private GameObject cardbtnpref = null;
    private void Start()
    {
        FileListLoad(cardbtnpref,cardlist,"*");
    }

    public static void FileListLoad(GameObject prefab,GameObject parent,string cardname)
    {
        DirectoryInfo dir = new DirectoryInfo(Application.streamingAssetsPath + "/card/");
        FileInfo[] info = dir.GetFiles(cardname + ".json");
        GameObject obj;
        foreach (FileInfo f in info)
        {
            obj = Instantiate(prefab, parent.transform);
            obj.transform.Find("Text").GetComponent<Text>().text = f.Name;
        }
    }

    public static Card StatusLoad(string cardname)
    {
        Card card = new Card();
        var json = File.ReadAllText(Application.streamingAssetsPath + "/card/" + cardname);
        card = JsonUtility.FromJson<Card>(json);
        return card;
    }

    public static void AddComponentCard(GameObject obj)
    {
        obj.AddComponent<Card>();
    }
}
