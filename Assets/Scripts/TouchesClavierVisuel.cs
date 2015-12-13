using UnityEngine;
using System.Collections;

public class TouchesClavierVisuel : MonoBehaviour {

    public Renderer m_RendererGMaterial;
    public Renderer m_RendererHMaterial;
    public Renderer m_RendererJMaterial;
   

    public Color m_LeftColor;
    public Color m_RightColor;
    public Color m_White;


    public GameManager m_GameManager;

	// Update is called once per frame
	void Update ()
    {
        /*
	    if(m_GameManager.m_LeftFinger==14)
        {
            m_RendererGMaterial.material.color = m_LeftColor;
        }
        else if (m_GameManager.m_LeftFinger == 15)
        {
            m_RendererHMaterial.material.color = m_LeftColor;
        }else if (m_GameManager.m_LeftFinger == 16)
        {
            m_RendererJMaterial.material.color = m_LeftColor;
        }
        
        if (m_GameManager.m_RightFinger == 14)
        {
            m_RendererGMaterial.material.color = m_RightColor;
        }
        else if (m_GameManager.m_RightFinger == 15)
        {
            m_RendererHMaterial.material.color = m_RightColor;
        }
        else if (m_GameManager.m_RightFinger == 16)
        {
            m_RendererJMaterial.material.color = m_RightColor;
        }

        */
    }
}
