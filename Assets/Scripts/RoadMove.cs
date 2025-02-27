using UnityEngine;

public class RoadMove : MonoBehaviour
{
    private float speed;

    private void Start()
    {
        UIManager.OnFinishGame += StopRoad;
    }

    void Update()
    {
        transform.Translate(Vector3.back * (speed * Time.deltaTime));
    }
    
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
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

