using Data;
using System;
using UnityEngine;

[Serializable]
public class Card :MonoBehaviour
{
    public string cardname;     //カードの名前
    public int paramlength;     //カードの名前
    public int[] param;         //基礎数値
    public int[] subparam;      //判定数値(default 0)
    public int[,] areaID = new int[3,6];       //エリアID
    public bool[] angleSelected;//trueの時エリア指定 falseの時前方にする
    public Elements element;  //属性
    public Conditions[] con;    //状態
    public TechType[] type;     //技のタイプ
    public Targets[] target;    //ターゲット

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
            for (int j = 0; j < areaID.GetLength(1); j++)
            {
                str += "  " + areaID[i, j];
            }
            Debug.Log(str);
            Debug.Log("＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊");
        }
    }
}
