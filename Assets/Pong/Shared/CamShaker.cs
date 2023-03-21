using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShaker : MonoBehaviour
{
    //Allow to knows if the camera is been shake or not
    bool shakingCam;


    public void Shake(float duration, float amount, float intensity){
        if(!shakingCam){
            //Causing a jolt
            StartCoroutine(ShakeCam(duration, amount, intensity));
        }
    }

    IEnumerator ShakeCam(float dur, float amount, float intensity){
        float t = dur;
        //retrieve the original position of the camera
        Vector3 originalPos = Camera.main.transform.localPosition;
        //Position to attempt
        Vector3 targetPos = Vector3.zero;
        
        shakingCam = true;

        while(t > 0.0f){
            if (targetPos == Vector3.zero){
                targetPos = originalPos + (Random.insideUnitSphere * amount);
            }

            //function Lerp() to deplace the camera from the localPos to the arrival position
            Camera.main.transform.localPosition = Vector3.Lerp(Camera.main.transform.localPosition, targetPos, intensity * Time.deltaTime);

            //Vector3.distance() to knows if the camera has attempt the arrival position
            if(Vector3.Distance(Camera.main.transform.localPosition, targetPos) < 0.02f)
            {
                targetPos = Vector3.zero;
            }

            t -= Time.deltaTime;
            yield return null;
        }


        Camera.main.transform.localPosition = originalPos;
        shakingCam= false;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
