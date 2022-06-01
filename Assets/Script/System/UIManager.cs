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
    [SerializeField] TextMeshProUGUI level;
    [SerializeField] TextMeshProUGUI life;
    int playerLevel ;
    int maxHp;
    int hp;
    int maxExp;
    int exp;
    void Start()
    {
        playerLevel = player.Level;
        maxHp = player.MaxLife;
        maxExp = player.ExpPool;
        hp = player.Life;
        exp = player.Exp;

        //�X���C�_�[�̍ő�l�̐ݒ�
        lifeber.maxValue = maxHp;
        expber.maxValue = maxExp;
        //�X���C�_�[�̌��ݒl�̐ݒ�
        lifeber.value = hp;
        expber.value = exp;
    }


    void Update()
    {
        playerLevel = player.Level;
        maxHp = player.MaxLife;
        maxExp = player.ExpPool;
        hp = player.Life;
        exp = player.Exp;

        //�X���C�_�[�̍ő�l�̐ݒ�
        lifeber.maxValue = maxHp;
        expber.maxValue = maxExp;

        //�X���C�_�[�̌��ݒl�̐ݒ�
        lifeber.value = hp;
        expber.value = exp;
        level.text = "LEVEL:" + playerLevel;
        life.text = "LIFE:" + hp + "/" + maxHp;
    }
}