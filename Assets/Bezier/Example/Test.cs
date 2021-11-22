using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private GameObject plotPointPrefab; //The prefab for the point that will represent the curve
    [SerializeField] private List<Transform> controlPoints = new List<Transform>(); //A list of control points. These can be any Transform

    [Header("No. points used to plot the curve")]
    [SerializeField] private int pointCount = 20; //The number of points that should be plotted to graph the curve

    private List<GameObject> graphPoints = new List<GameObject>(); //A list of all the points that are spawned to graph the curve

    private void Update()
    {
        //Destroy previous points and clear the list
        foreach (GameObject g in graphPoints)
        {
            Destroy(g);
        }
        graphPoints.Clear();

        if (pointCount < 2)
        {
            pointCount = 10;
            Debug.LogWarning("Point count cannot be less than 2");
        }

#if BEZIER_BENCHMARK
        var watch = System.Diagnostics.Stopwatch.StartNew();
#endif
        //Loop through values of t to create the graph, spawning points at each step
        for (float i = 0; i < 1; i += 1f / pointCount)
        {
            Vector2 position = Bezier.NOrderBezierInterp(controlPoints, i);

            graphPoints.Add(Instantiate(plotPointPrefab, position, Quaternion.identity));
        }

#if BEZIER_BENCHMARK
        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;
        Debug.Log(elapsedMs);
#endif
    }

    private void Start()
    {
        Debug.Log($"You're calculating a {controlPoints.Count}th order bezier curve.");
        Debug.Log($"Drag the red control point objects to manipulate the bezier curve.");
        Debug.Log($"To add more control points, add a new control point prefab object (Example/UIControlPoint) and add it to the Control Points list on the Testing object. ");
    }
}
