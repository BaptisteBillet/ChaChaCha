using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreFinal : MonoBehaviour {

    private Text m_Text;

    public Text m_Titre;

    float m_Score;

	// Use this for initialization
	void Start () {

        m_Text=GetComponent<Text>();

        m_Text.text = PlayerPrefs.GetInt("Score", 0).ToString();

        m_Score = PlayerPrefs.GetInt("Score", 0);

        if(m_Score>=40)
        {
            m_Titre.text = "Muy Bien!";
        }
        else
        {
            m_Titre.text = "Baillas como un pescado en el suelo";
        }


    }
	
	
}
