using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public int score;
    public int weight;
    // Start is called before the first frame update
    void Update()
    {
        score = new System.Random().Next(1, 11);
        weight = new System.Random().Next(1, 6);
    }

}
