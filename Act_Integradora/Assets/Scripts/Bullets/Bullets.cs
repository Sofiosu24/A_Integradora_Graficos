using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public BulletManager bulletManager;
    public float timeSinceLastSpawn = 0f;
    public int value = 0;
    public float death = 5f;

    private void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
        bulletManager.AddBullets();
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn > death)
        {
            bulletManager.RestBullets();
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.up * value * Time.deltaTime);
        }
    }
}
