using System;
using UnityEngine;

public class Shot : MonoBehaviour, ISkill
{
    public SkillDef SkillId => SkillDef.Shot;
    public GameObject _bullet;

    float _interval = 0.5f;
    int _shotCount = 1;

    public void SetUp()
    {
        //Instantiate(bbb);
    }

    public void Update()
    {
    }


    public void SkillUpdate()
    {
        throw new NotImplementedException();
    }

    public void LevelUp()
    {
        _shotCount += 2;
    }
}
