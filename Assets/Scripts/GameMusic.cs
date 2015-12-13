using UnityEngine;
using System.Collections;

public partial class GameManager : MonoBehaviour {

    bool m_Rythm = true;

    public RoomManager m_RoomManager;

    public AudioSource m_Audio;

    public float m_TimeMusic = 0;
    float m_TimeDemi = 0;

    float m_Delay = 0.3f;

    int m_LeftFingerGoodPosition = 14;
    int m_RightFingerGoodPosition = 15;

    /*
    void FixedUpdate()
    {
        m_TimeMusic = m_Audio.time;
    }
    */

    private bool m_Alternatif = false;
    public Material m_MaterialCube;
    public Color m_Color1;
    public Color m_Color2;
    public Color m_Color3;

    void LauchMusic()
    {
        m_Delay = 0.5f;
        m_isMusicLaunch = true;
        SoundManagerEvent.emit(SoundManagerType.LAUNCHMUSIC);
        StartCoroutine(Rythm());
        m_TimeMusic = 0;
        m_TimeDemi = 0;
    }

    IEnumerator Rythm()
    {
        while(m_Rythm)
        {
            yield return new WaitForSeconds(0.5f);
            m_TimeMusic += 0.5f;
            m_TimeDemi+=1;
            m_RoomManager.Pulse();

            StartCoroutine(Cube());
            
        }
    }

    IEnumerator Cube()
    {
        
        m_Alternatif = !m_Alternatif;

        if(m_Alternatif)
        {
            m_RightFingerGoodPosition = 15;
        }
        else
        {
            m_RightFingerGoodPosition = 16;
        }

        m_MaterialCube.color = m_Color1;

        m_Delay = 0.5f;
        while(m_Delay>0)
        {
                if (m_LeftFinger== m_LeftFingerGoodPosition && m_RightFinger == m_RightFingerGoodPosition)
                {
                    Debug.Log("Bien");
                    break;
                }
                else
                {
                    m_MaterialCube.color = m_Color3;
                }

            yield return new WaitForSeconds(0.001f);
            m_Delay -= 0.01f;
        }
        
        
      
       
    }


   
}
