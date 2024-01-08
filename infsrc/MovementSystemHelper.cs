using ABI_RC.Systems.MovementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace ZuluClientCVR
{
    //Hacky hacky!
    //Who's a good hack? You are! You are!
    internal class MovementSystemHelper
    {
        public static void ChangeSpeed5()
        {MovementSystem.Instance.baseMovementSpeed += 5f;}
        public static void ChangeSpeed5Minus()
        { MovementSystem.Instance.baseMovementSpeed -= 5f; }
        public static void ChangeSpeed15()
        { MovementSystem.Instance.baseMovementSpeed += 15f; }
        public static void ChangeSpeed15Minus()
        { MovementSystem.Instance.baseMovementSpeed -= 15f; }
    }
}
