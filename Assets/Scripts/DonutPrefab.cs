using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviorScript : MonoBehaviour
{
    public float Timer = 2;
    public GameObject DonutPrefab;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Vector3 where = new Vector3(Random.Range(-8f, 8f),
                Random.Range(-4f, 4f), 0);
            Instantiate(DonutPrefab, where, Quaternion.identity);
            Timer = 3;
        }

    }
}
