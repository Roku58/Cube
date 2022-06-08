//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemySearch : MonoBehaviour
//{
//    [SerializeField, Tooltip("衝突させるレイヤー")] LayerMask _targetLayerMask = default;
//    [SerializeField, Tooltip("索敵")] float _radius = 1f;

//    private void OnDrawGizmosSelected()
//    {
//        Gizmos.color = Color.red;
//        Gizmos.DrawWireSphere(transform.position, _radius);
//    }

//    /// <summary>プレイヤーから最も近い敵を取得する </summary>
//    /// <returns>敵の位置</returns>
//    public Vector3 GetMostNearEnemy()
//    {
//        var nearEnemies = Physics2D.OverlapCircleAll(transform.position, _radius, _targetLayerMask);

//        if (nearEnemies.Length == 0)    //敵を取得出来なかったら
//        {
//            return Vector3.zero;
//        }
//        var nearEnemyCollider = nearEnemies.OrderBy(x => Vector2.Distance(transform.position, x.transform.position)).FirstOrDefault();
//        return nearEnemyCollider.transform.position;
//    }

//    /// <summary>プレイヤーから一定の範囲内にいる敵の位置を取得する </summary>
//    /// <returns>敵の位置</returns>
//    public Vector3 GetRandomEnemy()
//    {
//        var Enemies = Physics2D.OverlapCircleAll(transform.position, _radius, _targetLayerMask);
//        if (Enemies.Length == 0)    //敵を取得出来なかったら
//        {
//            return Vector3.zero;
//        }
//        var index = Random.Range(0, Enemies.Length - 1);
//        var nearEnemyCollider = Enemies[index];
//        return nearEnemyCollider.transform.position;
//    }
//}
