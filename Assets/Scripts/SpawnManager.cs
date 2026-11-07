using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform waypointParent;
    [SerializeField] private Transform enemyParent;
    [SerializeField] private Enemy enemyPrefab;

    private Transform[] arWaypoints;

    void Awake()
    {
        GetChildWaypoints(waypointParent);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This function gets the waypoint root reference and assigns all its children in an array 
    //for them to be used as individual waypoints for enemies.
    private void GetChildWaypoints(Transform Parent)
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

    //Spawns an enemy 
    private void SpawnEnemy()
    {
        //Confirms there are valid waypoints for the enemy
        if(arWaypoints == null || arWaypoints.Length == 0) return;

        //Confirms there is an enemy prefab to instantiate
        if (enemyPrefab == null)
        {
            Debug.LogError("Spawn Manager: Enemy prefab is not assigned");
            return;
        }

        //Instantiates the enemy
        Enemy newEnemy = Instantiate(enemyPrefab,arWaypoints[0].position, quaternion.identity);

        // Assigns the waypoint to the enemy
        newEnemy.InitializePath(arWaypoints);
    }
}
