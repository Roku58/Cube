using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponsManager : MonoBehaviour
{
    public WeponLeve[] wepons;
    float _timer;

    private void Start()
    {
        
    }

    private void Update()
    {
        
        _timer += Time.deltaTime;
        if (_timer > 3)
        {
            StartCoroutine("WeponActive");
            _timer = 0;
        }

    }

    IEnumerator WeponActive()
    {
        for (int i = 0; i < wepons.Length; i++)
        {
            if (wepons[i].weponLevelIndex > 0)
            {
                wepons[i].weponLevel[wepons[i].weponLevelIndex - 1].SetActive(true);
                yield return new WaitForSeconds(2);
                wepons[i].weponLevel[wepons[i].weponLevelIndex - 1].SetActive(false);
            }
        }
    }

}

[System.Serializable]
public class WeponLeve
{
    public string weponName;
    public GameObject wepon;
    public GameObject[] weponLevel;
    public int weponLevelIndex;
}