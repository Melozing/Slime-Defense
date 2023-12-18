using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform rocketPoints;
    [SerializeField] private GameObject[] rockets;

    private float cooldownTime = Mathf.Infinity;

    private void Update() {
        if(Input.GetMouseButton(0) && cooldownTime > attackCooldown){
            AttackGun();
        }
        cooldownTime += Time.deltaTime;
    }

    private void AttackGun(){
        cooldownTime = 0;
        rockets[FindRocket()].transform.position = rocketPoints.position;
        rockets[FindRocket()].GetComponent<ProjectilesBullet>().SetRocket();
    }
    private int FindRocket(){
        for(int i=0; i < rockets.Length; i++){
            if(!rockets[i].activeInHierarchy) return i;
        }
        return 0;
    }
}
