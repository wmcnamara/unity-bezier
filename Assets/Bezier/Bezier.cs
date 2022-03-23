﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bezier2D
{
    //Gets a point along a line defined by the two ends p1 and p2, with the interpolant t
    public static Vector2 LineLerp(Vector2 p1, Vector2 p2, float t)
    {
        float x = Mathf.Lerp(p1.x, p2.x, t);
        float y = Mathf.Lerp(p1.y, p2.y, t);

        return new Vector2(x, y);
    }

    //Interpolates between three control points with a quadratic bezier curve, with the interpolant t
    public static Vector2 QuadraticBezierInterp(Transform p1, Transform p2, Transform p3, float t)
    {
        Vector2 a = LineLerp(p1.position, p2.position, t);
        Vector2 b = LineLerp(p2.position, p3.position, t);

        return LineLerp(a, b, t);
    }

    //Interpolates between four control points with a cubic bezier curve, with the interpolant t
    public static Vector2 CubicBezierInterp(Transform p1, Transform p2, Transform p3, Transform p4, float t)
    {      
        Vector2 a = LineLerp(p1.position, p2.position, t);
        Vector2 b = LineLerp(p2.position, p3.position, t);
        Vector2 c = LineLerp(p3.position, p4.position, t);

        Vector2 d = LineLerp(a, b, t);
        Vector2 e = LineLerp(b, c, t);

        return LineLerp(d, e, t);
    }

    //Interpolates between any number of control points in the points list, using a bezier curve and the interpolant, t. 
    public static Vector2 NOrderBezierInterp(List<Transform> points, float t)
    {
        if (points.Count < 2)
            throw new System.Exception("Bezier Curve needs atleast 3 points, or 2 for a linear interpolation");

        //Convert the list of Transform's to a list of Vector2
        List<Vector2> vecp = new List<Vector2>();

        foreach (Transform p in points)
        {
            vecp.Add(p.position);
        }

        return NOrderBezier_R(vecp, t);
    }

    //Underlying recursive function to calculate n order bezier curves
    private static Vector2 NOrderBezier_R(List<Vector2> points, float t)
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

        return NOrderBezier_R(lines, t);
    }
}

public static class Bezier3D
{
    //Gets a point along a line defined by the two ends p1 and p2, with the interpolant t
    public static Vector3 LineLerp3D(Vector3 p1, Vector3 p2, float t)
    {
        float x = Mathf.Lerp(p1.x, p2.x, t);
        float y = Mathf.Lerp(p1.y, p2.y, t);
        float z = Mathf.Lerp(p1.z, p2.z, t);

        return new Vector3(x, y, z);
    }

    //Interpolates between three control points with a quadratic bezier curve, with the interpolant t
    public static Vector3 QuadraticBezierInterp(Transform p1, Transform p2, Transform p3, float t)
    {
        Vector3 a = LineLerp3D(p1.position, p2.position, t);
        Vector3 b = LineLerp3D(p2.position, p3.position, t);

        return LineLerp3D(a, b, t);
    }

    //Interpolates between four control points with a cubic bezier curve, with the interpolant t
    public static Vector2 CubicBezierInterp(Transform p1, Transform p2, Transform p3, Transform p4, float t)
    {
        Vector3 a = LineLerp3D(p1.position, p2.position, t);
        Vector3 b = LineLerp3D(p2.position, p3.position, t);
        Vector3 c = LineLerp3D(p3.position, p4.position, t);

        Vector3 d = LineLerp3D(a, b, t);
        Vector3 e = LineLerp3D(b, c, t);

        return LineLerp3D(d, e, t);
    }

    //Interpolates between any number of control points in the points list, using a bezier curve and the interpolant, t. 
    public static Vector3 NOrderBezierInterp(List<Transform> points, float t)
    {
        if (points.Count < 2)
            throw new System.Exception("Bezier Curve needs atleast 3 points, or 2 for a linear interpolation");

        //Convert the list of Transform's to a list of Vector2
        List<Vector3> vecp = new List<Vector3>();

        foreach (Transform p in points)
        {
            vecp.Add(p.position);
        }

        return NOrderBezier_R(vecp, t);
    }

    //Underlying recursive function to calculate n order bezier curves
    private static Vector3 NOrderBezier_R(List<Vector3> points, float t)
    {
        if (points.Count == 2)
        {
            return LineLerp3D(points[0], points[1], t);
        }

        List<Vector3> lines = new List<Vector3>();

        for (int i = 0; i < points.Count - 1; i++)
        {
            Vector3 line = LineLerp3D(points[i], points[i + 1], t);
            lines.Add(line);
        }

        return NOrderBezier_R(lines, t);
    }
}