using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{   
    
    public int timeLife {get; private set;}
    [SerializeField] private TextMeshProUGUI score;

    private void Start() {
            InvokeRepeating("IncreaseCount", 1f, 1f);
    }

    private void IncreaseCount(){
        timeLife ++;
        score.text = timeLife.ToString();
    }

}
