using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/Data",order = 1)]
public class PlayerData : ScriptableObject
{
    [Header ("Life")]
    public int maxLife;

    [Header ("Movement")]
    public float walkSpeed;
    public float runSpeed;

    [Header("Jump")]
    public KeyCode jumpKey;
    public float jumpForce;
    public float feetRadius;
    public LayerMask ground;
    public bool inGround;

    [Header("Shot")]
    public KeyCode shotKey; 
    public float shotCadency;
}
