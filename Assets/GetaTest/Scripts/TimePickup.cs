using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePickup : MonoBehaviour
{
    // Start is called before the first frame update
    public TimeManager TimeControl;
    public float TimeRecover = 5;
    private void OnTriggerEnter(Collider other)
    {
        TimeControl.AddTime(TimeRecover);
        gameObject.SetActive(false);
    }
}
