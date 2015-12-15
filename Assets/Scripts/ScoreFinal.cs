using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreFinal : MonoBehaviour {

    private Text m_Text;

    public Text m_Titre;

    float m_Score;

    bool m_CanPass = false;

    // Use this for initialization
    void Start () {

        SoundManagerEvent.emit(SoundManagerType.APPLAUDISSEMENT);

        m_Text =GetComponent<Text>();

        m_Text.text = PlayerPrefs.GetInt("Score", 0).ToString();

        m_Score = PlayerPrefs.GetInt("Score", 0);

        if (m_Score < 10)
        {
            m_Titre.text = "No bueno!";
        }

        if (m_Score >= 10 && m_Score < 30)
        {
            m_Titre.text = "Passable";
        }

        if (m_Score >= 30 && m_Score < 50)
        {
            m_Titre.text = "Bien!";
        }

        if (m_Score >= 50 && m_Score < 72)
        {
            m_Titre.text = "Muy Bien!";
        }

        if (m_Score>=72)
        {
            m_Titre.text = "Perfecto !";
        }



    }
	

    void Update()
    {

        if (m_CanPass == true)
        {
            if (Input.anyKey)
            {
                StopAllCoroutines();
                SceneManager.LoadScene("Game");
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.G) && Input.GetKeyUp(KeyCode.H))
            {
                m_CanPass = true;
            }
        }


    }
	
}
