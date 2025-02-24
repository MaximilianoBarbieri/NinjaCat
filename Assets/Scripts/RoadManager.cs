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
                Debug.Log("Modo aleatorio activado.");
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

        Debug.Log("Se activó un nuevo Road: " + newRoad.name + " en posición " + newPosition);

        ItemManager.Instance.OnRequestRoad?.Invoke(newRoad);
    }

    public void DeactivateOldestRoad()
    {
        if (activeRoads.Count <= 1) return;

        GameObject oldRoad = activeRoads.Dequeue();
        oldRoad.SetActive(false);

        Debug.Log("Se desactivó el Road: " + oldRoad.name);
    }

    private GameObject GetInactiveRoad()
    {
        // solo los Roads inactivos
        List<GameObject> inactiveRoads = roadPrefabs.FindAll(road => !road.activeInHierarchy);

        if (inactiveRoads.Count == 0) return null;

        // road aleatorio
        return inactiveRoads[Random.Range(0, inactiveRoads.Count)];
    }
}