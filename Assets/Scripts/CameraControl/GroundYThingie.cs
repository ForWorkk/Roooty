using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundYThingie : MonoBehaviour
{
    private void Awake()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z + 0.001f * transform.position.y);
    }

}
