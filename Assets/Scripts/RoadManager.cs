using UnityEngine;
using System.Collections.Generic;
using static Utils;

public class RoadManager : MonoBehaviour
{
    public List<GameObject> roadPrefabs;
    private Queue<GameObject> activeRoads = new();
    public float roadLength = 50f;
    public GameObject lastRoad { get; private set; }

    private int roadIndex;
    private bool useRandomSpawn;
    
    private float elapsedTime;
    private float currentSpeed = SPEED_ROAD_EASY;

    void Start()
    {
        if (roadPrefabs.Count == 0) return;

        GameObject firstRoad = roadPrefabs[roadIndex];
        firstRoad.transform.position = Vector3.zero;
        firstRoad.SetActive(true);
        activeRoads.Enqueue(firstRoad);
        lastRoad = firstRoad;
        roadIndex++;
        
        // Le asigno velocidad al primer Road
        RoadMove roadMove = firstRoad.GetComponent<RoadMove>();
        if (roadMove != null) roadMove.SetSpeed(currentSpeed);
        
        UIManager.OnFinishGame += StopAllRoads;
    }
    
    void Update()
    {
        elapsedTime += Time.deltaTime;
        AdjustSpeed();
    }

    private void AdjustSpeed()
    {
        float newSpeed = currentSpeed;

        if (elapsedTime >= TIME_SPEED_ROAD_PRO)
            newSpeed = SPEED_ROAD_PRO;
        else if (elapsedTime >= TIME_SPEED_ROAD_HARD)
            newSpeed = SPEED_ROAD_HARD;
        else if (elapsedTime >= TIME_SPEED_ROAD_MEDIUM)
            newSpeed = SPEED_ROAD_MEDIUM;

        if (Mathf.Abs(newSpeed - currentSpeed) > 0.01f)
        {
            currentSpeed = newSpeed;
            UpdateRoadSpeeds();
            Debug.Log($"🚀 Nueva velocidad: {currentSpeed}");
        }
    }
    
    private void UpdateRoadSpeeds()
    {
        foreach (GameObject road in activeRoads)
        {
            RoadMove roadMove = road.GetComponent<RoadMove>();
            if (roadMove != null)
            {
                roadMove.SetSpeed(currentSpeed);
            }
        }
    }

    public void ActivateNewRoad()
    {
        GameObject newRoad;

        if (!useRandomSpawn)
        {
            newRoad = roadPrefabs[roadIndex];
            roadIndex++;

            // activar modo aleatorio
            if (roadIndex >= roadPrefabs.Count)
            {
                useRandomSpawn = true;
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

        // nuevo Road delante del ultimo activo
        Vector3 newPosition = lastRoad.transform.position + new Vector3(0, 0, roadLength);
        newRoad.transform.position = newPosition;
        newRoad.SetActive(true);

        RoadMove roadMove = newRoad.GetComponent<RoadMove>();
        if (roadMove != null)
            roadMove.SetSpeed(currentSpeed);
        
        activeRoads.Enqueue(newRoad);
        lastRoad = newRoad;
        
        ItemManager.Instance.OnRequestRoad?.Invoke(newRoad);
    }

    public void DeactivateOldestRoad()
    {
        if (activeRoads.Count <= 1) return;

        GameObject oldRoad = activeRoads.Dequeue();
        oldRoad.SetActive(false);
    }

    private GameObject GetInactiveRoad()
    {
        // solo los Roads inactivos
        List<GameObject> inactiveRoads = roadPrefabs.FindAll(road => !road.activeInHierarchy);

        if (inactiveRoads.Count == 0) return null;

        // road aleatorio
        return inactiveRoads[Random.Range(0, inactiveRoads.Count)];
    }
    
    private void StopAllRoads()
    {
        Debug.Log("Deteniendo todos los Roads porque el personaje ha muerto.");
        currentSpeed = 0;
        UpdateRoadSpeeds();
        enabled = false; 
    }

    private void OnDestroy()
    {
        UIManager.OnFinishGame -= StopAllRoads; 
    }
}