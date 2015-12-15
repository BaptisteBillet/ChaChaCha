using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Tempo : MonoBehaviour {

    public float m_Speed;

    public Sprite m_Idle;
    public Sprite m_TapLeft;
    public Sprite m_TapRight;
    public Sprite m_StepLeft;
    public Sprite m_StepRight;
    public Sprite m_TapFront;

    public SpriteRenderer m_Indication;

    MouvementName m_Mouvement;

    private GameManager m_GameManager;
	
    public void SetMouvement( MouvementName _move, GameManager _manager, bool _instruction=false)
    {
        m_GameManager = _manager;

        m_Mouvement = _move;

        if(_instruction)
        {
            switch (m_Mouvement)
            {
                case MouvementName.StepLeft:
                    m_Indication.sprite = m_StepLeft;
                    break;
                case MouvementName.StepRight:
                    m_Indication.sprite = m_StepRight;
                    break;
                case MouvementName.TapFront:
                    m_Indication.sprite = m_TapFront;
                    break;
                case MouvementName.TapLeft:
                    m_Indication.sprite = m_TapLeft;
                    break;
                case MouvementName.TapRight:
                    m_Indication.sprite = m_TapRight;
                    break;

                    /*
                case MouvementName.Idle:
                    m_Indication.sprite = m_Idle;
                    break;
                    */
            }
        }

        
    }


	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.left * m_Speed * Time.deltaTime);
	}
  
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Animation")
        {
            if (m_GameManager != null)
            {
                m_GameManager.BlockAnimationContact(m_Mouvement);
            }

        }
        else
        {
            if (m_GameManager != null)
            {
                m_GameManager.BlockContact(m_Mouvement);
            }

            Debug.Log(m_Mouvement);

            if(m_Mouvement==MouvementName.End)
            {
                PlayerPrefs.SetInt("Score", m_GameManager.m_Score);
                SceneManager.LoadScene("End");
            }


            Destroy(this.gameObject);
        }

        
       
    }
}
