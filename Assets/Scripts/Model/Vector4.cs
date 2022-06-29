using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Vector4
{
    public float x { get; set; }
    public float y;
    public float z;
    public float r;


    public Vector4(float x, float y, float z, float r)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.r = r;
    }

    public Vector3 AsVector3()
    {
        return new Vector3(x,y,z);
    }
}

