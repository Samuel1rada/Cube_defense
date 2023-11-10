using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Point
{
    public int X { get; set; }
    public int Z { get; set; }

    public Point(int x, int z)
    {
        this.X = x;
        this.Z = z;
    }

    public static bool operator == (Point first, Point second)
    {
        return first.X == second.X && first.Z == second.Z;
    }

    public static bool operator !=(Point first, Point second)
    {
        return first.X != second.X || first.Z != second.Z;
    }
}
