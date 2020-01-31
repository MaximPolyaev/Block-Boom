using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class TrajectoryRenderer : MonoBehaviour
{
    public GameObject bulletPrefab;
    private LineRenderer _lineRendererComponent;

    private GameObject bullet;
    private void Start()
    {
        _lineRendererComponent = GetComponent<LineRenderer>();
        
    }

    public void ShowTrajectory(Vector3 origin, Vector2 force)
    {
        // Подготовка
        bullet = Instantiate(bulletPrefab, origin, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        
        Physics.autoSimulation = false;

        
        // Симуляция
        Vector3[] points = new Vector3[100];
        _lineRendererComponent.positionCount = points.Length;
        
        for (int i = 0; i < points.Length; i++)
        {
            
            Physics.Simulate(0.1f);
            points[i] = bullet.transform.position;

        }
        
        _lineRendererComponent.SetPositions(points);
        
        // Зачистка:
        Physics.autoSimulation = true;
        
        Destroy(bullet.gameObject);
    }
}
