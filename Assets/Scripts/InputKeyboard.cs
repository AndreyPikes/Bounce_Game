using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bounce.Inputs
{    
    public class InputKeyboard
    {        
        public (bool, Vector3) GetInput()
        {
            bool jumping = false;
            Vector3 movementHorizontal;

            float vertical = Input.GetAxis("Vertical");
            bool jump = Input.GetButtonDown("Jump");
            jumping |= (jump || vertical > 0); //логическое или оставляет левую часть true до конца Update, даже если нажатие закончилось!

            float horizontalInput = Input.GetAxis("Horizontal");
            movementHorizontal = new Vector3(-horizontalInput, 0, 0).normalized; //единичные            

            return (jumping, movementHorizontal);
        }
    }
}


