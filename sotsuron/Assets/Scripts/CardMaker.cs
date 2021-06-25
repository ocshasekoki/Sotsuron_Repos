using Data;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CardMaker : MonoBehaviour
{
    [SerializeField] private InputField cardnameIF = null;
    [SerializeField] private Dropdown paramlengthDD = null;
    [SerializeField] private Dropdown elementDD = null;
    [SerializeField] private GameObject param = null;
    [SerializeField] private GameObject subParam = null;
    [SerializeField] private GameObject techType = null;
    [SerializeField] private GameObject condition = null;
    [SerializeField] private GameObject target = null;
    [SerializeField] private Dropdown angleDD = null;
    [SerializeField] private Toggle angletoggle = null;

    //Prefab
    [SerializeField] private GameObject inputPanel = null;
    [SerializeField] private GameObject DDPanel = null;

    private List<string> techTypelist = null;
    private List<string> conditionlist = null;
    private List<string> targetlist = null;
    private List<string> arealist = new List<string>();

    [SerializeField] private Toggle[] areas = null;
    private int paraindex;
    private Card card;
    
    private void Start()
    {
        card = new Card();
        SetDDValue();
        ChangeValue();
    }
    /// <summary>
    /// ステータスの長さを変更した時にオブジェクトの量を変えるメソッド
    /// </summary>
    public void ChangeValue()
    {
        int length = paramlengthDD.value + 1;
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
                    obj.name = "param" + (i + defaultlength + 1).ToString();
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
                    obj.name = "param" + (i + defaultlength + 1).ToString();
                    OptionsChange(obj.transform.Find("Dropdown").GetComponent<Dropdown>(), targetlist);
                    arealist.Add((i + 1 + defaultlength).ToString());
                }

            }
            else
            {
                for (int i = 0; i < defaultlength - length; i++)
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
                Debug.Log("エリアリスト" + s);
            }
            OptionsChange(angleDD, arealist);
            card.SetparamLength(length);
        }
    }
    /// <summary>
    /// ドロップダウンにリストを反映させるメソッド
    /// </summary>
    /// <param name="obj">反映させるドロップダウン</param>
    /// <param name="list">登録するリスト</param>
    private void OptionsChange(Dropdown obj, List<string> list)
    {
        try
        {
            obj.ClearOptions();
        } 
        catch (Exception e)
        {
            Debug.LogError(list.ToString());
            Debug.LogError(e);
        }
        obj.AddOptions(list);
    }
    /// <summary>
    /// 選択したエリアを取得するメソッド
    /// </summary>
    public void GetArea()
    {
        int[] ID = new int[areas.Length];
        for (int i = 0; i < areas.Length; i++)
        {
            if (areas[i].isOn) ID[i] = 1;
            else ID[i] = 0;
        }
        card.SetareaID(paraindex, ID);
    }

    public void AngleChanged()
    {
        card.Setangle(paraindex, angletoggle.isOn);
    }

    public void AreaChanged()
    {
        paraindex = angleDD.value;
        int[] area = card.GetareaID(paraindex);
        if (area == null)
        {
            foreach(Toggle t in areas)
            {
                t.isOn = false;
            }
        }
        else
        {
            for(int i = 0; i < areas.Length; i++)
            {
                if (area[i] == 1) areas[i].isOn = true;
                else areas[i].isOn = false;
            }
        }
    }

    public void Save()
    {
        card.SetcardName(cardnameIF.text);
        card.SetparamLength(paramlengthDD.value + 1);
        card.SetElement(elementDD.GetComponent<Dropdown>().value);
        for (int i = 0; i < card.GetparamLength(); i++)
        {
            card.Setparam(i, int.Parse(param.transform.Find("param" + (i + 1)).transform.Find("InputField").GetComponent<InputField>().text));
            card.Setsubparam(i, int.Parse(subParam.transform.Find("param" + (i + 1)).transform.Find("InputField").GetComponent<InputField>().text));
            card.SetTechtype(i, techType.transform.Find("param" + (i + 1)).transform.Find("Dropdown").GetComponent<Dropdown>().value);
            card.SetTarget(i, target.transform.Find("param" + (i + 1)).transform.Find("Dropdown").GetComponent<Dropdown>().value);
            card.SetCondition(i, condition.transform.Find("param" + (i + 1)).transform.Find("Dropdown").GetComponent<Dropdown>().value);
        }
        card.Dump();
        OutputJson(card.GetcardName(), card.GetJson());
    }
    public static void OutputJson(string name, string str)
    {
        StreamWriter writer = new StreamWriter(Application.dataPath + "/card/" + name + ".json", false);
        writer.WriteLine(str);
        writer.Flush();
        writer.Close();
    }
    private void SetDDValue ()
    {
        string[] enumNames = Enum.GetNames(typeof(TechType));
        techTypelist = new List<string>(enumNames);
        enumNames = Enum.GetNames(typeof(Targets));
        targetlist = new List<string>(enumNames);
        enumNames = Enum.GetNames(typeof(Conditions));
        conditionlist = new List<string>(enumNames);
    }
}
