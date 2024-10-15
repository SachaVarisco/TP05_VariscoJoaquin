using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("BulletData")]
    private PlayerData playerData;

    [Header("Pool")]

    [SerializeField] private GameObject pool;

    [Header("Timer")]
    private float currentTime;

    [Header("Gun")]
    private Transform gun;

    private void Awake()
    {
        playerData = GetComponent<Player_Controller>().playerData;
        currentTime = playerData.shotCadency;
        gun = transform.GetChild(1).gameObject.transform;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        if (Input.GetKeyDown(playerData.shotKey))
        {
            GameObject Bullet = pool.GetComponent<BulletPool>().GetBullet();
            if (Bullet != null)
            {
                Bullet.transform.position = gun.position;
                Bullet.SetActive(true);

            }
            currentTime = playerData.shotCadency;
        }
    }

}

