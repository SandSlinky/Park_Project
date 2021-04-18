using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    public int trashValue = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        TrashCollection.instance.ChangeTrash(trashValue);      
        Destroy(gameObject);
    }
}
