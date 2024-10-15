using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
     [Header ("Land")]
    private bool toLand;

    [Header ("Feets")]
    private Transform feetPos;

    [Header ("Data")]
    private PlayerData playerData;

    [Header ("Components")]
    private Rigidbody2D rb2D;
    private Animator animator;

    private void Awake() {
        playerData = GetComponent<Player_Controller>().playerData;
        feetPos = transform.GetChild(0).gameObject.transform;

        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        toLand = false;
    }

    private void Update() {
        bool isGrounded = Physics2D.OverlapCircle(feetPos.position, playerData.feetRadius, playerData.ground);
        playerData.inGround = isGrounded;
        animator.SetFloat("MoveY", rb2D.velocity.y); 
        animator.SetBool("IsGround", isGrounded);
        
        if (Input.GetKeyDown(playerData.jumpKey) && isGrounded)
        {
            toLand = true;
            //Audio_Controller.Instance.PlaySound(playerData.jumpSound);
            rb2D.AddForce(Vector2.up * playerData.jumpForce);
        }
        if (isGrounded && toLand && rb2D.velocity.y < 0)
        {
            toLand = false;
            //Audio_Controller.Instance.PlaySound(playerData.landSound);

        }
    }
    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(feetPos.position, 0.1f);
    }*/

}