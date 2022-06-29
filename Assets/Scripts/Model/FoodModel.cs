using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FoodModel
{
    public Vector4 PosNRotation { get; set; }

    public FoodModel(Vector4 posNRotation)
    {
        PosNRotation = posNRotation;
    }
}

