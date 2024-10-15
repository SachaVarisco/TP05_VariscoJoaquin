using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("BulletData")]
    [SerializeField] private BulletData bulletData;

    [Header("Pool")]
    [SerializeField] private BulletPool pool;

    [Header("Player")]
    [SerializeField] private Transform playerLook;

    [Header("Timer")]
    private float currentTime;
    [Header("Direction")]
    private Vector2 direction;

    [Header("Components")]

    private SpriteRenderer SR;
    private Rigidbody2D rb2D;


    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        //playerLook = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnEnable()
    {
        currentTime = bulletData.lifeTime;
        if (playerLook.localScale.x == 1)
        {
            direction = -transform.right;
            SR.flipX = true;
        }
        else
        {
            SR.flipX = false;
            direction = transform.right;
        }
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        
        rb2D.velocity = direction * bulletData.speed;
        if (currentTime <= 0)
        {
            pool.ReturnBullet(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 7) //Enemies
        {
            
        }
        
    }
}
