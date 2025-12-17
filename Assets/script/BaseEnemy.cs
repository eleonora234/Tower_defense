using UnityEngine;

public class BaseEnemy : MonoBehaviour
{

    public Rigidbody2D body2d;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float speed = 20f;
    public bool isSideSpriteTurnedRight;

    levelManager LevelManager;
    int taretPathIndex = 0;

    private void Awake()
    {
        LevelManager = FindAnyObjectByType<levelManager>();
    }

    public void Update()
    {
        Vector3 targetPosition = LevelManager.pathPoints[taretPathIndex].position;
        if (Vector3.Distance(transform.position, targetPosition) < 0.05f )
        {
            if (taretPathIndex + 1 < LevelManager.pathPoints.Count)
            {
                taretPathIndex++;
            }
        }
    }


    public void FixedUpdate()
    {
        Vector3 direction = (LevelManager.pathPoints[taretPathIndex].position - transform.position).normalized;

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

}
