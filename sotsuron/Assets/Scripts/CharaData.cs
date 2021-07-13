using System;
using System.Collections.Generic;
using UnityEngine;
namespace Data
{
    [Serializable]
    public class CharaData : MonoBehaviour
    {
        [SerializeField] private string charaname;
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
        [SerializeField] private List<Card> hands = new List<Card>();
        //属性
        [SerializeField] private Elements element;
        public void Setname(string _name)
        {
            charaname = _name;
        }
        public void SetHp(int _hp)
        {
            hp = _hp;
        }
        public void SetATK(int _atk)
        {
            atk = _atk;
        }
        public void SetDF(int _df)
        {
            df = _df;
        }
        public void SetSPD(int _spd)
        {
            spd = _spd;
        }
        public void SetCtype(CharaType type)
        {
            ctype = type;
        }
        public void SetCon(Conditions _con)
        {
            con = _con;
        }
        public void SetDeck(Decks deck)
        {
            dec = deck;
        }
        public List<Card> GetDeck()
        {
            return dec.GetDeck();
        }
        public void SetElement(Elements e)
        {
            element = e;
        }
        public void AddHands(Card c)
        {
            hands.Add(c);
        }
        public void RemoveHands(Card c)
        {
            hands.Remove(c);
        }
        public void DrowCard(int number)
        {
            int index;
            List<Card> deck = dec.GetDeck();
            for (int i = 0; i<number; i++)
            {
                index = UnityEngine.Random.Range(0, deck.Count-1);
                hands.Add(deck[index]);
                dec.RemoveCard(index);
            }
        }

        public void Dump()
        {
            Debug.Log("HP:" + hp+" ATK:" + atk+" DF:" + df+ " SPD:" + spd+" キャラタイプ:" + ctype+" 状態:" + con+" 属性:" + element);
            foreach(Card c in dec.GetDeck())
            {
                c.Dump();
            }
            foreach (Card c in hands)
            {
                c.Dump();
            }
        }
    }
    [Serializable]
    public class Decks
    {
        [SerializeField]private List<Card> cards;

        public void ClearDeck()
        {
            cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }
        public void RemoveCard(Card card)
        {   
            cards.Remove(card);
        }
        public void RemoveCard(int index)
        {

            cards.RemoveAt(index);
        }
        public List<Card> GetDeck()
        {
            return cards;
        }
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
