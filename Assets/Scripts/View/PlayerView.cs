using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{

    private Vector3 target;


    public void SetPosition(Vector4 pos)
    {
        gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }

    private void Update()
    {        
        transform.position = target;
    }

    public void MoveTo(Vector4 pos)
    {
        target = pos.AsVector3();        
    }

}
