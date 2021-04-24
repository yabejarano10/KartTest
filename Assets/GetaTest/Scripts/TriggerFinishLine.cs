using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFinishLine : MonoBehaviour
{
    public TimeManager timeStart;
    public RaceManager raceStatus;

    private bool started = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Equals("KartColliders"))
        {
            if (!started)
            {
                timeStart.StartRace();

                started = true;
            }
            else
            {
                raceStatus.FinishRace();
            }

        }
    }
}
