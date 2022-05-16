using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int level = 1;//現在レベル
    public int exp = 0;//経験値
    public int expPool = 100;//必要経験値
    public int playerLife = 100;//体力
    public int playerMaxLife = 100;//最大体力


    void Start()
    {
        playerLife = playerMaxLife;
    }

    void Update()
    {
        LevelManagar();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Exp")
        {
            exp += 10;
            Destroy(collision.gameObject);
        }
    }

    void LevelManagar()//レベル管理
    {
        if(exp == expPool)
        {
            LevelUp();
        }
    }

    void LevelUp()//レベルが上がった際の処理
    {
        exp = 0;
        playerMaxLife += 10;
        playerLife = playerMaxLife;
        expPool += 10;
        level ++;
    }

    void Damage()//プレイヤーの体力を減らす
    {
        if(playerLife <= 0)
        {

        }
    }
}

