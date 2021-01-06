using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotater : MonoBehaviour
{
    private Transform target;
    private CreepWaypointFollower targetComp;

    [Header("Turret Stats:")]
    public float range = 15f;
    public float rotationSpeedFactor = 10f;
    public string enemyTag = "enemy";
    public int baseDamage = 5;
    public float attackSpeed = 2f;

    private float fireCountdown;

    // Start is called before the first frame update
    void Start()
    {
        fireCountdown = 1f / attackSpeed;
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.3f);
    }

    // Update is called once per frame
    void UpdateTarget()
    {
        if (target != null && Vector3.Distance(transform.position, target.transform.position) <= range)
        {
            return;
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetComp = nearestEnemy.GetComponent<CreepWaypointFollower>();
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if(target == null)
        {
            return;
        }
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeedFactor).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / attackSpeed;
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        targetComp.Damage(baseDamage);
    }
}
