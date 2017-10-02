using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour {

    private float m_distance; // distance from wheel to player

    [SerializeField]
    private AudioClip m_audioclip; // audio clip open

    [SerializeField]
    private AudioClip m_audioclip_close; // audio clip closle

    private AudioSource m_audioS; // audio source
    
    [SerializeField]
    private Transform m_target; // player

    [SerializeField]
    private Animator m_anim; // animator 

    
    // Use this for initialization
    void Start () {
        m_anim = GetComponent<Animator>();
        m_audioS = GetComponent<AudioSource>();
        m_target = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        m_distance = Vector3.Distance(transform.position, m_target.position); // distance frorm wheel to player

        if (m_distance < 1.5f) // if distance is less than 1.5f
        {
            if (Input.GetKeyDown(KeyCode.E)) // if key down E
            {
                // m_anim.enabled = true;
                m_anim.Play("Door"); // play door animation

                
                
                if(!m_audioS.isPlaying) // if audio is not playing
                {
                    StartCoroutine(SoundOut()); // start coroutine
                }
            }

            /*else if (Input.GetKeyUp(KeyCode.E))
            {
                m_anim.enabled = false;
            }
            */
        }
    }

    IEnumerator SoundOut()
    {
        yield return new WaitForSeconds(6);
        m_audioS.PlayOneShot(m_audioclip); // play open sound clip
        yield return new WaitForSeconds(14);
        m_audioS.PlayOneShot(m_audioclip_close); // play close sound clip

    }
}
