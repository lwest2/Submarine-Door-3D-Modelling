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

    [SerializeField]
    private AudioSource m_audioS; // audio source

    [SerializeField]
    private AudioSource m_audioSclose; // audio source close

    [SerializeField]
    private Transform m_target; // player

    [SerializeField]
    private Animator m_anim; // animator 

    public static bool hasFinished = false; //handleturn finished


    // Use this for initialization
    void Start () {
        m_anim = GetComponent<Animator>();
        m_target = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        m_distance = Vector3.Distance(transform.position, m_target.position); // distance frorm wheel to player

        if (m_distance < 1.5f) // if distance is less than 1.5f
        {
            if (Input.GetKeyDown(KeyCode.E)) // if key down E
            {
                //m_anim.enabled = true;
                m_anim.Play("Door");
                StartCoroutine("PlaySound");
            }

            /*
            else if (Input.GetKeyUp(KeyCode.E))
            {
                m_anim.enabled = false;
            }
            */
            
       
           
        }
        
        
    }

    IEnumerator PlaySound()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        if(!m_audioS.isPlaying)
            m_audioS.Play();
        yield return new WaitForSecondsRealtime(10.5f);
        if (!m_audioSclose.isPlaying)
            m_audioSclose.Play();
    }


}
