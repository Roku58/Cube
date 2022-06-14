using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerState player;
    [SerializeField] Slider lifeber = default;
    [SerializeField] Slider expber = default;
    [SerializeField] Slider spber = default;
    [SerializeField] TextMeshProUGUI level;
    [SerializeField] TextMeshProUGUI life;
    int playerLevel ;
    int maxHp;
    int hp;
    int maxExp;
    int exp;
    int _maxSp;
    int _sp;
    void Start()
    {
        playerLevel = GameManager.Level;
        maxHp = player.MaxLife;
        maxExp = GameManager.Instance.ExpPool;
        _maxSp = player.MaxSp;
        _sp = player.Sp;
        hp = player.Life;
        exp = GameManager.Instance.Exp;

        //スライダーの最大値の設定
        lifeber.maxValue = maxHp;
        expber.maxValue = maxExp;
        spber.maxValue = _maxSp;
        //スライダーの現在値の設定
        lifeber.value = hp;
        expber.value = exp;
        spber.value = _sp;
    }


    void Update()
    {
        playerLevel = GameManager.Level;
        maxHp = player.MaxLife;
        maxExp = GameManager.Instance.ExpPool;
        _maxSp = player.MaxSp;
        _sp = player.Sp;
        hp = player.Life;
        exp = GameManager.Instance.Exp;

        //スライダーの最大値の設定
        lifeber.maxValue = maxHp;
        expber.maxValue = maxExp;

        //スライダーの現在値の設定
        lifeber.value = hp;
        expber.value = exp;
        spber.value = _sp;
        level.text = "LEVEL:" + playerLevel;
        life.text = "LIFE:" + hp + "/" + maxHp;
    }
}