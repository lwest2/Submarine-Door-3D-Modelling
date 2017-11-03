using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {


    [SerializeField]
    private Animator m_anim; // animator 

    // Use this for initialization
    void Start()
    {
        m_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
		
        if (Interact.hasFinished == true)
        {
            m_anim.Play("Door_Opening");
            Interact.hasFinished = false;
        }
	}
}
