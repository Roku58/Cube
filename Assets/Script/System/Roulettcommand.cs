using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roulettcommand : MonoBehaviour
{
    [SerializeField] Image[] commandlist;
    private float countTime;
    private int lastTime;
    private float fireTime;
    private float speed = 10;
    bool isStop = false;
    private float lottery;
    bool justOnce = true;

    void Start()
    {

    }

    void Update()
    {
        //タイマーA
        countTime += Time.deltaTime * speed;

        if (countTime > commandlist.Length)
        {
            countTime = 0f;
        }

        //タイマーB
        fireTime += Time.deltaTime;

        if (lastTime != (int)countTime)
        {
            fireTime = 0f;
            foreach (var command in commandlist)
            {
                command.color = new Color(1, 1, 1);
            }
            lastTime = (int)countTime;
            commandlist[(int)countTime].color = new Color(1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStop = true;
            lottery = Random.Range(990, 997) * 0.001f;
        }

        if (isStop)
        {
            speed *= lottery;
        }

        if (fireTime >= 2.5 && justOnce)
        {
            fireTime = 0;
            justOnce = false;
            //(int)countTimeを他スクリプトに送信
        }
    }

    public void startRoulett()
    {
        isStop = false;
        speed = 10;
        justOnce = true;
        countTime = 0;
        fireTime = 0;
    }
}