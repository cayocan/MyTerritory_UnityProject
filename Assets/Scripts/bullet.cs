using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour
{
    public float lifeTime;

    private void Update()
    {
        DestroyByTime();
    }

    void DestroyByTime()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
