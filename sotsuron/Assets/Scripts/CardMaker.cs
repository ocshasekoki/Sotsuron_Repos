using Data;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardMaker : MonoBehaviour
{
    [SerializeField] InputField cardnameIF = null;
    [SerializeField] Dropdown paramlengthDD = null;
    [SerializeField] Dropdown elementDD = null;
    [SerializeField] GameObject param = null;
    [SerializeField] GameObject subParam = null;
    [SerializeField] GameObject techType = null;
    [SerializeField] GameObject condition = null;
    [SerializeField] GameObject target = null;
    [SerializeField] Dropdown angleDD = null;
    [SerializeField] Toggle angletoggle = null;

    //Prefab
    [SerializeField] GameObject inputPanel = null;
    [SerializeField] GameObject DDPanel = null;

    [SerializeField] List<string> techTypelist = null;
    [SerializeField] List<string> conditionlist = null;
    [SerializeField] List<string> targetlist = null;
    [SerializeField] List<string> arealist = null;

    [SerializeField] Toggle[] Areas = null;
    int paraindex;
    private Card card;
    // Start is called before the first frame update
    void Start()
    {
        card = new Card();
        card.Setlength(1);
    }
    public void ChangeValue()
    {
        //パラメータ数の読み込み
        int length =paramlengthDD.value+1;
        int defaultlength = card.GetparamLength();
        card.Setlength(length);
        if (defaultlength != length)
        {

            if (defaultlength < length)
            {
                GameObject obj;
                for (int i = 0; i < length - defaultlength; i++)
                {
                    obj = Instantiate(inputPanel, param.transform);
                    obj.name = "param" + (i+ defaultlength + 1).ToString();
                    obj = Instantiate(inputPanel, subParam.transform);
                    obj.name = "param" + (i + defaultlength + 1).ToString();
                    obj = Instantiate(DDPanel, techType.transform);
                    obj.name = "param" + (i + defaultlength + 1).ToString();
                    OptionsChange(obj.transform.Find("Dropdown").GetComponent<Dropdown>(), techTypelist);
                    obj.name = "param" + (i + defaultlength + 1).ToString();
                    obj = Instantiate(DDPanel, condition.transform);
                    obj.name = "param" + (i + defaultlength + 1).ToString();
                    OptionsChange(obj.transform.Find("Dropdown").GetComponent<Dropdown>(), conditionlist);
                    obj = Instantiate(DDPanel, target.transform);
                    obj.name = "param" + (i+ defaultlength + 1).ToString();
                    OptionsChange(obj.transform.Find("Dropdown").GetComponent<Dropdown>(), targetlist);
                    arealist.Add((i+1+ defaultlength).ToString());   
                }

            }
            else
            {
                for(int i = 0;i< defaultlength - length; i++)
                {
                    Destroy(param.transform.Find("param" + (defaultlength - i).ToString()).gameObject);
                    Destroy(subParam.transform.Find("param" + (defaultlength - i).ToString()).gameObject);
                    Destroy(techType.transform.Find("param" + (defaultlength - i).ToString()).gameObject);
                    Destroy(condition.transform.Find("param" + (defaultlength - i).ToString()).gameObject);
                    Destroy(target.transform.Find("param" + (defaultlength - i).ToString()).gameObject);
                    arealist.Remove((defaultlength - i).ToString());
                }
            }
            foreach (string s in arealist) 
            {
                Debug.Log("エリアリスト"+s);
            }
            OptionsChange(angleDD,arealist);
            card.SetparamLength(length);
        }
    }
    void OptionsChange(Dropdown obj,List<string> list)
    {
        try
        {
            obj.ClearOptions();
        }catch(Exception e)
        {
            Debug.LogError(list.ToString());
            Debug.LogError(e);
        }
            obj.AddOptions(list);
    }

    public void GetArea()
    {
        paraindex = angleDD.value;
        int[] ID = new int[18];
        for (int i = 0;i< Areas.Length; i++)
        {
            if (Areas[i].isOn) ID[i] = 1;
            else ID[i] = 0;                        
        }
        card.SetareaID(paraindex, ID);
    }

    public void AngleChanged()
    {
        paraindex = angleDD.value;
        card.Setangle(paraindex,angletoggle.isOn); 
    }

    public void Save()
    {
        card.SetcardName(cardnameIF.text);
        card.SetparamLength(paramlengthDD.value+1);
        card.SetElement(elementDD.GetComponent<Dropdown>().value);
        for (int i = 0; i < card.GetparamLength(); i++)
        {
            card.Setparam(i,int.Parse(param.transform.Find("param" + (i + 1)).transform.Find("InputField").GetComponent<InputField>().text));
            card.Setsubparam(i,int.Parse(subParam.transform.Find("param" + (i + 1)).transform.Find("InputField").GetComponent<InputField>().text));
            card.SetTechtype(i,techType.transform.Find("param" + (i + 1)).transform.Find("Dropdown").GetComponent<Dropdown>().value);
            card.SetTarget(i ,target.transform.Find("param" + (i + 1)).transform.Find("Dropdown").GetComponent<Dropdown>().value);
            card.SetCondition(i,condition.transform.Find("param" + (i + 1)).transform.Find("Dropdown").GetComponent<Dropdown>().value);
        }
        card.Dump();
        Debug.Log(card.GetJson());
    }
}
