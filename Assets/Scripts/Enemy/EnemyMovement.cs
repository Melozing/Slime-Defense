using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    private SpriteRenderer spriteRenderer;
    public float speed = 4f;

    private void Awake() {
        player = GameObject.Find("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update() {
        if(player == null) return;
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if(transform.position.x < player.position.x){
            spriteRenderer.flipX = true;
        }else{
            spriteRenderer.flipX = false;
        }
    }
}
