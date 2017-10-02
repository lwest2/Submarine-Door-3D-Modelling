using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayUI : MonoBehaviour
{

    [SerializeField]
    private string m_myString;

    [SerializeField]
    private Text m_myText;

    [SerializeField]
    private float m_fadeTime;

    [SerializeField]
    private bool m_displayInfo;

    private float m_distance;

    [SerializeField]
    private Transform m_target;

    // Use this for initialization
    void Start()
    {
        m_myText = GameObject.Find("Text").GetComponent<Text>(); // get object text
        m_myText.color = Color.clear; // set colour to clear so text does not show

    }

    // Update is called once per frame
    void Update()
    {

        FadeText(); // fade text
    }

    private void OnMouseOver()
    {
        m_displayInfo = true; 
    }

    private void OnMouseExit()
    {
        m_displayInfo = false;
    }

    void FadeText()
    {
        m_distance = Vector3.Distance(transform.position, m_target.position); // calculate distance betweeen wheel and player

        if (m_distance < 1.5f) // if distance is smaller than 1.5f
        {
            if (m_displayInfo) // if display info is true
            {
                m_myText.text = m_myString; // set text to string
                m_myText.color = Color.Lerp(m_myText.color, Color.white, m_fadeTime * Time.deltaTime); // show text
            }
        }

        else if (!m_displayInfo) // if display info is false
        {
            m_myText.color = Color.Lerp(m_myText.color, Color.clear, m_fadeTime * Time.deltaTime); // make invinsible    
        }
      
    }
}
