using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bomberman.Utils
{
    public static class Vector2Extensions
    {
        public static Vector2 Round(this Vector2 vector2)
        {
            vector2.x = Mathf.Round(vector2.x);
            vector2.y = Mathf.Round(vector2.y);

            return vector2;
        }
    }
}

