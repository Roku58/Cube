using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField, Tooltip("�N�[���^�C��")] float _attackInterval = 0;
    [SerializeField, Tooltip("�G�ɗ^����_���[�W")] int _damage = 0;
    [SerializeField, Tooltip("�m�b�N�o�b�N")] int _knockBackPower = 0;
    [SerializeField, Tooltip("�ړ����x")] int _moveSpeed = 0;
    [SerializeField, Tooltip("������")] int _generatorNumber = 1;


    //�@���񂷂�^�[�Q�b�g
    [SerializeField] private Transform _player;
    //�@���݂̊p�x
    private float angle;
    //�@��]����X�s�[�h
    [SerializeField] private float _rotateSpeed = 180f;
    //�@�^�[�Q�b�g����̋���
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
        //�@���j�b�g�̈ʒu = �^�[�Q�b�g�̈ʒu �{ �^�[�Q�b�g���猩�����j�b�g�̊p�x �~�@�^�[�Q�b�g����̋���
        transform.position = _player.position + Quaternion.Euler(0f, angle, 0f) * _distanceFromTarget;
        //�@���j�b�g���g�̊p�x = �^�[�Q�b�g���猩�����j�b�g�̕����̊p�x���v�Z����������j�b�g�̊p�x�ɐݒ肷��
        transform.rotation = Quaternion.LookRotation(transform.position - new Vector3(_player.position.x, transform.position.y, _player.position.z), Vector3.up);
        //�@���j�b�g�̊p�x��ύX
        angle += _rotateSpeed * Time.deltaTime;
        //�@�p�x��0�`360�x�̊ԂŌJ��Ԃ�
        angle = Mathf.Repeat(angle, 360f);
    }
}
