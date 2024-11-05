using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/Data",order = 1)]
public class PlayerData : ScriptableObject
{
    [Header ("Life")]
    public int maxLife;
    public int actualLife;

    [Header("DamageRebound")]
    public Vector2 impactVelocity;

    [Header ("Movement")]
    public float walkSpeed;
    public float runSpeed;

    [Header("Jump")]
    public KeyCode jumpKey;
    public float jumpForce;
    public float gravity;
    public float feetRadius;
    public LayerMask ground;
    public bool inGround;
    

    [Header("Shot")]
    public KeyCode shotKey; 
    public float shotCadency;
    public int maxAmmo;
    public int actualAmmo;

    [Header("Sounds")]
    public AudioClip jumpClip;
    public AudioClip landClip;
    public AudioClip shootClip;
    public AudioClip damagedClip;
    public AudioClip deathClip;
    public AudioClip healthClip;


    public void TakeDamage(){
        actualLife--;
    }

    public void RestLife()
    {
        actualLife = maxLife;
    }

    public void SetAmmo()
    {
        actualAmmo = maxAmmo;
    }
}
