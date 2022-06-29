using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesView : MonoBehaviour
{
    public GameHandler gameHandler;
    private Text myText;

    private void Start()
    {
        myText = gameObject.GetComponent<Text>();
    }

    void Update()
    {
         myText.text = "Lives: " + gameHandler.playerModel.lives.ToString();
    }
}
