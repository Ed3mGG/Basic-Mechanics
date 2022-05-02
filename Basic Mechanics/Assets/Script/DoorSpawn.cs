using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpawn : MonoBehaviour
{
    public GameObject door;
    public Boss bossPos;

    public void TriggerDoorCredit()
    {
        door.SetActive(true);
        door.transform.position = bossPos.transform.position;
    }
}
