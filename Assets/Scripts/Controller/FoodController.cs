using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class FoodController
{
    public GameHandler parentHandler { private get; set; }
    public FoodModel model { get; private set; }
    public FoodView view { get; private set; }


    public FoodController(FoodModel model, FoodView view, GameHandler parentHandler)
    {
        this.model = model;
        this.view = view;
        this.parentHandler = parentHandler;

        view.SetPosition(this.model.PosNRotation);
        view.GetComponent<SpriteRenderer>().enabled = true;
    }

    ~FoodController()
    {
        DestroyView();
    }

    private void SetPosition(Vector4 pos)
    {
        this.model.PosNRotation = pos;
        this.view.SetPosition(this.model.PosNRotation);
    }


    public void DestroyView()
    {
        GameObject.Destroy(view.gameObject);
    }

}
