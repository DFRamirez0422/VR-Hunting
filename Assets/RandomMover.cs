using UnityEngine;

public class RandomMover : MonoBehaviour
{
    public float speed = 2f;        // movement speed
    public float range = 3f;        // max distance from start position
    public float waitTime = 1f;     // time to pause at each point

    private Vector3 startPos;
    private Vector3 targetPos;
    private float waitTimer = 0f;

    void Start()
    {
        startPos = transform.position;
        PickNewTarget();
    }

    void Update()
    {
        // Move toward target
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // Check if reached target
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                PickNewTarget();
                waitTimer = 0f;
            }
        }
    }

    void PickNewTarget()
    {
        float x = startPos.x + Random.Range(-range, range);
        float z = startPos.z + Random.Range(-range, range);
        float y = startPos.y; // keep same height
        targetPos = new Vector3(x, y, z);
    }
}
