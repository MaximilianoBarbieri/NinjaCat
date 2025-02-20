using UnityEngine;
using System.Collections.Generic;

public class RoadManager : MonoBehaviour
{
    public List<GameObject> roadPrefabs; // Lista de Roads disponibles (inicialmente desactivados)
    private Queue<GameObject> activeRoads = new(); // Roads activos en escena
    public float roadLength = 50f; // Longitud de cada Road en el eje Z
    private GameObject lastRoad; // Último Road activado en la escena

    void Start()
    {
        if (roadPrefabs.Count == 0)
        {
            Debug.LogError("No hay prefabs de Road en la lista del RoadManager.");
            return;
        }


        // Activa solo un Road al inicio
        GameObject firstRoad = roadPrefabs[Random.Range(0, roadPrefabs.Count)];
        firstRoad.transform.position = Vector3.zero;
        firstRoad.SetActive(true);
        activeRoads.Enqueue(firstRoad);
        lastRoad = firstRoad;

        Debug.Log("Se activó el primer Road: " + firstRoad.name);
    }

    public void ActivateNewRoad()
    {
        // Selecciona un Road aleatorio que no esté activo
        GameObject newRoad = GetInactiveRoad();
        if (newRoad == null)
        {
            Debug.LogWarning("No hay Roads inactivos disponibles.");
            return;
        }

        // Posiciona el nuevo Road delante del último activo
        Vector3 newPosition = lastRoad.transform.position + new Vector3(0, 0, roadLength);
        newRoad.transform.position = newPosition;
        newRoad.SetActive(true);

        // Agrega a la cola de activos
        activeRoads.Enqueue(newRoad);
        lastRoad = newRoad;
        
        Debug.Log("Se activó un nuevo Road: " + newRoad.name + " en posición " + newPosition);
    }

    public void DeactivateOldestRoad()
    {
        if (activeRoads.Count <= 1) return; // Siempre debe haber al menos un Road activo

        GameObject oldRoad = activeRoads.Dequeue();
        oldRoad.SetActive(false);
        
        Debug.Log("Se desactivó el Road: " + oldRoad.name);
    }

    private GameObject GetInactiveRoad()
    {
        // Busca un Road inactivo en la lista
        foreach (GameObject road in roadPrefabs)
        {
            if (!road.activeInHierarchy)
                return road;
        }

        return null; // Si todos están activos, no devuelve ninguno
    }
}