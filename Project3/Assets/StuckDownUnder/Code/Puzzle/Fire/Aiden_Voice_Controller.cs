using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiden_Voice_Controller : MonoBehaviour
{
    public GameObject Aiden;
    SimpleChase simpleChase;
    public AudioClip aidenSpeech;
    public AudioClip AnklesGone;
    public AudioClip KindaSlow;
    public AudioClip Annoying;
    public GameObject player;
    AudioSource audioSource;
    public GameObject cockBlocker;
    public int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        cockBlocker.SetActive(true);
        simpleChase = Aiden.GetComponent<SimpleChase>();
        audioSource = player.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerController.firstTimeFire && PlayerController.rotationMax[3] == 3)
        {
            audioSource.clip = aidenSpeech;
            audioSource.Play();
            PlayerController.firstTimeFire = true;
            simpleChase.enabled = false;
        }
        if(!audioSource.isPlaying && PlayerController.firstTimeFire && !PlayerController.fireWin)
        {
            simpleChase.enabled = true;
            cockBlocker.SetActive(false);
            var joinClips = new AudioClip[] {AnklesGone, KindaSlow, Annoying};
            audioSource.clip = joinClips[index];
            // Play current sound
            // I would rather use PlayOneShot in order to allow multiple concurrent sounds
            audioSource.Play();
            // Increase the index, wrap around if reached end of array
            index = (index + 1) % joinClips.Length;
            if(index==2)
            {
                index = 0;
            }
        }
    }
}
