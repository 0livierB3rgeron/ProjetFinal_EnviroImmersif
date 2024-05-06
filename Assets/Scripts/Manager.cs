using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField]
    public ScoreDisplay scoreDisplay;
    [SerializeField]
    public GameObject gameOver;
    

    // Update is called once per frame
    void Update()
    {
        if (scoreDisplay.partieFinie)
        {
            gameOver.gameObject.SetActive(true);
        }
    }
}
