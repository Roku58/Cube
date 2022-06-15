using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythes : MonoBehaviour ,ISkill
{
    public SkillDef SkillId => SkillDef.Scythes;
    List<GameObject> _weaps = new List<GameObject>();
    int _skillLevel = 0;
    float _timer = 0;
    public float _cooldown { get; set; } = 2;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _cooldown)
        {
            ActiveSkill();
            _timer -= _cooldown;
        }
    }
    public void SetUp()
    {
        var skill = Instantiate(Resources.Load<GameObject>("Skills/Whip"), transform.position, Quaternion.identity);
        skill.transform.SetParent(transform);
        _weaps.Add(skill);
    }



    public void LevelUp()
    {
        _skillLevel++;
        switch (_skillLevel)
        {
            case 2:
                _weaps.Add(Instantiate(Resources.Load<GameObject>("Skills/Whip"), transform.position, Quaternion.identity));
                break;
            case 3:

                foreach (var a in _weaps)
                {

                }
                break;
            case 4:
                break;
            case 5:

                foreach (var a in _weaps)
                {

                }
                break;
            default:
                break;
        }
    }

    public  void ActiveSkill()
    {
        PlayerState _moveController = FindObjectOfType<PlayerState>();

        //var rote = transform.rotation;
        //var firstRote = 0f;
        //var secondRote = 0f;

        //if (_moveController.Lastdir.y == 1)
        //{
        //    firstRote = 90f;
        //}
        //else if (_moveController.Lastdir.y == -1)
        //{
        //    firstRote = 270f;
        //}
        //else if (_moveController.Lastdir.x == 1)
        //{
        //    firstRote = 0f;
        //}
        //else if (_moveController.Lastdir.x == -1)
        //{
        //    firstRote = 180f;
        //}

        //foreach (var a in _weaps)
        //{
        //    rote = Quaternion.Euler(0.0f, 0.0f, firstRote + secondRote);
        //    a.transform.position = _moveController.gameObject.transform.position;
        //    a.transform.rotation = rote;
        //    a.SetActive(true);
        //    StartCoroutine(Method.DelayMethod(0.15f, () => a.SetActive(false)));
        //    secondRote += 180;
        //}
    }
}
