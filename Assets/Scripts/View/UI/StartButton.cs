using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameHandler gameHandler;

    public void OnClick()
    {
        gameHandler.ChangeGameState(GAMESTATE.INGAME);
    }
}
