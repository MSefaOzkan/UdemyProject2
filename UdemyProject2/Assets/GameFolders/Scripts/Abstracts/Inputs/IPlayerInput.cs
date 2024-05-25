using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Abstracts.Inputs
{
    public interface IPlayerInput 
    {
        float xAxis { get; }
        float yAxis { get; }
        bool IsJumpButtonDown { get; }
    }
}