using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FollowerControler : MonoBehaviour
{
    public GameObject follower;
    public float followSpeed = 1.0f;
    public float followRotationSpeed = 1.0f;

    XRRayInteractor rayInteractor;

    public void FollowStart(HoverEnterEventArgs args)
    {
        if(rayInteractor == null)
        {
            //we are casting the base interactor as a ray interactor 
            rayInteractor = args.interactor as XRRayInteractor;

            //check if casting failed
            if(rayInteractor != null)
            {
                //start following
                StartCoroutine("Follow");
            }
        }
    }

    public void FollowStop()
    {
        //stop following
        StopAllCoroutines();
        rayInteractor = null;
    }

    IEnumerator Follow()
    {
        //infinite loop
        while(true)
        {
            //TryGetCurrent3DRaycastHit returns a bool
            if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
            {
                follower.transform.position = Vector3.MoveTowards(follower.transform.position, hit.point, followSpeed * Time.deltaTime);
                Vector3 targetDir = hit.point - follower.transform.position;
                Vector3 rotationAmount = Vector3.RotateTowards(follower.transform.forward, targetDir, followRotationSpeed * Time.deltaTime, 0.0f);

                //might need this for project 2 pillars
                follower.transform.rotation = Quaternion.LookRotation(rotationAmount);
            }

            //you have to yield inside the infinite
            //if you don't, Unity will freeze
            yield return null;
        }
    }
   
}
