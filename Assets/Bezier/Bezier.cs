using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier
{
    //Gets a point along a line defined by the two ends p1 and p2, with the interpolant t
    public static Vector2 LineLerp(Vector2 p1, Vector2 p2, float t)
    {
        float x = Mathf.Lerp(p1.x, p2.x, t);
        float y = Mathf.Lerp(p1.y, p2.y, t);

        return new Vector2(x, y);
    }

    //Interpolates between three control points with a quadratic bezier curve, with the interpolant t
    public static Vector2 QuadraticBezierInterp(Vector2 p1, Vector2 p2, Vector2 p3, float t)
    {
        Vector2 a = LineLerp(p1, p2, t);
        Vector2 b = LineLerp(p2, p3, t);

        return LineLerp(a, b, t);
    }

    //Interpolates between four control points with a cubic bezier curve, with the interpolant t
    public static Vector2 CubicBezierInterp(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, float t)
    {      
        Vector2 a = LineLerp(p1, p2, t);
        Vector2 b = LineLerp(p2, p3, t);
        Vector2 c = LineLerp(p3, p4, t);

        Vector2 d = LineLerp(a, b, t);
        Vector2 e = LineLerp(b, c, t);

        return LineLerp(d, e, t);
    }

    //Interpolates between any number of control points in the points list, using a bezier curve and the interpolant, t. 
    public static Vector2 NOrderBezier(List<Transform> points, float t)
    {
        if (points.Count < 2)
            throw new System.Exception("Bezier Curve needs atleast 3 points, or 2 for a linear interpolation");

        //Convert the list of Transform's to a list of Vector2
        List<Vector2> vecp = new List<Vector2>();

        foreach (Transform p in points)
        {
            vecp.Add(p.position);
        }

        return BezierOrderN_R(vecp, t);
    }

    //Underlying recursive function to calculate n order bezier curves
    private static Vector2 BezierOrderN_R(List<Vector2> points, float t)
    {
        if (points.Count == 2)
        {
            return LineLerp(points[0], points[1], t);
        }

        List<Vector2> lines = new List<Vector2>();

        for (int i = 0; i < points.Count - 1; i++)
        {
            Vector2 line = LineLerp(points[i], points[i + 1], t);
            lines.Add(line);
        }

        return BezierOrderN_R(lines, t);
    }
}
