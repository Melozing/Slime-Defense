using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using TMPro;

public class SpawnEnemys : MonoBehaviour
{
    
    [SerializeField] private Transform tanker;
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private float radius = 6.0f;
    // [SerializeField] private float spawnTime = 5f;
    [SerializeField] private Manager manager;

    private void Start() {
        InvokeRepeating("SpawnEnemy", 0, 5);
    }

    private void SpawnEnemy(){
        if(manager.timeLife < 30){
            for(int i =0; i<6; i++){
            float angle = UnityEngine.Random.Range(0,360);
            float xOffset = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
            float yOffset = radius * Mathf.Sin(angle * Mathf.Deg2Rad);

            Vector3 spawnPosition = tanker.position + new Vector3(xOffset, yOffset);
            Instantiate(enemy1, spawnPosition, Quaternion.identity);
            }
        }
        else if(manager.timeLife > 30 && manager.timeLife < 100 ){
            for(int i =0; i<7; i++){
            float angle = UnityEngine.Random.Range(0,360);
            float xOffset = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
            float yOffset = radius * Mathf.Sin(angle * Mathf.Deg2Rad);

            Vector3 spawnPosition = tanker.position + new Vector3(xOffset, yOffset);
            Instantiate(enemy2, spawnPosition, Quaternion.identity);
            }
        }
        
    }
    
    
}
