using System.Collections.Generic;
using UnityEngine;

public class ItemGeneration : MonoBehaviour
{
    public List<GameObject> prefabs;
    [SerializeField] private Transform tracker;
    private int currentIndex;

    private void Awake()
    {
        GenerateItem();
    }

    private void GenerateItem()
    {
        GameObject obj = Instantiate(prefabs[currentIndex % prefabs.Count]);
        obj.transform.position = transform.position + transform.forward * currentIndex * 10;
        currentIndex++;
    }
}
