using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 22f;
    [SerializeField] private float projectileRange = 10f;
    [SerializeField] private bool isEnemyProjectile = false;

    private Vector3 startPosition;
    public BulletManager bulletManager;

    private void Start()
    {
        startPosition = transform.position;
    }
    
    private void Update()
    {
        MoveProjectile();
    }
 
    public void UpdateProjectileRange(float projectileRange)
    {
        this.projectileRange = projectileRange;
    }

    public void UpdateMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();

        if (!other.isTrigger && enemyHealth || player) 
        {
            if ((player && isEnemyProjectile) || (enemyHealth && !isEnemyProjectile))
            {
                player?.TakeDamage(1, transform);
                enemyHealth?.TakeDamage(1);
            }
        }
    }

    private void MoveProjectile()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }
}
