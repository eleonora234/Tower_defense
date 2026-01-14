using UnityEngine;

public class BaseEnemy : MonoBehaviour
{

    public Rigidbody2D body2d;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Collider2D enemycollider;
    public float speed = 20f;
    public int playerHitdamage = 1;
    public bool isSideSpriteTurnedRight;
    public int MaxHP = 2;
    public int moneyReward= 2;
    int currentHp = 2;
    bool active = true;
    bool isDead = false;


    levelManager LevelManager;
    int targetPathIndex = 0;

    public int TargetPathIndex => targetPathIndex;

    private void Awake()
    {
        LevelManager = FindAnyObjectByType<levelManager>();
        currentHp = MaxHP;  
            }

   

    public void Update()
    {
        if (!active) 
            { return; }

        Vector3 targetPosition = LevelManager.pathPoints[targetPathIndex].position;
        if (Vector3.Distance(transform.position, targetPosition) < 0.05f )
        {
            if (targetPathIndex + 1 < LevelManager.pathPoints.Count)
            {
                targetPathIndex++;
            }
            else 
            {
                TargetReached();
            }
        }
    }


   

    public void FixedUpdate()
    {
        Vector3 direction = (LevelManager.pathPoints[targetPathIndex].position - transform.position).normalized;

        body2d.linearVelocity = direction * speed;

        animator.SetFloat("NormalizeSpeedX", direction.x);
        animator.SetFloat("NormalizedSpeedY", direction.y);
      

        if (isSideSpriteTurnedRight)
        {
            spriteRenderer.flipX = (direction.x < 0);
        }

        else
        {
            spriteRenderer.flipX = (direction.x > 0);
        }


    }


    public void TargetReached()
    {
        active = false;
        PlayerManager playerManager = FindFirstObjectByType<PlayerManager>();
        if (playerManager != null)
        {
            playerManager.playerHit(playerHitdamage);
        }

        DestroyMe();
    }
    public void Hit (int damage)
    {
        currentHp -= damage; 
        spriteRenderer.color = Color.red;
        Invoke("ResetColor", 0.3f);

        if (currentHp <= 0 && !isDead)
        {
            isDead = true;
            enemycollider.enabled = false;
            PlayerManager playerManager = FindAnyObjectByType<PlayerManager>();
            if (playerManager != null)
            {
                playerManager.GainMoney(moneyReward);
            }
            DestroyMe();
        }

    }


    void ResetColor()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.white; 
        }
    }

    public void DestroyMe()
    {
        EnemySpawner enemySpawner = FindAnyObjectByType<EnemySpawner>();
        if(enemySpawner != null)
        {
            enemySpawner.OnEnemyDie(this);
        }    
       active = false;
       
       

        Destroy(gameObject);
    }
}
