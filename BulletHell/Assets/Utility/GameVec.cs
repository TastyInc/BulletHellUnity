using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVec : MonoBehaviour
{
    public static Vector2 VL1 { get { return new Vector2(-1, 0); } }
    public static Vector2 VL2 { get { return new Vector2(-2, 0); } }
    public static Vector2 VL3 { get { return new Vector2(-3, 0); } }
    public static Vector2 VL4 { get { return new Vector2(-4, 0); } }

    public static Vector2 VR1 { get { return new Vector2(1, 0); } }
    public static Vector2 VR2 { get { return new Vector2(2, 0); } }
    public static Vector2 VR3 { get { return new Vector2(3, 0); } }
    public static Vector2 VR4 { get { return new Vector2(4, 0); } }

    public static Vector2 VU1 { get { return new Vector2(0, -1); } }
    public static Vector2 VU2 { get { return new Vector2(0, -2); } }
    public static Vector2 VU3 { get { return new Vector2(0, -3); } }
    public static Vector2 VU4 { get { return new Vector2(0, -4); } }

    public static Vector2 VD1 { get { return new Vector2(0,1); } }
    public static Vector2 VD2 { get { return new Vector2(0,2); } }
    public static Vector2 VD3 { get { return new Vector2(0,3); } }
    public static Vector2 VD4 { get { return new Vector2(0,4); } }
}
