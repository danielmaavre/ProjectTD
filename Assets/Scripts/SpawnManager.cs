using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform waypointParent;
    [SerializeField] private Transform enemyParent;
    [SerializeField] private Enemy enemy;

    private Transform[] arWaypoints;

    void Awake()
    {
        GetChildWaypoints(waypointParent);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This function gets the waypoint root reference and assigns all its children in an array 
    //for them to be used as individual waypoints for enemies.
    void GetChildWaypoints(Transform Parent)
    {
        int childrenAmount;

        //Checks if the parent waypoint object is assigned
        if (Parent == null)
        {
            Debug.LogError("Spawn Manager: WaypointParent is not assigned in Inspector.");
            return;
        }

        //Gets the total amount of waypoint children
        childrenAmount = Parent.childCount;

        //If there are children, stores each of them in an array
        if (childrenAmount > 0)
        {
            arWaypoints = new Transform[childrenAmount];

            for (int i = 0; i < childrenAmount; i++)
            {
                arWaypoints[i] = Parent.GetChild(i);
                // Debug.Log(arWaypoints[i]);
            }            
        }else
        {
            Debug.LogError("Spawn Manager: Path root has no waypoints.");
        }

    }
}
