using Data;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DeckCreate : MonoBehaviour
{
    [SerializeField] private GameObject cardlist = null;
    [SerializeField] private GameObject decklist = null;
    [SerializeField] private GameObject cardbtnpref = null;
    [SerializeField] private Text nameText = null;
    [SerializeField] private Text ElementText = null;
    [SerializeField] private GameObject DataPref = null;
    [SerializeField] private GameObject DataParents = null;

    private void Start()
    {
        FileInfo[] info = LoadFile.FileListLoad("*");
        GameObject obj;
        string charactername = PlayerPrefs.GetString("CharaName");
        foreach (FileInfo f in info)
        {
            obj = Instantiate(cardbtnpref, cardlist.transform);
            obj.transform.Find("Text").GetComponent<Text>().text = f.Name.Substring(0, f.Name.IndexOf("."));
        }
        List<Card> cardList;
        charactername = "111";
        try
        {
            cardList = LoadFile.DeckStatusLoad(charactername);
        }
        catch
        {
            cardList = new List<Card>();
        }
        foreach (Card c in cardList)
        {
            obj = Instantiate(cardbtnpref, decklist.transform);
            obj.transform.Find("Text").GetComponent<Text>().text = c.name;
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
