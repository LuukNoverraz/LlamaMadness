using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitTimer : MonoBehaviour
{
    [SerializeField] private float TimeAmount = 5;
    void Update()
    {
        // Subtract seconds from time amount until time amount has passed and destroy object
        TimeAmount -= Time.deltaTime;

        if (TimeAmount < 0)
        {
            Destroy(gameObject);
        }
    }
}
