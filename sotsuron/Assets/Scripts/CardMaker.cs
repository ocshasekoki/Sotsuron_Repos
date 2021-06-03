using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardMaker : MonoBehaviour
{
    [SerializeField] GameObject cardnameIF = null;
    [SerializeField] GameObject paramlengthIF = null;
    [SerializeField] GameObject elementDD = null;
    [SerializeField] GameObject param = null;
    [SerializeField] GameObject subParam = null;
    [SerializeField] GameObject techType = null;
    [SerializeField] GameObject condition = null;
    [SerializeField] GameObject target = null;

    [SerializeField] GameObject inputPanel = null;
    [SerializeField] GameObject DDPanel = null;
    
    [SerializeField] List<string> techTypelist = null;
    [SerializeField] List<string> conditionlist = null;
    [SerializeField] List<string> targetlist = null;

    [SerializeField] Toggle[] Areas = null;
    int areaID;
    bool call = false;
    Card card;
    // Start is called before the first frame update
    void Start()
    {
        card = new Card();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeValue()
    {
        //パラメータ数の読み込み
        int length =int.Parse(paramlengthIF.transform.Find("Label").GetComponent<Text>().text);
        Debug.Log(length);
        if (card.paramlength != length)
        {
            //cardの長さを変更する
            card.param = new int[length];
            card.subparam = new int[length];
            card.areaID = new int[length];
            card.type = new Data.TechType[length];
            card.con = new Data.Conditions[length];
            card.target = new Data.Targets[length];

            if (card.paramlength < length)
            {
                GameObject obj;
                for (int i = 0; i < length - card.paramlength; i++)
                {
                    obj = Instantiate(inputPanel, param.transform);
                    obj.name = "param" + (i+ card.paramlength +1).ToString();
                    obj = Instantiate(inputPanel, subParam.transform);
                    obj.name = "param" + (i + card.paramlength + 1).ToString();
                    obj = Instantiate(DDPanel, techType.transform);
                    obj.name = "param" + (i + card.paramlength + 1).ToString();
                    OptionsChange(obj.transform.Find("Dropdown").GetComponent<Dropdown>(), techTypelist);
                    obj.name = "param" + (i + card.paramlength + 1).ToString();
                    obj = Instantiate(DDPanel, condition.transform);
                    obj.name = "param" + (i + card.paramlength + 1).ToString();
                    OptionsChange(obj.transform.Find("Dropdown").GetComponent<Dropdown>(), conditionlist);
                    obj = Instantiate(DDPanel, target.transform);
                    obj.name = "param" + (i+ card.paramlength +1).ToString();
                    OptionsChange(obj.transform.Find("Dropdown").GetComponent<Dropdown>(), targetlist);
                }
            }
            else
            {
                for(int i = 0;i< card.paramlength - length; i++)
                {
                    Destroy(param.transform.Find("param" + (card.paramlength - i).ToString()).gameObject);
                    Destroy(subParam.transform.Find("param" + (card.paramlength - i).ToString()).gameObject);
                    Destroy(techType.transform.Find("param" + (card.paramlength - i).ToString()).gameObject);
                    Destroy(condition.transform.Find("param" + (card.paramlength - i).ToString()).gameObject);
                    Destroy(target.transform.Find("param" + (card.paramlength - i).ToString()).gameObject);
                }
            }
            card.paramlength = length;
        }
    }
    void OptionsChange(Dropdown obj,List<string> list)
    {
        obj.ClearOptions();
        obj.AddOptions(list);
    }
    public void pushAreaChange()
    {
        if (!call)
        {

        }
    }
    public void GetArea()
    {
        
        areaID = 0;
        for (int i = 0;i<Areas.Length;i++)
        {
            int deb = 0;
            if (Areas[i].isOn)
            {
                areaID += (int)Math.Pow(2, i);
                deb = i;
            }           
        }
        Debug.Log(areaID);
        PlayerPrefs.SetInt("AREAID",areaID);
        SetArea();
    }
    public void SetArea()
    {
        string str = "";
        int count = 0;
        areaID = PlayerPrefs.GetInt("AREAID");
        for(int i = 131072; i > 0; i /= 2)
        {
            count++;
            if(areaID - i > 0)
            {
                str += "  " + ((Data.AreaIDs)Enum.ToObject(typeof(Data.AreaIDs), i)).ToString();
                areaID -= i;
            }
            else if(areaID -i == 0)
            {
                str += "  " + ((Data.AreaIDs)Enum.ToObject(typeof(Data.AreaIDs), i)).ToString();
                i = -1;
            }
            if(count %3 == 0)
            {
                str += "\n";
            }
        }
        Debug.Log(str);
    }
    
}
