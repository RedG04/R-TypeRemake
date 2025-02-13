using System.Collections.Generic;
using UnityEngine;
using System.Collections;



public class Map_Loop : MonoBehaviour

{
    public GameObject[] Road_Segments; // Prefab delle strade
    public float roadLength = 10f; // Lunghezza di ogni segmento
    public float speed = 5f; // Velocità di movimento
    private List<GameObject> activeRoads; // Lista dei segmenti attivi
    private float lastXPosition; // Posizione X dell'ultimo segmento

    void Start()
    {
        activeRoads = new List<GameObject>();
        lastXPosition = 0f;

        // Crea i primi segmenti
        for (int i = 0; i < 5; i++) // Aggiungi più segmenti iniziali
        {
            AddRoadSegment();
        }
    }

    void Update()
    {
        // Muove la mappa
        MoveRoads();

        // Aggiungi nuovi segmenti se necessario
        if (lastXPosition - Camera.main.transform.position.x < 20f)
        {
            AddRoadSegment();
        }
    }

    void MoveRoads()
    {
        foreach (GameObject road in activeRoads)
        {
            road.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        // Rimuove i segmenti fuori dalla visibilità
        if (activeRoads[0].transform.position.x < Camera.main.transform.position.x - roadLength)
        {
            Destroy(activeRoads[0]);
            activeRoads.RemoveAt(0);
        }
    }

    void AddRoadSegment()
    {
        GameObject newSegment = Instantiate(Road_Segments[Random.Range(0, Road_Segments.Length)]);
        newSegment.transform.position = new Vector3(0f, 0f, lastXPosition + roadLength);
        lastXPosition = newSegment.transform.position.x;
        activeRoads.Add(newSegment);
    }
}

