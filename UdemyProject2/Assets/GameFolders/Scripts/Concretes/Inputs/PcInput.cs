using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstracts.Inputs;
using UnityEngine;

namespace UdemyProject2.Inputs
{
    public class PcInput : IPlayerInput
    {
        public float xAxis => Input.GetAxisRaw("Horizontal");
        public float yAxis => Input.GetAxisRaw("Vertical");
        public bool IsJumpButtonDown => Input.GetButtonDown("Jump");
    }
}

