using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private float minHeight;
    [SerializeField] private float maxHeight;

    [SerializeField] private List<GameObject> pipes;
    [SerializeField] public bool isGameOver = false;

    private void Start()
    {
        StartCoroutine(SpawnPipe());
    }
    IEnumerator SpawnPipe()
    {
        if (!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            GameObject pipe = ObjectPooler.Instance.SpawnFromPool("Pipe", transform.position, Quaternion.identity);
            pipe.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
            pipes.Add(pipe);

            yield return new WaitForSeconds(spawnRate);
            StartCoroutine(SpawnPipe());
        }
        else
        {
            StopAllPipes();
            StopCoroutine(SpawnPipe());
        }

    }
    private void StopAllPipes()
    {
        foreach (GameObject pipe in pipes)
        {
            pipe.GetComponent<Pipe>().isCanMove = false;
        }
    }
}
