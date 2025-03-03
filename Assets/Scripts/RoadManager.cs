using UnityEngine;
using System.Collections.Generic;

public class RoadManager : MonoBehaviour
{
    public List<GameObject> roadPrefabs;
    private Queue<GameObject> activeRoads = new();
    public float roadLength = 50f;
    public GameObject lastRoad { get; private set; }

    private int roadIndex;
    private bool useRandomSpawn;

    void Start()
    {
        if (roadPrefabs.Count == 0) return;

        GameObject firstRoad = roadPrefabs[roadIndex];
        firstRoad.transform.position = Vector3.zero;
        firstRoad.SetActive(true);
        activeRoads.Enqueue(firstRoad);
        lastRoad = firstRoad;

        roadIndex++;
        
        UIManager.OnFinishGame += StopAllRoads;
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
        enabled = false; 
    }

    private void OnDestroy()
    {
        UIManager.OnFinishGame -= StopAllRoads; 
    }
}