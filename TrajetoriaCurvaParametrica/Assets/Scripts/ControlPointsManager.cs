using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ControlPointsManager : MonoBehaviour
{
    [SerializeField] List<Transform> controlPoints = new List<Transform>();
    [SerializeField] LayerMask layerGround;
    [SerializeField] GameObject controlPointPrefab;
    List<GameObject> controlPointObjects = new List<GameObject>();
    List<Vector3> trajectoryPoints = new List<Vector3>();

    [SerializeField] Car car; // Reference to the Car script

    private LineRenderer lineRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerGround))
            {
                Debug.Log("Hit Ground: " + hit.collider.name);
                GameObject newControlPoint = Instantiate(controlPointPrefab, hit.point, Quaternion.identity);
                controlPointObjects.Add(newControlPoint);
                controlPoints.Add(newControlPoint.transform);
            }
        }
    }

    public void ResetControlPonts()
    {
        foreach (GameObject cp in controlPointObjects)
        {
            Destroy(cp);
            controlPoints.Remove(cp.transform);
        }
        controlPointObjects.Clear();
    }

    public void LinearInterpolation()
    {
        trajectoryPoints.Clear();
        if (controlPoints.Count < 2)
        {
            Debug.LogWarning("Not enough control points for linear interpolation.");
            return;
        }

        lineRenderer.positionCount = controlPoints.Count;
        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = 0.5f;

        for (int i = 0; i < controlPoints.Count; i++)
        {
            lineRenderer.SetPosition(i, controlPoints[i].position);
            trajectoryPoints.Add(controlPoints[i].position);
        }
    }


    Vector3 CalculatingBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        Vector3 p = u * u * u * p0 +
         3 * u * u * t * p1 +
         3 * u * t * t * p2 +
         t * t * t * p3;
        return p;
    }

    public void BezierInterpolation()
    {
        trajectoryPoints.Clear();
        if (controlPoints.Count < 4)
        {
            Debug.LogWarning("Not enough control points for Bezier interpolation.");
            return;
        }
        int resolution = 20; // Number of points to generate along the curve
        int segmentCount = (controlPoints.Count - 1) / 3;
        int totalPoints = segmentCount * resolution + 1;
        lineRenderer.positionCount = totalPoints;
        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = 0.5f;
        int outputIndex = 0;
        for (int segment = 0; segment < segmentCount; segment++)
        {
            int index = segment * 3;
            Vector3 p0 = controlPoints[index].position;
            Vector3 p1 = controlPoints[index + 1].position;
            Vector3 p2 = controlPoints[index + 2].position;
            Vector3 p3 = controlPoints[index + 3].position;

            for (int i = 0; i <= resolution; i++)
            {
                if(segment>0 && i== 0)
                    continue; // Skip the first point of each segment except the first one to avoid duplicates
                float t = i / (float)resolution;
                Vector3 pointOnCurve = CalculatingBezierPoint(t, p0, p1, p2, p3);
                lineRenderer.SetPosition(outputIndex, pointOnCurve);
                trajectoryPoints.Add(pointOnCurve);
                outputIndex++;
            }
        }
    }

    public void StartCarMovement()
    {
        car.StartMovement(trajectoryPoints);
    }
}
    