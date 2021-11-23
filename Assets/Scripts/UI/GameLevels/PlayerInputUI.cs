using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputUI : MonoBehaviour
{
    [SerializeField] private EventHandler  LEFT;
    [SerializeField] private EventHandler  RIGHT;
    [SerializeField] private EventHandler  JUMP;

    public (bool, Vector3) GetInput()
    {
        bool jumping = false;
        Vector3 movementHorizontal;
        
        bool jump = JUMP.isDown;
        jumping |= jump; //логическое или оставляет левую часть true до конца Update, даже если нажатие закончилось!

        if (RIGHT.isDown) movementHorizontal = new Vector3(-1, 0, 0);
        else if (LEFT.isDown) movementHorizontal = new Vector3(1, 0, 0);
        else movementHorizontal = Vector3.zero;

        return (jumping, movementHorizontal);
    }
}
