using System.Collections;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] private float startingHealthEnemy;
    public float currentHealthEnemy { get; private set; }
    private Animator anim;
    private bool dead;
    [SerializeField] private GameObject itemHPlv1;
    [SerializeField] private float dropChange = 0.1f;

    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer sprite;

    private void Start()
    {
        currentHealthEnemy = startingHealthEnemy;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }

    public void TakeDamageEnemy(float _damage)
    {
        currentHealthEnemy = Mathf.Clamp(currentHealthEnemy - _damage, 0, startingHealthEnemy);
        if (currentHealthEnemy > 0)
        {
            dead = false;
        }
        else
        {
            if (!dead)
            {
                AudioController.instance.PlayerDieSound();
                anim.SetTrigger("die");
                if (GetComponent<EnemyMovement>() != null) GetComponent<EnemyMovement>().enabled = false;
                if (GetComponent<Collider2D>() != null) GetComponent<Collider2D>().enabled = false;
                dead = true;
                Manager.Ins.EnemyKilled++;
                GameGUIManager.Ins.UpdatekilledCounting(Manager.Ins.EnemyKilled);
            }
        }
    }

    private bool isDead()
    {
        return dead;
    }

    private IEnumerator Invulnerability()
    {
        // Physics2D.IgnoreLayerCollision(6,7,true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            sprite.color = Color.gray;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            sprite.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        // Physics2D.IgnoreLayerCollision(6,7,false);
    }
    private void DeactivateEnemy()
    {
        Destroy(gameObject);
        if (UnityEngine.Random.value <= dropChange)
        {
            SpawnItem();
        }

    }
    private void SpawnItem()
    {
        if (Manager.Ins.m_isGameover) return;
        Instantiate(itemHPlv1, transform.position, Quaternion.identity);
    }

}
