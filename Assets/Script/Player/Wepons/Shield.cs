using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField, Tooltip("クールタイム")] float _attackInterval = 0;
    [SerializeField, Tooltip("敵に与えるダメージ")] int _damage = 0;
    [SerializeField, Tooltip("ノックバック")] int _knockBackPower = 0;
    [SerializeField, Tooltip("移動速度")] int _moveSpeed = 0;
    [SerializeField, Tooltip("生成数")] int _generatorNumber = 1;


    //　旋回するターゲット
    [SerializeField] private Transform _player;
    //　現在の角度
    private float angle;
    //　回転するスピード
    [SerializeField] private float _rotateSpeed = 180f;
    //　ターゲットからの距離
    [SerializeField] private Vector3 _distanceFromTarget = new Vector3(0f, 1f, 2f);


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Ak()
    {
        
    }

    void Move()
    {
        //　ユニットの位置 = ターゲットの位置 ＋ ターゲットから見たユニットの角度 ×　ターゲットからの距離
        transform.position = _player.position + Quaternion.Euler(0f, angle, 0f) * _distanceFromTarget;
        //　ユニット自身の角度 = ターゲットから見たユニットの方向の角度を計算しそれをユニットの角度に設定する
        transform.rotation = Quaternion.LookRotation(transform.position - new Vector3(_player.position.x, transform.position.y, _player.position.z), Vector3.up);
        //　ユニットの角度を変更
        angle += _rotateSpeed * Time.deltaTime;
        //　角度を0～360度の間で繰り返す
        angle = Mathf.Repeat(angle, 360f);
    }
}
