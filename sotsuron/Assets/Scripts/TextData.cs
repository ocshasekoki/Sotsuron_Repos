using UnityEngine;
using UnityEngine.UI;

public class TextData : MonoBehaviour
{
    [SerializeField] private Text paramText;
    [SerializeField] private Text subparamText;
    [SerializeField] private Text targetText;
    [SerializeField] private Text typeText;
    [SerializeField] private Text conText;
    [SerializeField] private Toggle angle;
    [SerializeField] private Image[] areas;
    public void SetText(Card card,int index)
    {
        paramText.text = card.Getparam(index).ToString();
        subparamText.text = card.Getsubparam(index).ToString();
        targetText.text = card.GetTarget(index).ToString();
        typeText.text = card.GetTechtype(index).ToString();
        conText.text = card.GetCondition(index).ToString();
        conText.text = card.Getangle(index).ToString();
        for(int i = 0; i< areas.Length;i++)
        {
            if(card.GetareaID(index)[i] ==0)
            {
                areas[i].color = Color.red;
            }
        }
    }
}
