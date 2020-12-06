using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {
    [SerializeField] int damegeValue = 100;
    public int GetDamage()
    {
        return damegeValue;
    }
    public void Hit()
    {
        Destroy(gameObject);
    }
}
