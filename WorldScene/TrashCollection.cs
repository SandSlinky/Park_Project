using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashCollection : MonoBehaviour
{
    public static TrashCollection instance;
    public Text text;
    int trashCollected;
    
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeTrash(int trashValue)
    {
        trashCollected += trashValue;
        text.text = "Trash collected: " + trashCollected.ToString() + "/10";
        Debug.Log($"Trash collected = {trashCollected}");
    }
}
