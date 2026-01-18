using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public Transform[] patrolPoints;
    public Transform player;
    public float speed = 2f;
    public float stopDistance = 2f;

    int index;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (ShouldStopPatrol())
        {
            StopPatrol();
            return;
        }

        Patrol();
    }

    bool ShouldStopPatrol()
    {
        return Vector3.Distance(rb.position, player.position) < stopDistance;
    }

    void Patrol()
    {
        Vector3 target = patrolPoints[index].position;
        target.y = rb.position.y;
        target.z = rb.position.z;

        Vector3 newPos = Vector3.MoveTowards(
            rb.position,
            target,
            speed * Time.fixedDeltaTime
        );

        rb.MovePosition(newPos);

        if (Vector3.Distance(rb.position, target) < 0.05f)
            index = (index + 1) % patrolPoints.Length;
    }

    void StopPatrol()
    {
        rb.linearVelocity = Vector3.zero;
    }
}
