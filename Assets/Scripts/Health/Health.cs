using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;}
    private Animator anim;
    private bool dead;
    
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    [SerializeField] private GameObject gun;
    private SpriteRenderer spriteRenderer;
    
    private void Start() {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage){
        currentHealth = Mathf.Clamp(currentHealth - _damage,0,startingHealth);
        if(currentHealth > 0){
            StartCoroutine(Invulnerability());
        }else{
            if(!dead){
                if(gun!=null)  gun.SetActive(false);
                anim.SetTrigger("die");
                if(GetComponent<EnemyMovement>()!=null)  GetComponent<EnemyMovement>().enabled = false;
                if(GetComponent<TankerMovement>()!=null) GetComponent<TankerMovement>().enabled = false;
                
                dead = true;
            }
        }
    }
    public void AddHealth(float _item){
        currentHealth = Mathf.Clamp(currentHealth + _item, 0, startingHealth);
    }

    private IEnumerator Invulnerability(){
        // Physics2D.IgnoreLayerCollision(6,7,true);
        for(int i=0;i<numberOfFlashes;i++){
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes*2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes*2));
        }
        // Physics2D.IgnoreLayerCollision(6,7,false);
    }
    private void Deactivate(){
        Destroy(gameObject);
    }
}
