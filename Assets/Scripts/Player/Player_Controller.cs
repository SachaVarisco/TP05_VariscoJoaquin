using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    [Header("PlayerData")]
    public PlayerData playerData;

    [Header("Components")]
    private Rigidbody2D rb2D;
    private Animator animator;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        playerData.actualLife = playerData.maxLife;
    }
    private void Update()
    {
        if (playerData.actualLife <= 0)
        {
            Audio_Controller.Instance.PlaySound(playerData.deathClip);
            animator.Play("Death");

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.transform.gameObject.layer)
        {
            case 7:
                if (playerData.actualLife > 0)
                {
                    Damaged(collision);
                }
                break;
            
            case 9:
                
                Audio_Controller.Instance.PlaySound(playerData.healthClip);
                collision.gameObject.SetActive(false);
                playerData.RestLife();
                
                
                break;
            case 11:
                SceneManager.LoadScene("Victory");
                break;
            case 12:
                Damaged(collision);
                break;

        }
    }

    public void StopForces()
    {
        rb2D.velocity = new Vector2(0, 0);
    }

    private void Damaged(Collision2D collision)
    {
        Audio_Controller.Instance.PlaySound(playerData.damagedClip);
        rb2D.velocity = new Vector2(-playerData.impactVelocity.x * collision.GetContact(0).normal.x, playerData.impactVelocity.y);
        animator.SetTrigger("Damaged");
        playerData.TakeDamage();
    }

}
