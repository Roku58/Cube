using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeSword : MonoBehaviour
{
    public GameObject[] Sword;
    [SerializeField] int weponLevel = 0;//ê∂ê¨êî
    //[SerializeField] GameObject effect;
    float cooltime = 10f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        timer += Time.deltaTime;
        if (timer <= cooltime)
        {
            for(int i = 0; i < weponLevel; i++)
            {
                Sword[i].SetActive(true);
                timer = 0;

            }
        }
    }

    void Off()
    {
        for (int i = 0; i < weponLevel; i++)
        {
            Sword[i].SetActive(false);

        }
    }
}
