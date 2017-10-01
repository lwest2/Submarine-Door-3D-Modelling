using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour {

    private float m_distance;

    [SerializeField]
    private AudioClip audioclip;

    [SerializeField]
    private AudioClip audioclip_close;

    private AudioSource audio;
    
    [SerializeField]
    private Transform m_target;

    [SerializeField]
    private Animator anim;

    
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        m_distance = Vector3.Distance(transform.position, m_target.position);

        if (m_distance < 1.5f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.Play("Door");

                if(!audio.isPlaying)
                {
                    StartCoroutine(SoundOut());
                }
            }
        }
    }

    IEnumerator SoundOut()
    {
        yield return new WaitForSeconds(6);
        audio.PlayOneShot(audioclip);
        yield return new WaitForSeconds(14);
        audio.PlayOneShot(audioclip_close);

    }
}
