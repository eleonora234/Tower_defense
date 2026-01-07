using System.Collections.Generic;
using UnityEngine;

public class PoweBase : MonoBehaviour
{
    [Header("settings")]
    public float range = 1.5f;
    public int damage = 1;
    public float shootRate = 1;

    float shootTimer = 1;
   


    [Header("Components")]
    public SpriteRenderer towerSpriteRenderer;
    public SpriteRenderer rangeSpriteRenderer;
    public towertrigger trigger;

    public void Awake()
    {
        rangeSpriteRenderer.transform.localScale = new Vector3(range * 2, range * 2, 1);
    }




    public void Update()
    {
        if (shootTimer < shootRate)
             shootTimer += Time.deltaTime;

        if (trigger.IsEnemyInView() && shootTimer >= shootRate)
        {
             Shoot();
             shootTimer = 0; 
        }
    }

    public void Shoot()
    {
        List<BaseEnemy> enemiesInView = trigger.GetEnemiesInView();

        int biggerPathIndex = -1;
        BaseEnemy target = null;
        foreach(BaseEnemy enemy in enemiesInView)
        {
            if(enemy.TargetPathIndex > biggerPathIndex)
            {
                biggerPathIndex = enemy.TargetPathIndex;
                target = enemy;
            }
        }

        if (target != null)
        {
            target.Hit(damage);
        }

        Debug.Log("Bang");
    }
}
