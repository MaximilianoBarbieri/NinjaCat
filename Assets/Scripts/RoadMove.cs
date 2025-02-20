using UnityEngine;

public class RoadMove : MonoBehaviour
{
    private float speed = 5f; // Velocidad de movimiento

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}

