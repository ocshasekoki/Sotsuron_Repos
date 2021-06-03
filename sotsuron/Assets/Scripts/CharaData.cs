using System.Collections.Generic;
using UnityEngine;
namespace Data
{
    public class CharaData :MonoBehaviour
    {
        //HP
        public int hp;
        //攻撃力
        public int atk;            
        //防御力
        public int df;
        //スピード
        public int spd;
        //キャラクタタイプ
        public CharaType ctype;
        //キャラクタの状態
        public Conditions con;
        //デッキ
        public Decks dec;
        //手札
        public Card[] hands;
        //属性
        public Elements element;

    }
    public class Decks
    {
        public Dictionary<int,Card> cards;
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
        ALLY,           //味方一人
        ALLIES,         //味方複数
        ALLALLIES,      //味方全員
        RANDOMALLYS,    //ランダムな味方
        ENEMY,          //敵一人
        ENEMYS,         //敵複数人
        ALLENEMYS,      //敵全員
        RANDOMENEMYS,   //ランダムな敵の数
        AREA,           //特定エリア
        RANDOMAREA,     //ランダムのエリア
        ALLYAREA,       //味方エリア全体
        ENEMYAREA,      //敵エリア全体
        ALLAREA,        //エリア全体
    }
    public enum AreaIDs
    {
        ALLYUPPERLEFT = 1,
        ALLYUPPERCENTER = 2,
        ALLYUPPERRIGHT = 4,
        ALLYMIDDLELEFT = 8,
        ALLYMIDDLECENTER = 16,
        ALLYMIDDLERIGHT = 32,
        ALLYLOWERLEFT = 64,
        ALLYLOWERCENTER = 128,
        ALLYLOWERRIGHT = 256,
        ENEMYUPPERLEFT = 512,
        ENEMYUPPERCENTER = 1024,
        ENEMYUPPERRIGHT = 2048,
        ENEMYMIDDLELEFT = 4096,
        ENEMYMIDDLECENTER = 8192,
        ENEMYMIDDLERIGHT = 16384,
        ENEMYLOWERLEFT = 32768,
        ENEMYLOWERCENTER = 65536,
        ENEMYLOWERRIGHT = 131072,
    }
}
