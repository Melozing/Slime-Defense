using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] private float startingHealthEnemy;
    public float currentHealthEnemy {get; private set;}
    private Animator anim;
    private bool dead;
    [SerializeField] private GameObject itemHPlv1;
    [SerializeField] private float dropChange = 0.1f;

    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer sprite;

    private void Start() {
        currentHealthEnemy = startingHealthEnemy;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }

    public void TakeDamageEnemy(float _damage){
        currentHealthEnemy = Mathf.Clamp(currentHealthEnemy - _damage,0,startingHealthEnemy);
        if(currentHealthEnemy > 0){

        }else{
            if(!dead){
                anim.SetTrigger("die");
                if(GetComponent<EnemyMovement>()!=null)  GetComponent<EnemyMovement>().enabled = false;
                if(GetComponent<Collider2D>()!= null) GetComponent<Collider2D>().enabled = false;
                dead = true;
            }
        }
    }

    private IEnumerator Invulnerability(){
        // Physics2D.IgnoreLayerCollision(6,7,true);
        for(int i=0;i<numberOfFlashes;i++){
            sprite.color = Color.gray;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes*2));
            sprite.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes*2));
        }
        // Physics2D.IgnoreLayerCollision(6,7,false);
    }
    private void DeactivateEnemy(){
        Destroy(gameObject);
        if(UnityEngine.Random.value <= dropChange){
            SpawnItem();
        }

    }
    private void SpawnItem(){
        Instantiate(itemHPlv1, transform.position, Quaternion.identity);

    }

}
