using System.Collections.Generic;
using UnityEngine;

public class towertrigger : MonoBehaviour
{

    List<BaseEnemy> enemiesInView = new List<BaseEnemy>();

    public List<BaseEnemy> GetEnemiesInView()
    { 
        return enemiesInView; 
    }
    public bool IsEnemyInView()
    {
        return enemiesInView.Count > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            BaseEnemy enemy = collision.gameObject.GetComponent<BaseEnemy>();
            if (enemy != null)
            {
                enemiesInView.Add(enemy);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            BaseEnemy enemy = collision.gameObject.GetComponent<BaseEnemy>();
            if (enemy != null)
            {
                enemiesInView.Remove(enemy);
            }
        }
    }
}
