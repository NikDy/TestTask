using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    public PlayerModel model { get; private set; }
    public PlayerView view { get; private set; }
    public GameHandler parentHandler { get; private set; }
    public PlayerInput input { get; private set; }

    private float stepSize;

    public PlayerController(PlayerModel model, PlayerView view, PlayerInput input, GameHandler parentHandler)
    {
        this.model = model;
        this.view = view;
        this.input = input;
        this.parentHandler = parentHandler;

        this.input.OnPlayerInput += MoveTo;
        this.parentHandler.MoveUpdate += NextMove;
    }


    private void SetPosition(Vector4 pos)
    {
        this.model.PosNRotation = pos;
        this.view.SetPosition(this.model.PosNRotation);
    }

    private void MoveTo(Vector4 target)
    {
        this.model.target = target;
    }

    private void NextMove()
    {
        var nextPos = Vector3.MoveTowards(model.PosNRotation.AsVector3(), model.target.AsVector3(), Time.deltaTime * model.speed);
        this.model.PosNRotation = new Vector4(nextPos.x, nextPos.y, nextPos.z, 0);        
        this.view.MoveTo(this.model.PosNRotation);
        if (CheckEnemyCollisions())
        {
            this.model.lives -= 1;
            if (this.model.lives <= 0)
            {
                parentHandler.ChangeGameState(GAMESTATE.SCORESCREEN);
            }
        }
        if (CheckFoodCollisions())
        {
            this.model.points += 1;
        }

    }

    private bool CheckFoodCollisions()
    {
        foreach(var controller in parentHandler.GetFoodContollers())
        {
            if (Vector3.Distance(controller.model.PosNRotation.AsVector3(), this.model.PosNRotation.AsVector3()) < 1f)
            {
                controller.DestroyView();
                parentHandler.GetFoodContollers().Remove(controller);
                return true;
            }
        }
        return false;
    }

    private bool CheckEnemyCollisions()
    {
        foreach (var controller in parentHandler.GetEnemyControllers())
        {
            if (Vector3.Distance(controller.model.PosNRotation.AsVector3(), this.model.PosNRotation.AsVector3()) < 1f)
            {                
                controller.DestroyView();
                parentHandler.GetEnemyControllers().Remove(controller);
                return true;
            }
        }
        return false;
    }

}
