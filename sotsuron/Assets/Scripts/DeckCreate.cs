using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DeckCreate : MonoBehaviour
{
    [SerializeField] private GameObject cardlist = null;
    [SerializeField] private GameObject cardbtnpref = null;
    [SerializeField] private Text nameText = null;
    [SerializeField] private Text ElementText = null;
    [SerializeField] private GameObject DataPref = null;
    [SerializeField] private GameObject DataParents = null;

    private void Start()
    {
        FileInfo[] info = LoadFile.FileListLoad("*");
        GameObject obj;
        foreach (FileInfo f in info)
        {
            obj = Instantiate(cardbtnpref, cardlist.transform);
            obj.transform.Find("Text").GetComponent<Text>().text = f.Name.Substring(0, f.Name.IndexOf(".")); ;
        }
    }
    public void SetText(Card card)
    {
        nameText.text = card.GetcardName();
        ElementText.text = card.GetElement().ToString();
        for(int i = 0; i< card.GetparamLength(); i++)
        {
            GameObject obj = Instantiate(DataPref, DataParents.transform);
            obj.GetComponent<TextData>().SetText(card, i);
        }
    }
}
