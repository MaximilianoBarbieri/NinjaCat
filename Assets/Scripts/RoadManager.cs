using UnityEngine;
using System.Collections.Generic;
using static Utils;

public class RoadManager : MonoBehaviour
{
    public List<GameObject> roadPrefabs;
    private Queue<GameObject> _activeRoads = new();
    public float roadLength = 50f;
    private GameObject LastRoad { get; set; }

    private int _roadIndex;
    private bool _useRandomSpawn;

    private float _elapsedTime;
    private float _currentSpeed = SPEED_ROAD_EASY;

    void Start()
    {
        if (roadPrefabs.Count == 0) return;

        GameObject firstRoad = roadPrefabs[_roadIndex];
        firstRoad.transform.position = Vector3.zero;
        firstRoad.SetActive(true);
        _activeRoads.Enqueue(firstRoad);
        LastRoad = firstRoad;
        _roadIndex++;

        // Le asigno velocidad al primer Road
        RoadMove roadMove = firstRoad.GetComponent<RoadMove>();
        if (roadMove != null) roadMove.SetSpeed(_currentSpeed);

        UIManager.OnFinishGame += StopAllRoads;
    }

    void Update()
    {
        _elapsedTime += Time.deltaTime;
        AdjustSpeed();
    }

    private void AdjustSpeed()
    {
        float newSpeed = _currentSpeed;

        if (_elapsedTime >= TIME_SPEED_ROAD_PRO)
            newSpeed = SPEED_ROAD_PRO;
        else if (_elapsedTime >= TIME_SPEED_ROAD_HARD)
            newSpeed = SPEED_ROAD_HARD;
        else if (_elapsedTime >= TIME_SPEED_ROAD_MEDIUM)
            newSpeed = SPEED_ROAD_MEDIUM;

        if (Mathf.Abs(newSpeed - _currentSpeed) > 0.01f)
        {
            _currentSpeed = newSpeed;
            UpdateRoadSpeeds();
            Debug.Log($"Nueva velocidad: {_currentSpeed}");
        }
    }

    private void UpdateRoadSpeeds()
    {
        foreach (GameObject road in _activeRoads)
        {
            RoadMove roadMove = road.GetComponent<RoadMove>();
            if (roadMove != null)
            {
                roadMove.SetSpeed(_currentSpeed);
            }
        }
    }

    public void ActivateNewRoad()
    {
        GameObject newRoad;

        if (!_useRandomSpawn)
        {
            newRoad = roadPrefabs[_roadIndex];
            _roadIndex++;

            // activar modo aleatorio
            if (_roadIndex >= roadPrefabs.Count)
            {
                _useRandomSpawn = true;
            }
        }
        else
        {
            newRoad = GetInactiveRoad();
        }

        if (newRoad == null)
        {
            Debug.LogWarning("No hay Roads inactivos disponibles.");
            return;
        }

        Vector3 newPosition = LastRoad.transform.position + new Vector3(0, 0, roadLength);
        newRoad.transform.position = newPosition;
        newRoad.SetActive(true);

        RoadMove roadMove = newRoad.GetComponent<RoadMove>();
        if (roadMove != null)
            roadMove.SetSpeed(_currentSpeed);

        _activeRoads.Enqueue(newRoad);
        LastRoad = newRoad;

        ItemManager.Instance.OnRequestRoad?.Invoke(newRoad);
    }

    public void DeactivateOldestRoad()
    {
        if (_activeRoads.Count <= 1) return;

        GameObject oldRoad = _activeRoads.Dequeue();
        oldRoad.SetActive(false);
    }

    private GameObject GetInactiveRoad()
    {
        List<GameObject> inactiveRoads = roadPrefabs.FindAll(road => !road.activeInHierarchy);

        if (inactiveRoads.Count == 0) return null;

        return inactiveRoads[Random.Range(0, inactiveRoads.Count)];
    }

    private void StopAllRoads()
    {
        Debug.Log("Deteniendo todos los Roads porque el personaje ha muerto.");
        _currentSpeed = 0;
        UpdateRoadSpeeds();
        enabled = false;
    }

    private void OnDestroy()
    {
        UIManager.OnFinishGame -= StopAllRoads;
    }
}