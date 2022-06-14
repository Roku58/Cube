using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] Item[] _prefab = null;
    [SerializeField] Transform _root = null;
    [SerializeField, Tooltip("�ő�X�|�[����")] int _prefabCapacity = 30;
    ObjectPool<Item> _itemPool = new ObjectPool<Item>();

    void Start()
    {
        //for(var i = 0; i < _prefab.Length; i++)
        //{
         
        //}
        _itemPool.SetBaseObj(_prefab[0], _root);
        _itemPool.SetCapacity(_prefabCapacity );
    }

    public Item Spawn()
    {
        var script = _itemPool.Instantiate();

        return script;
    }
}
