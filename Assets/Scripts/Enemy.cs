using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform[] waypoints;
    private int targetPosition;
    [SerializeField] float speed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPosition <= waypoints.Length-1)
        {
            MovementControl();            
        }
        
        if(targetPosition == waypoints.Length-1)
        {
            Destroy(gameObject);
        }
             
    }

    public void InitializePath(Transform[] waypoints)
    {
        this.waypoints = waypoints;
        targetPosition = 1;
    }

    private void MovementControl()
    {
        float maxDistance = speed * Time.deltaTime;

        //Checks if the enemy reached the target position
        if(this.transform.position == waypoints[targetPosition].position && targetPosition < waypoints.Length-1)
        {
            targetPosition++;
            Debug.Log($"Target position: {targetPosition}");
        }

        this.transform.position = Vector3.MoveTowards(this.transform.position, waypoints[targetPosition].position, maxDistance);                  
    }

    public int GetTargetPosition()
    {
        return targetPosition;
    }
}
