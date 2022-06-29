using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour 
{

    private Vector3 target;


    private void Update()
    {
        gameObject.transform.position = target;
    }

    public void SetPosition(Vector4 pos)
    {
        gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }

    public void MoveTo(Vector4 pos)
    {
        target = pos.AsVector3();
    }
        
}