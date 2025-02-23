using UnityEngine;
using System.Collections.Generic;

public class RoadManager : MonoBehaviour
{
    public List<GameObject> roadPrefabs; // Lista de Roads disponibles (inicialmente desactivados)
    private Queue<GameObject> activeRoads = new(); // Roads activos en escena
    public float roadLength = 50f; // Longitud de cada Road en el eje Z
    private GameObject lastRoad; // Último Road activado en la escena

    private int roadIndex = 0; // Índice para el spawn secuencial
    private bool useRandomSpawn = false; // Controla cuándo empezar el spawn aleatorio

    void Start()
    {
        if (roadPrefabs.Count == 0)
        {
            Debug.LogError("No hay prefabs de Road en la lista del RoadManager.");
            return;
        }

        // Activa solo un Road al inicio
        GameObject firstRoad = roadPrefabs[roadIndex];
        firstRoad.transform.position = Vector3.zero;
        firstRoad.SetActive(true);
        activeRoads.Enqueue(firstRoad);
        lastRoad = firstRoad;

        roadIndex++; // Avanzar al siguiente en la lista

        Debug.Log("Se activó el primer Road en orden: " + firstRoad.name);
    }

    public void ActivateNewRoad()
    {
        GameObject newRoad;

        if (!useRandomSpawn)
        {
            // Modo secuencial: Elegir el siguiente Road en la lista
            newRoad = roadPrefabs[roadIndex];
            roadIndex++;

            // Si hemos usado todos los Roads en orden, activar modo aleatorio
            if (roadIndex >= roadPrefabs.Count)
            {
                useRandomSpawn = true;
                Debug.Log("Modo aleatorio activado.");
            }
        }
        else
        {
            // Modo aleatorio: Elegir un Road inactivo al azar
            newRoad = GetInactiveRoad();
        }

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
        // Filtrar solo los Roads que están inactivos
        List<GameObject> inactiveRoads = roadPrefabs.FindAll(road => !road.activeInHierarchy);

        if (inactiveRoads.Count == 0)
            return null; // Si todos están activos, no devuelve ninguno

        // Seleccionar un Road aleatorio de la lista de inactivos
        return inactiveRoads[Random.Range(0, inactiveRoads.Count)];
    }
}