using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    public WeaponLeve[] weapons;
    public Animator[] animators;
    [SerializeField] float _cooltime;
    float _timer;

    private void Start()
    {
        //for (int i = 0; i < weapons.Length; i++)
        //{
        //    animators = weapons[i].GetComponent<Animator>
        //}


    }

    private void Update()
    {
        
        _timer += Time.deltaTime;
        if (_timer > _cooltime)
        {
            StartCoroutine("WeaponActive");
            _timer = 0;
        }

    }

    IEnumerator WeaponActive()
    {

        for (int i = 0; i < weapons.Length; i++)
        {
            if(weapons[i].canAtack)
            {
                if (weapons[i].weaponLevelIndex > 0)
                {
                    weapons[i].weaponLevel[weapons[i].weaponLevelIndex - 1].SetActive(true);
                    yield return new WaitForSeconds(weapons[i].waitTime);
                    weapons[i].weaponLevel[weapons[i].weaponLevelIndex - 1].SetActive(false);
                }
            }

        }
    }

}

[System.Serializable]
public class WeaponLeve
{
    public string weaponName;
    //public GameObject wepon;
    public GameObject[] weaponLevel;
    public int weaponLevelIndex;
    public float waitTime;
    public bool canAtack;
}