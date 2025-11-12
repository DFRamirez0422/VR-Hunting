using UnityEngine;

public class CubeMover : MonoBehaviour
{
    public float speed = 2f;
    public float moveRange = 3f;
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position = startPos + new Vector3(Mathf.PingPong(Time.time * speed, moveRange) - moveRange / 2, 0, 0);
    }
}
