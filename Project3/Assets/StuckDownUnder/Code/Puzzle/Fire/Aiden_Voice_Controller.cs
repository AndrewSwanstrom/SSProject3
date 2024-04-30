using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiden_Voice_Controller : MonoBehaviour
{
    public GameObject Aiden;
    SimpleChase simpleChase;
    public AudioClip aidenSpeech;
    public GameObject player;
    AudioSource audioSource;
    public GameObject cockBlocker;
    // Start is called before the first frame update
    void Start()
    {
        simpleChase = Aiden.GetComponent<SimpleChase>();
        audioSource = player.GetComponent<AudioSource>();
        if(!PlayerController.firstTimeFire)
        {
            audioSource.clip = aidenSpeech;
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
