using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepWaypointFollower : MonoBehaviour
{
    public float speed = 10f;

    public float targetDistance = 0.2f;
    private Transform target;
    private int wavepointIndex = 0;

    private bool isOriginalColor = true;
    private Color originalColor;
    Renderer rend;
    
    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.points[0];
        rend = GetComponent<Renderer>();
        originalColor = rend.material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= targetDistance)
        {
            GetNextWaypoint();
        }

    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        if(wavepointIndex == Waypoints.points.Length - 2)
        {
            InvokeRepeating("Blinkiboy", 0f, 0.1f);
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void Blinkiboy() 
    {
        if (isOriginalColor)
        {
            rend.material.color = Color.Lerp(originalColor, Color.blue, 1f);
            isOriginalColor = false;
        }
        else
        {
            rend.material.color = Color.Lerp(Color.blue, originalColor, 1f);
            isOriginalColor = true;
        }
    }
}
