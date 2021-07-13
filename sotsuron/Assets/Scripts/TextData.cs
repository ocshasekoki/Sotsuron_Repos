using UnityEngine;
using UnityEngine.UI;

public class TextData : MonoBehaviour
{
    [SerializeField] private Text paramText =null;
    [SerializeField] private Text subparamText = null;
    [SerializeField] private Text targetText = null;
    [SerializeField] private Text typeText = null;
    [SerializeField] private Text conText = null;
    [SerializeField] private Toggle angle = null;
    [SerializeField] private Image[] areas = null;
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
