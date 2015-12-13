using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public enum Pas
{
    LeftLeft,
    LeftUp,
    LeftRight,
    LeftDown,
    LeftIdle,

    RightLeft,
    RightUp,
    RightRight,
    RightDown,
    RightIdle
}

public enum MouvementName
{
    TapLeft,
    TapRight,
    StepLeft,
    StepRight,
    TapFront,
    Idle,
    End
}

public struct Enchainement
{
    public MouvementName m_Mouvement;
    public int m_Repetition;
}

public struct Choree
{
    public List<Enchainement> m_Choree; 
}

public partial class GameManager : MonoBehaviour {

    ///////////////
    Choree m_Choree1;


    //////////////

    bool m_Rythm = true;

    public RoomManager m_RoomManager;

    public AudioSource m_Audio;

    public float m_TimeMusic = 0;
    public int m_TimeDemi = 0;

    float m_Delay = 0.3f;

    public int m_LeftFingerGoodPosition = 14;
    public int m_RightFingerGoodPosition = 15;

    int m_Score = 0;

    float m_Battement=0.5f;

    private bool m_Alternatif = false;
    public Material m_MaterialCube;
    public Color m_Color1;
    public Color m_Color2;
    public Color m_Color3;

    private bool m_MusicLaunch = false;

    public TempoCanon m_TempoCanon;

    public Animator m_AnimatorMain;

    public Text m_ScoreText;

    /// <summary>
    
    int m_ChoreeCompteur = -1;
    int m_EnchainementCompteur=0;
    int m_PasCompteur = 0;
    MouvementName m_CurrentMouvement;

    int m_RealPasCompteur=1;
    int m_AnimationPasCompteur = 1;
    /// </summary>

    void LaunchMusic()
    {
        m_Delay = 0.5f;

        
        StartCoroutine(Rythm());
        m_TimeMusic = 0;
        m_TimeDemi = 0;
    }



    IEnumerator Rythm()
    {
        while(m_Rythm)
        {
            yield return new WaitForSeconds(m_Battement);
            m_TimeMusic += m_Battement;
            m_TimeDemi+=1;

            

            if(m_TimeDemi>=6)
            {
                if(m_MusicLaunch==false)
                {
                    m_MusicLaunch = true;
                    SoundManagerEvent.emit(SoundManagerType.LAUNCHMUSIC);
                }   
                m_RoomManager.Pulse();
                ChangeLePas();
            }
            else
            {
                m_TempoCanon.Send();

            }

        }
    }


    void ChangeLePas()
    {
        //Si c'est un nouveau pas
        if (m_PasCompteur == 0)
        {

            //Si c'est un nouveau move
            if (m_EnchainementCompteur == 0)
            {
                //C'est une nouvelle étape de la chorée
                m_ChoreeCompteur++;
                //Si c'est la fin
                if (m_Choree1.m_Choree[m_ChoreeCompteur].m_Mouvement == MouvementName.End)
                {

                }
                else //Sinon
                {
                    //On prend le nouveau move
                    m_CurrentMouvement = m_Choree1.m_Choree[m_ChoreeCompteur].m_Mouvement;
                    //Et on initialize le compteur pour qu'il compte le nombre de fois que l'on doit le faire
                    m_EnchainementCompteur = m_Choree1.m_Choree[m_ChoreeCompteur].m_Repetition;
                }
            }
            else
            {
                //Si ce n'est pas un nouveau move on le decremente afin de faire le nouveau pas du move actuel
                m_EnchainementCompteur--;
            }

            m_PasCompteur = 1;
            m_TempoCanon.Send(m_Choree1.m_Choree[m_ChoreeCompteur].m_Mouvement,true);
        }
        else
        {
            m_PasCompteur--;
            m_TempoCanon.Send(m_Choree1.m_Choree[m_ChoreeCompteur].m_Mouvement);
        }

    }

    public void BlockAnimationContact(MouvementName _move)
    {
        if (m_AnimationPasCompteur == 1)
        {
            switch (_move)
            {

                case MouvementName.TapLeft:
                        m_AnimatorMain.SetTrigger("TapLeft");
                    break;

                case MouvementName.TapRight:
                        m_AnimatorMain.SetTrigger("TapRight");
                    break;

                case MouvementName.StepLeft:
                    m_AnimatorMain.SetTrigger("StepLeft");
                    break;

                case MouvementName.StepRight:
                    m_AnimatorMain.SetTrigger("StepRight");
                    break;

                case MouvementName.TapFront:
                    m_AnimatorMain.SetTrigger("TapFront");
                    break;
            }


            m_AnimationPasCompteur = 0;

        }
        else
        {
            m_AnimationPasCompteur = 1;
        }
    }


    public void BlockContact(MouvementName _move)
    {

        switch (_move)
        {
            case MouvementName.Idle:
                if (m_RealPasCompteur == 1)
                {
                    m_LeftFingerGoodPosition = m_LeftFingerLast;
                    m_RightFingerGoodPosition = m_RightFingerLast;
                }
                else
                {
                    m_LeftFingerGoodPosition = m_LeftFingerLast;
                    m_RightFingerGoodPosition = m_RightFingerLast;
                }
                break;

            case MouvementName.TapLeft:

                if (m_RealPasCompteur == 1)
                {
                    m_LeftFingerGoodPosition = m_LeftFingerLast - 1;
                    m_RightFingerGoodPosition = m_RightFingerLast;

                }
                else
                {
                    m_LeftFingerGoodPosition = m_LeftFingerLast + 1;
                    m_RightFingerGoodPosition = m_RightFingerLast;
                }

               
                break;

            case MouvementName.TapRight:

                if (m_RealPasCompteur == 1)
                {
                    m_RightFingerGoodPosition = m_RightFingerLast + 1;
                    m_LeftFingerGoodPosition = m_LeftFingerLast;

                }
                else
                {
                    m_RightFingerGoodPosition = m_RightFingerLast - 1;
                    m_LeftFingerGoodPosition = m_LeftFingerLast;
                }
                break;

            case MouvementName.TapFront:

                if (m_RealPasCompteur == 1)
                {
                    m_LeftFingerGoodPosition = m_LeftFingerLast - 10;
                    m_RightFingerGoodPosition = m_RightFingerLast;

                }
                else
                {
                    m_LeftFingerGoodPosition = m_LeftFingerLast + 10;
                    m_RightFingerGoodPosition = m_RightFingerLast;
                }
                break;

            case MouvementName.StepLeft:

                if (m_RealPasCompteur == 1)
                {
                    m_LeftFingerGoodPosition = m_LeftFingerLast - 1;
                    m_RightFingerGoodPosition = m_RightFingerLast;

                }
                else
                {
                    m_RightFingerGoodPosition = m_RightFingerLast - 1;
                    m_LeftFingerGoodPosition = m_LeftFingerLast;
                }
                break;

            case MouvementName.StepRight:

                if (m_RealPasCompteur == 1)
                {
                    m_LeftFingerGoodPosition = m_LeftFingerLast + 1;
                    m_RightFingerGoodPosition = m_RightFingerLast;

                }
                else
                {
                    m_RightFingerGoodPosition = m_RightFingerLast + 1;
                    m_LeftFingerGoodPosition = m_LeftFingerLast;
                }
                break;
        }


        if(m_RealPasCompteur==1)
        {
            m_RealPasCompteur = 0;
        }
        else
        {
            m_RealPasCompteur = 1;
        }


        TapeVerification(_move);
    }

    void TapeVerification(MouvementName _move)
    {
        if (_move != MouvementName.Idle)
        {
            if (m_LeftFinger == m_LeftFingerGoodPosition && m_RightFinger == m_RightFingerGoodPosition)
            {
                ChangeScore();
                Debug.Log("GOOD");
            }
        }

        if (m_LeftFinger != -1)
        {
            m_LeftFingerLast = m_LeftFinger;
        }

        if (m_RightFinger != -1)
        {
            m_RightFingerLast = m_RightFinger;
        }
    }


    /*
    void ChangeGoodPosition()
    {
        switch (m_CurrentMouvement)
        {
            case MouvementName.Idle:
                if (m_PasCompteur == 1)
                {
                    m_TempoCanon.Send(MouvementName.Idle);
                    m_LeftFingerGoodPosition = m_LeftFingerLast;
                    m_RightFingerGoodPosition = m_RightFingerLast;
                }
                else
                {
                    m_LeftFingerGoodPosition = m_LeftFingerLast;
                    m_RightFingerGoodPosition = m_RightFingerLast;
                }

                break;

            case MouvementName.TapLeft:

                if (m_PasCompteur == 1)
                {
                    m_TempoCanon.Send(MouvementName.TapLeft);
                    m_LeftFingerGoodPosition = m_LeftFingerLast - 1;
                    m_RightFingerGoodPosition = m_RightFingerLast;
                    Debug.Log(m_LeftFingerGoodPosition);

                }
                else
                {
                    m_LeftFingerGoodPosition = m_LeftFingerLast + 1;
                    m_RightFingerGoodPosition = m_RightFingerLast;
                }
                break;
        }
    }
    */
    /*
    void TapeVerification()
    {
        if (m_CurrentMouvement != MouvementName.Idle)
        {

            if(m_LeftFinger == m_LeftFingerGoodPosition)
            {
                Debug.Log("Left OK");

            }

            if (m_RightFinger == m_RightFingerGoodPosition)
            {
                Debug.Log("Right OK");

            }


            if (m_LeftFinger == m_LeftFingerGoodPosition && m_RightFinger == m_RightFingerGoodPosition)
            {
                ChangeScore();
                Debug.Log("GOOD");
            }
        }

        if (m_LeftFinger != -1)
        {
            m_LeftFingerLast = m_LeftFinger;
        }

        if (m_RightFinger != -1)
        {
            m_RightFingerLast = m_RightFinger;
        }



    }
    */

  
    void ChangeScore()
    {
        m_Score++;
        m_ScoreText.text = m_Score.ToString();
    }
   

    public void EndGame()
    {
        PlayerPrefs.SetInt("Score", m_Score);
    }

}
