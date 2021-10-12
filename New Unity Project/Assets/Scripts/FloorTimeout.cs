using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTimeout : MonoBehaviour
{
    public float timeoutDuration = 5.0f;
    //public bool starttimer = false;
    public Transform spawn;

    Coroutine timeout;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            //start a timer for floor collision to reset position of cube
            StartCoroutine(Timeout());
        }
    }

    IEnumerator Timeout()
    {

        //Yield means that it gives control back to unity
        //Every yield spans a frame
        //Yield inside a while loop can make a co-routine that is happening every frame

        yield return new WaitForSeconds(timeoutDuration);

        //change position of object to its spawn (initial) position
        transform.position = spawn.position;
    }

    public void ClearTimeout()
    {
       if(timeout != null) StopCoroutine(timeout);
    }
   
}
