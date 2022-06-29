using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodView : MonoBehaviour 
{

    public void SetPosition(Vector4 pos)
    {
        gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }

}