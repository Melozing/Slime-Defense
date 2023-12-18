using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealth : MonoBehaviour
{
    [SerializeField] private float itemHp;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            other.GetComponent<HealthPlayer>().AddHealth(itemHp);
            gameObject.SetActive(false);
        }
    }
}
