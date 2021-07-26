using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBarSpawner : MonoBehaviour
{
    public static LifeBarSpawner Instance { get; set; }

    public Transform Holder;
    public GameObject LifePrefab;

    [Space]
    public List<Transform> SpawnPosList = new List<Transform>();
    private List<RectTransform> SpawnedLifeBars = new List<RectTransform>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public List<RectTransform> SpawnLifeBars(int amount)
    {
        SpawnedLifeBars.Clear();

        for (int i = 0; i < amount; i++)
        {
            GameObject lifebar = Instantiate(LifePrefab, GetTransformPos());
            SpawnedLifeBars.Add(lifebar.GetComponent<RectTransform>());
        }

        return SpawnedLifeBars;
    }

    private Transform GetTransformPos()
    {
        return SpawnPosList[Random.Range(0, SpawnPosList.Count - 1)];
    }
}