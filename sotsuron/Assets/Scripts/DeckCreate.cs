using Data;
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
        FileInfo[] info = FileIO.LoadFile.FileListLoad("*");
        GameObject obj;
        string charactername = PlayerPrefs.GetString("CharaName");
        foreach (FileInfo f in info)
        {
            obj = Instantiate(cardbtnpref, cardlist.transform);
            obj.transform.Find("Text").GetComponent<Text>().text = f.Name.Substring(0, f.Name.IndexOf("."));
        }
        CharaData data;
        try
        {
            data = FileIO.LoadFile.CharacterStatusLoad(charactername);
            Debug.Log("ロード");
        }
        catch
        {
            data = CharaCreate();
        }
        foreach (string s in data.GetDeck())
        {
            obj = Instantiate(cardbtnpref, decklist.transform);
            obj.transform.Find("Text").GetComponent<Text>().text = s;
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
    private CharaData CharaCreate()
    {
        CharaData c = new CharaData();
        c.SetATK(100);
        c.SetDF(21);
        c.SetHp(111);
        c.SetSPD(1);
        c.SetCtype(CharaType.ATTACKER);
        c.Setname("222");
        c.SetElement(Elements.FIRE);
        c.ClearDeck();
        c.AddDeck("aaa");
        c.AddDeck("bbb");
        c.ClearHands();
        c.AddHands(FileIO.LoadFile.CardStatusLoad("aaa"));
        return c;
    }
}
