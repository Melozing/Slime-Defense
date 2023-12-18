using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesBullet : MonoBehaviour
{
    private bool hit = false;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float lifeTime;
    [SerializeField] private Transform gunDirection;
    private float colldownTime;
    private Animator anim;
    private BoxCollider2D coll;
    private Rigidbody2D rb;
    [SerializeField] private GameObject fire;

    private void Start() {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        transform.rotation = gunDirection.transform.rotation;

    }
    private void OnEnable() {
        transform.rotation = gunDirection.transform.rotation;
        fire.SetActive(true);
    }

    private void Update() {
        if(hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(0, movementSpeed, 0);
        colldownTime += Time.deltaTime;
        if(colldownTime > lifeTime) gameObject.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            hit = true;
            fire.SetActive(false);
            anim.SetTrigger("activated");
            other.GetComponent<HealthEnemy>().TakeDamageEnemy(damage);
        }
    }

    public void SetRocket(){
        hit = false;
        colldownTime = 0;
        gameObject.SetActive(true);


    }

    public void Deactivate(){
        gameObject.SetActive(false);
    }
}
