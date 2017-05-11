using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {


    public delegate void ExplosionEvent(float power);

    public static event ExplosionEvent Explosion;

    public static void NotifyExplosion( float power )
    {
        Explosion(power);
    }

}
