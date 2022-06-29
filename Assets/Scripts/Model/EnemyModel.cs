using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class EnemyModel
{
    public Vector4 PosNRotation { get; set; }
    public float moveSpeed { get; set; }
    public float rotationSpeed { get; set; }
    public Vector4 target { get; set; }
    public float moveStep { get; set; }

    public EnemyModel(Vector4 posNRotation, float moveSpeed, float rotationSpeed)
    {
        PosNRotation = posNRotation;
        this.moveSpeed = moveSpeed;
        this.rotationSpeed = rotationSpeed;
        this.target = this.PosNRotation;
        this.moveStep = 0.001f;
    }
}

