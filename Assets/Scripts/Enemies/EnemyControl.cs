using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour
{
    [Header ("Data")]
    public EnemyData enemyData;

    [Header("Life")]
    private int actualLife;
    [SerializeField] private Slider lifeBar;

    [Header ("Components")]
    [SerializeField] private ParticleSystem partSystem;
    private SpriteRenderer SR;
    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        actualLife = enemyData.life;
        lifeBar.value = actualLife;
    }

    public void TakeDamage()
    {
        actualLife --;
        
        lifeBar.value = actualLife;
        if (actualLife <= 0)
        {
            StartCoroutine("PlayParticles");

        }
        else
        {
            Audio_Controller.Instance.PlaySound(enemyData.damagedClip);
        }
    }

    private IEnumerator PlayParticles()
    {
        Audio_Controller.Instance.PlaySound(enemyData.deathClip);
        SR.enabled = false;
        partSystem.Play();
        yield return new WaitForSeconds(0.5f);
        Death();
    }
    
    private void Death()
    {
        gameObject.SetActive(false);
    }
}
