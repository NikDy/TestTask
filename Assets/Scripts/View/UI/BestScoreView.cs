using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BestScoreView : MonoBehaviour
{
    
    public GameHandler gameHandler;
    private Text myText;

    private void Start()
    {
        myText = gameObject.GetComponent<Text>();
    }
    
    void Update()
    {
        myText.text = "Best score: " + gameHandler.bestScore.ToString();
    }
}
