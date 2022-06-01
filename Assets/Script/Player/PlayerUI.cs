using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] PlayerState player;
    [SerializeField] Slider lifeber = default;
    [SerializeField] Slider expber = default;
    [SerializeField]TextMeshProUGUI level;
    [SerializeField] TextMeshProUGUI life;
    int playerLevel ;
    int maxHp;
    int hp;
    int maxExp;
    int exp;
    void Start()
    {
        //// �X���C�_�[���擾����
        //lifeber = GameObject.Find("LifeBer").GetComponent<Slider>();
        //expber = GameObject.Find("EXPbar").GetComponent<Slider>();
        //levelui.GetComponent<Text>().text = "Level:" + playerLevel;
        playerLevel = player._level;
        maxHp = player._playerMaxLife;
        maxExp = player._expPool;
        hp = player._playerLife;
        exp = player._exp;

        //�X���C�_�[�̍ő�l�̐ݒ�
        lifeber.maxValue = maxHp;
        expber.maxValue = maxExp;
        //�X���C�_�[�̌��ݒl�̐ݒ�
        lifeber.value = hp;
        expber.value = exp;
    }


    void Update()
    {
        playerLevel = player._level;
        maxHp = player._playerMaxLife;
        maxExp = player._expPool;
        hp = player._playerLife;
        exp = player._exp;

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