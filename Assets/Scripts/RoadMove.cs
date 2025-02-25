using UnityEngine;

public class RoadMove : MonoBehaviour
{
    private float speed = 5f; // Velocidad de movimiento

    private void Start()
    {
        UIManager.OnFinishGame += StopRoad;
    }

    void Update()
    {
        transform.Translate(Vector3.back * (speed * Time.deltaTime));
    }
    
    
    private void StopRoad()
    {
        enabled = false;
    }

    private void OnDisable()
    {
        UIManager.OnFinishGame -= StopRoad;
        
    }
}

