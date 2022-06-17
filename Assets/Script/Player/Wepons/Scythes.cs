using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythes : MonoBehaviour ,ISkill
{
    [SerializeField] GameObject _scythes;
    public SkillDef SkillId => SkillDef.Scythes;
    List<GameObject> _weaps = new List<GameObject>();
    int _skillLevel = 0;
    float _timer = 0;
    public float _cooldown { get; set; } = 2;

    public void SkillUpdate()
    {
        _timer += Time.deltaTime;
        if (_timer >= _cooldown)
        {
            StartCoroutine("ActiveSkill");
            _timer -= _cooldown;
        }
    }

    void Update()
    {
        SkillUpdate();
    }
    public void SetUp()
    {
        _skillLevel++;
        Debug.Log(_skillLevel);
        //var skill = Instantiate(_scythes);
        //skill.transform.SetParent(transform);
        //_weaps.Add(skill);
    }



    public void LevelUp()
    {
        _skillLevel++;
        Debug.Log(_skillLevel);


        switch (_skillLevel)
        {
            case 2:
                break;
            case 3:


                break;
            case 4:
                break;
            case 5:

                break;
            default:
                break;
        }
    }

    public IEnumerator ActiveSkill()
    {
        for(int i = 0; i <= _skillLevel;i++)
        {
            Instantiate(_scythes);
            yield return  (null);
        }
    }
}
