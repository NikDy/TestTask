using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class EnemyController
{
    public GameHandler parentHandler { private get; set; }
    public EnemyModel model { get; private set; }
    public EnemyView view { get; private set; }

    private PlayerModel playerModel;


    public EnemyController(EnemyModel model, EnemyView view, GameHandler parentHandler, PlayerModel playerModel)
    {
        this.model = model;
        this.view = view;
        this.parentHandler = parentHandler;
        this.playerModel = playerModel;

        this.parentHandler.MoveUpdate += NextMove;
        view.SetPosition(this.model.PosNRotation);
        view.GetComponent<SpriteRenderer>().enabled = true;
    }

    ~EnemyController()
    {
        DestroyView();
    }

    private void SetPosition(Vector4 pos)
    {
        this.model.PosNRotation = pos;
        this.view.SetPosition(this.model.PosNRotation);
    }

    private void NextMove()
    {
        if (Vector3.Distance(model.PosNRotation.AsVector3(), model.target.AsVector3()) >= model.moveStep && view.isActiveAndEnabled) { }
        else
        {
            model.target = new Vector4(Random.Range(-3.5f, 3.5f),
                                       Random.Range(-5.5f, 5.5f),
                                       model.PosNRotation.z,
                                       model.PosNRotation.r);
        }
        var nextPos = Vector3.MoveTowards(model.PosNRotation.AsVector3(), model.target.AsVector3(), model.moveSpeed * Time.deltaTime);
        this.model.PosNRotation = new Vector4(nextPos.x, nextPos.y, nextPos.z, 0);
        this.view.MoveTo(this.model.PosNRotation);
    }

    public void DestroyView()
    {
        this.parentHandler.MoveUpdate -= NextMove;
        GameObject.Destroy(view.gameObject);        
    }
}

