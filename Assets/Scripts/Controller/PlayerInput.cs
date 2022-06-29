using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public delegate void PlayerInputVector(Vector4 vec4);
    public event PlayerInputVector OnPlayerInput;

    void Update()
    {
        //if (Touchscreen.current.touches.Count > 0)
        //{
        //    
        //    var point = Camera.main.ScreenToWorldPoint(new Vector3(Touchscreen.current.primaryTouch.ReadValue().position.x,
        //                                                           Touchscreen.current.primaryTouch.ReadValue().position.y,
        //                                                           0));
        //    OnPlayerInput(new Vector4(point.x, point.y, 0, 0));
        //}
        if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            var point = Camera.main.ScreenToWorldPoint(new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, 0));
            OnPlayerInput(new Vector4(point.x, point.y, 0, 0));             
        }
    }
}

