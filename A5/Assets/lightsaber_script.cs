using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightsaber_script : MonoBehaviour
{
    public float extend_speed = 0.4f;

    public KeyCode activation_key = KeyCode.Space;
    bool lightsaber_on;
    float min_scale_value;
    float max_scale_value;
    //float local_x, local_z;
    public float min_lightrange, max_lightrange;

    [SerializeField] private AudioClip lightsaber_on_sound;
    [SerializeField] private AudioClip lightsaber_off_sound;
    // Start is called before the first frame update

    public GameObject gameobject;
    private Light lightsaber_light;

    void Start()
    {
        lightsaber_light = gameobject.GetComponent<Light>();
        max_scale_value = transform.localScale.y;
        min_scale_value = 0.0f;
        min_lightrange = 0.0f;
        max_lightrange = 4.0f;
        lightsaber_light.range = max_lightrange;
        lightsaber_on = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(activation_key))
        {
            lightsaber_on = !lightsaber_on;
            
            //lightsaber_on ? SoundFXManager.instance.PlayClip(lightsaber_on_sound, transform, 1.0f) :  SoundFXManager.instance.PlayClip(lightsaber_off_sound, transform, 1.0f)
            SoundFXManager.instance.PlayClip(lightsaber_on ? lightsaber_on_sound : lightsaber_off_sound, transform, 1.0f);
            StopAllCoroutines();
            StartCoroutine(ScaleLightSaber(lightsaber_on ? max_scale_value : min_scale_value));
        }
        
    }


    private IEnumerator ScaleLightSaber(float targetscale)
    {
        Vector3 curr_scale = transform.localScale;
        bool active = gameobject.activeSelf;

        if ( !Mathf.Approximately(targetscale, 0f) && !active)
        {
            gameobject.SetActive(true);
        }

        while (!Mathf.Approximately(curr_scale.y, targetscale))
        {

            curr_scale.y = Mathf.MoveTowards(curr_scale.y, targetscale, extend_speed * Time.deltaTime);
            lightsaber_light.range = min_lightrange + (curr_scale.y / max_scale_value) * (max_lightrange - min_lightrange);
            transform.localScale = curr_scale;
            yield return null;
        }

        curr_scale.y = targetscale;
        if(Mathf.Approximately(targetscale,0f))
        {
            gameobject.SetActive(false);
        }

        yield return null;
    }
}
