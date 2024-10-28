using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_lightsaber : MonoBehaviour
{
    public KeyCode activation_key;
    public float rotation_speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(activation_key))
        { 

            //lightsaber_on ? SoundFXManager.instance.PlayClip(lightsaber_on_sound, transform, 1.0f) :  SoundFXManager.instance.PlayClip(lightsaber_off_sound, transform, 1.0f)
            //SoundFXManager.instance.PlayClip(lightsaber_on ? lightsaber_on_sound : lightsaber_off_sound, transform, 1.0f);
            //StopAllCoroutines();
            StartCoroutine(RotateLightSaber());
        }

    }

    private IEnumerator RotateLightSaber()
    {
        float rotation_value = 0.0f;
        Quaternion initial_quaternion = transform.rotation;
        Quaternion final_rotation = initial_quaternion * Quaternion.Euler(0, 0, 180);
        while(rotation_value < 180)
        {
            if(rotation_value + rotation_speed * Time.deltaTime > 180)
            {
                transform.Rotate(0, 0, 180 - rotation_value, Space.Self);
                break;
            }

            rotation_value += rotation_speed * Time.deltaTime;
            transform.Rotate(0, 0, rotation_speed * Time.deltaTime, Space.Self);
            yield return null;
        }

        //transform.rotation = final_rotation;
        
        
        
    }
}
