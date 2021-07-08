using UnityEngine;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{
    private Card card;
    public void LoadCard()
    {
        Transform t = GameObject.Find("Panels").gameObject.transform;
        foreach (Transform child in t)
        {
            Destroy(child.gameObject);
        }
        string name = transform.Find("Text").GetComponent<Text>().text;
        card = LoadFile.StatusLoad(name + ".json");
        GameObject.Find("DeckSystem").GetComponent<DeckCreate>().SetText(card);

    }

    public Card GetCard()
    {
        return card;
    }
}
