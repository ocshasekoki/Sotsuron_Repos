using System;
using System.Collections.Generic;
using UnityEngine;
namespace Data
{
    [Serializable]
    public class CharaData : MonoBehaviour
    {
        //HP
        [SerializeField] private int hp;
        //攻撃力
        [SerializeField] private int atk;
        //防御力
        [SerializeField] private int df;
        //スピード
        [SerializeField] private int spd;
        //キャラクタタイプ
        [SerializeField] private CharaType ctype;
        //キャラクタの状態
        [SerializeField] private Conditions con;
        //デッキ
        [SerializeField] private Decks dec;
        //手札
        [SerializeField] private Card[] hands;
        //属性
        [SerializeField] private Elements element;

    }
    [Serializable]
    public class Decks
    {
        public Dictionary<int, Card> cards;
    }


    public enum Elements
    {
        FIRE,   //炎
        THUNDER,//雷
        WATER   //水
    }
    public enum CharaType
    {
        ATTACKER,   //攻撃職
        DEFENDER,   //タンク職
        SPEEDER,    //先制攻撃職
        HEARER,     //回復職
        JAMOR       //妨害職
    }
    //キャラクタの状態
    public enum Conditions
    {
        NOMAL,  //通常時
        POSION, //毒状態
        PARA,   //麻痺状態
        DESTROY //（AREA限定）破壊状態
    }
    //技の種類
    public enum TechType
    {
        ATTACK, //攻撃
        CARE,   //回復
        PLANT,  //設置
        BUFF    //状態変化
    }
    //ターゲットの種類
    public enum Targets
    {
        ALLY,          
        ALLIES,         
        ALLALLIES,      
        RANDOMALLYS,    
        ENEMY,         
        ENEMYS,        
        ALLENEMYS,      
        RANDOMENEMYS,   
        AREA,           
        RANDOMAREA,    
        ALLYAREA,       
        ENEMYAREA,      
        ALLAREA,        
    }
    public enum Areatype
    {
        UPPER,
        MIDDLE,
        LOWER
    }
}
