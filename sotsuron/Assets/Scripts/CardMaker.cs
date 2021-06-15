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
    [SerializeField] GameObject angleDD = null;
    [SerializeField] GameObject angletoggle = null;

    //Prefab
    [SerializeField] GameObject inputPanel = null;
    [SerializeField] GameObject DDPanel = null;

    [SerializeField] List<string> techTypelist = null;
    [SerializeField] List<string> conditionlist = null;
    [SerializeField] List<string> targetlist = null;
    [SerializeField] List<string> arealist = null;

    [SerializeField] Toggle[] Areas = null;

    int areaID;
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
                    arealist.Add((i+1+card.paramlength).ToString());   
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
                    Destroy(target.transform.Find("param" + (card.paramlength - i).ToString()).gameObject);
                    arealist.Remove((card.paramlength - i).ToString());
                }
            }
            foreach (string s in arealist) 
            {
                Debug.Log("エリアリスト"+s);
            }
            OptionsChange(angleDD.GetComponent<Dropdown>(),arealist);
            card.paramlength = length;
        }
    }
    void OptionsChange(Dropdown obj,List<string> list)
    {
        obj.ClearOptions();
        obj.AddOptions(list);
    }

    public void GetArea()
    {
        int height = 0;
        areaID = 0;
        for (int i = 0;i< Areas.Length; i++)
        {
            if (i % 6 == 0 && i!=0)
            {
                height = i / 6;
            }
            if (Areas[i].isOn)
            {
                card.areaID[height, i % 6] = 1;
            }
            else
            {
                card.areaID[height, i % 6] = 0;
            }            
        }
        DebugArea(card.areaID);
    }

    public void PushAreaSelect()
    {

    }

    public void AngleChanged()
    {

    }
    public void TargetSelected()
    {
        
    }
    public void SetParam()
    {

    }
    public void SetSubParam()
    {

    }
    public void SetType()
    {

    }
    public void SetCondition()
    {

    }
    public void SetTarget()
    {

    }
    public void DebugArea(int[,] areaID)
    {
        for (int i = 0; i< areaID.GetLength(0); i++)
        {
            string str = "";
            for (int j = 0; j < areaID.GetLength(1); j++)
            {
                str +="\t"+ areaID[i, j];
            }
            Debug.Log(str);
        }
    }
}
