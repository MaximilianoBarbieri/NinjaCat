using UnityEngine;

public class RoadMove : MonoBehaviour
{
    private float _speed;

    private void Start()
    {
        UIManager.OnFinishGame += StopRoad;
    }

    void Update()
    {
        transform.Translate(Vector3.back * (_speed * Time.deltaTime));
    }
    
    public void SetSpeed(float newSpeed)
    {
        _speed = newSpeed;
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

