using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    BoxCollider2D box;
    float MinX, MaxX;
    public int MaxCount, MinCount;
    public float MaxTimer, MinTimer;
    public float MinG, MaxG;

    public GameObject ENEMY;
    public GameObject Danger;

    private void Start()
    {
        box = this.GetComponent<BoxCollider2D>();
    }
    private void OnEnable()
    {
        box = this.GetComponent<BoxCollider2D>();
        MinX = box.size.x / 2 * -1;
        MaxX = box.size.x / 2;
        StartCoroutine(SpawnStart());
    }
    IEnumerator SpawnStart()
    {
        int Count = Random.Range(MinCount, MaxCount);
        for(int i=0;i< Count; i++)
        {
            float X = Random.Range(MinX, MaxX);
            float G = Random.Range(MinG,MaxG);
            Instantiate(Danger, new Vector3(X, 0, 0), Quaternion.identity, null);
            GameObject E = Instantiate(ENEMY, new Vector3(X, 3.37f, 0), Quaternion.identity, null);
            E.GetComponent<Rigidbody2D>().gravityScale = G;
        }
        float Timer = Random.Range(MinTimer, MaxTimer);
        yield return new WaitForSeconds(Timer);
        StartCoroutine(SpawnStart());
    }
}
