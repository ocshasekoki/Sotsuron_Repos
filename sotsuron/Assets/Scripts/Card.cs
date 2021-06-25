using Data;
using System;
using UnityEngine;

[Serializable]
public class Card :MonoBehaviour
{
    [SerializeField] private string cardname;       //カードの名前
    [SerializeField] private int paramlength;       //カードの名前
    [SerializeField] private int[] param;           //基礎数値
    [SerializeField] private int[] subparam;        //判定数値(default 0)
    [SerializeField] private AreaID[] areaID;       //エリアID
    [SerializeField] private bool[] angleSelected;  //trueの時エリア指定 falseの時前方にする
    [SerializeField] private Elements element;      //属性
    [SerializeField] private Conditions[] con;      //状態
    [SerializeField] private TechType[] type;       //技のタイプ
    [SerializeField] private Targets[] target;      //ターゲット

    public void SetcardName(string name)
    {
        cardname = name;
    }
    public string GetcardName()
    {
        return cardname;
    }
    public void SetparamLength(int length)
    {
        paramlength = length;
    }
    public int GetparamLength()
    {
        return paramlength;
    }
    public void Setparam(int index,int param)
    {
        this.param[index] = param;
    }
    public int Getparam(int index)
    {
        return param[index];
    }
    public void Setsubparam(int index, int param)
    {
        this.subparam[index] = param;
    }
    public int Getsubparam(int index)
    {
        return subparam[index];
    }
    public void SetareaID(int index,int[] param)
    {
        areaID[index].SetID(param);
    }
    public int[] GetareaID(int index)
    {
        return areaID[index].GetID();
    }
    public void Setangle(int index, bool angle)
    {
        angleSelected[index] = angle;
    }
    public bool Getangle(int index)
    {
        return angleSelected[index];
    }
    public void SetElement(int param)
    {
        element = (Elements)param;
    }
    public Elements GetElement()
    {
        return element;
    }
    public void SetCondition(int index,int param)
    {
        con[index] = (Conditions)param;
    }
    public Conditions GetCondition(int index)
    {
        return con[index];
    }
    public void SetTechtype(int index, int param)
    {
        type[index] = (TechType)param;
    }
    public TechType GetTechtype(int index)
    {
        return type[index];
    }
    public void SetTarget(int index, int param)
    {
        target[index] = (Targets)param;
    }
    public Targets GetTarget(int index)
    {
        return target[index];
    }
    public void Setlength(int length)
    {
        param = new int[length];
        subparam = new int[length];
        areaID = new AreaID[length];
        for(int i = 0;i < length; i++)
        {
            areaID[i] = new AreaID();
        }
        type = new TechType[length];
        con = new Conditions[length];
        target = new Targets[length];
        angleSelected = new bool[length];
    }
    public string GetJson()
    {
        return JsonUtility.ToJson(this,true);
    }
    public void Dump()
    {
        Debug.Log("名前：" +cardname);
        Debug.Log("パラメータ長：" +paramlength);
        Debug.Log("属性：" + element);

        int count = 0;
        for (int i = 0; i < paramlength; i++)
        {
            count++;
            Debug.Log("パラメータ" + count + "：" + i);
            Debug.Log("サブパラメータ" + count + "：" + i);
            Debug.Log("キャラ配置依存：" + angleSelected[i]);
            Debug.Log("状態変化：" + con[i]);
            Debug.Log("技のタイプ：" + type[i]);
            Debug.Log("ターゲット：" + target[i]);
            Debug.Log("＊＊＊＊＊＊＊＊エリア＊＊＊＊＊＊＊＊");
            string str = "";
            int[] id = areaID[i].GetID();
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 6; k++)
                {
                    str += "  " + id[j * 6 + k];
                }
            }
            Debug.Log(str);
            Debug.Log("＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊");
        }
    }
    [Serializable]
    public class AreaID
    {
        [SerializeField] private int[] ID;
        public void SetID(int[] id)
        {
            ID = id;
        }
        public int[] GetID()
        {
            return ID;
        }
    }
}
