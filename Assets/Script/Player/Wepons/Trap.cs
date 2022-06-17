using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour, ISkill
{
    [SerializeField] GameObject _trap;
    public SkillDef SkillId => SkillDef.Scythes;
    List<GameObject> _weaps = new List<GameObject>();
    int _skillLevel = 0;
    float _timer = 0;

    public void LevelUp()
    {
    }

    public void SetUp()
    {
    }

    public void SkillUpdate()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
