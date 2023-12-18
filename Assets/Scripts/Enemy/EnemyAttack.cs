using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage;

    private Animator anim;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioController.instance.HitSound();
            other.GetComponent<HealthPlayer>().TakeDamagePlayer(damage);
            anim.SetTrigger("explo");
        }
    }
}
