using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class Car : MonoBehaviour
{
    private List<Vector3> trajectoryPoints = new List<Vector3>();
    private int currentPointIndex = 0;
    private float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCar();
    }

    public void StartMovement(List<Vector3> newTrajectoryPoints)
    {
        trajectoryPoints = newTrajectoryPoints;

        if(trajectoryPoints.Count == 0)
        {
            return;
        }

        currentPointIndex = 0;
        transform.position = trajectoryPoints[currentPointIndex];
    }

    void MoveCar()
    {
        if(trajectoryPoints.Count == 0)
        {
            return;
        }

        if(currentPointIndex >= trajectoryPoints.Count)
        {
            return;
        }

        Vector3 target = trajectoryPoints[currentPointIndex];
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

        if(Vector3.Distance(transform.position, target) < 0.1f)
        {
            currentPointIndex++;
        }
    }
}
