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
        m_myText = GameObject.Find("Text").GetComponent<Text>();
        m_myText.color = Color.clear;

    }

    // Update is called once per frame
    void Update()
    {

        FadeText();
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
        m_distance = Vector3.Distance(transform.position, m_target.position);

        if (m_distance < 1.5f)
        {
            if (m_displayInfo)
            {
                m_myText.text = m_myString;
                m_myText.color = Color.Lerp(m_myText.color, Color.white, m_fadeTime * Time.deltaTime);
            }
        }

        else if (!m_displayInfo)
        {
            m_myText.color = Color.Lerp(m_myText.color, Color.clear, m_fadeTime * Time.deltaTime);       
        }
      
    }
}
