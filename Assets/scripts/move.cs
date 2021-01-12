using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    private void Update()
    {
        transform.Translate(2 * Time.deltaTime, 0, 0);
    }
}

