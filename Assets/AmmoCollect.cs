using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCollect : MonoBehaviour
{
    [SerializeField] int amount = 10;

    public int Collect()
    {
        return amount;
    }
}
