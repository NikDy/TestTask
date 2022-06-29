using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class PlayerModel
{
    //Vector4 interpret object position by XYZ axis and rotation by Z axe.
    public Vector4 PosNRotation { get; set; }        
    public Vector4 target { get; set; }
    public float speed { get; set; }
    public int points { get; set; }
    public int lives { get; set; }


    public PlayerModel(Vector4 PosNRotation, int points, int lives, float speed)
    {
        this.PosNRotation = PosNRotation;
        this.points = points;
        this.lives = lives;
        this.speed = speed;
        this.target = this.PosNRotation;
    }

}
