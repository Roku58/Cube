using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] PlayerState player;
    [SerializeField] Slider lifeber = default;
    [SerializeField] Slider expber = default;
    [SerializeField] GameObject levelui;
    int playerLevel ;
    int maxHp;
    int hp;
    int maxExp;
    int exp;
    void Start()
    {
        //// スライダーを取得する
        //lifeber = GameObject.Find("LifeBer").GetComponent<Slider>();
        //expber = GameObject.Find("EXPbar").GetComponent<Slider>();

        playerLevel = player.level;
        maxHp = player.playerMaxLife;
        maxExp = player.expPool;
        hp = player.playerLife;
        exp = player.exp;

        //スライダーの最大値の設定
        lifeber.maxValue = maxHp;
        expber.maxValue = maxExp;
        //スライダーの現在値の設定
        lifeber.value = hp;
        expber.value = exp;
    }


    void Update()
    {
        //levelui.GetComponent<Text>().text = "Level:" + playerLevel;
        maxHp = player.playerMaxLife;
        maxExp = player.expPool;
        hp = player.playerLife;
        exp = player.exp;

        //スライダーの最大値の設定
        lifeber.maxValue = maxHp;
        expber.maxValue = maxExp;

        //スライダーの現在値の設定
        lifeber.value = hp;
        expber.value = exp;
    }
}