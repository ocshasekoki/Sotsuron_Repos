using Data;
using UnityEngine;

public class Card :MonoBehaviour
{
    public string cardname;     //カードの名前
    public int paramlength;     //カードの名前
    public int[] param;         //基礎数値
    public int[] subparam;      //判定数値(default 0)
    public int[] areaID;        //エリアID
    public bool[] areaSelected; //trueの時エリア指定 falseの時前方にする
    public Elements element;    //属性
    public Conditions[] con;    //状態
    public TechType[] type;     //技のタイプ
    public Targets[] target;    //ターゲット
}
