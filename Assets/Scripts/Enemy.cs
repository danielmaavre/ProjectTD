using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform[] waypoints;
    private int currentWaypoint;
    private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializePath(Transform[] waypoints)
    {
        this.waypoints = waypoints;
        currentWaypoint = 1;
    }
}
