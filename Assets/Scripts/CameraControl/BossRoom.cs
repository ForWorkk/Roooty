using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    private List<GameObject> colliderList;
    private List<Transform> spawnPosList;

    [SerializeField] private bool isActive;

    private void Awake()
    {
        colliderList = new List<GameObject>();
        foreach(Transform child in transform.Find("Colliders"))
        {
            colliderList.Add(child.gameObject);
        }

        spawnPosList = new List<Transform>();
        foreach (Transform child in transform.Find("SpawnPoss"))
        {
            spawnPosList.Add(child);
        }

        if (!isActive)
        {
            foreach (GameObject i in colliderList)
            {
                i.SetActive(false);
            }
        }
        else
        {
            Activate();
        }
    }

    public Vector3 GetRandomSpawnPosition()
    {
        return spawnPosList[Random.Range(0, 2)].position;
    }

    public void Activate()
    {
        isActive = true;

        foreach(GameObject i in colliderList)
        {
            i.SetActive(true);
        }

        Transform camPos = Camera.main.transform;
        camPos.position = new Vector3(transform.position.x, transform.position.y, camPos.position.z);
    }
}
