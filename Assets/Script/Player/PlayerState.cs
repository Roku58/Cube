using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int level = 1;//���݃��x��
    public int exp = 0;//�o���l
    public int expPool = 100;//�K�v�o���l
    public int playerLife = 100;//�̗�
    public int playerMaxLife = 100;//�ő�̗�


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

    void LevelManagar()//���x���Ǘ�
    {
        if(exp == expPool)
        {
            LevelUp();
        }
    }

    void LevelUp()//���x�����オ�����ۂ̏���
    {
        exp = 0;
        playerMaxLife += 10;
        playerLife = playerMaxLife;
        expPool += 10;
        level ++;
    }

    void Damage()//�v���C���[�̗̑͂����炷
    {
        if(playerLife <= 0)
        {

        }
    }
}

