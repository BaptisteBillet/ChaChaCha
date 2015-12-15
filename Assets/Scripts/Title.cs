using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Title : MonoBehaviour {

    public Text m_Press;

    public Color m_Orange;
    public Color m_White;

    bool m_isWhite=false;

    bool m_CanPass = false;

	// Use this for initialization
	void Start () {

        StartCoroutine(pingPong());
    }
	
    
    IEnumerator pingPong()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);

            if(m_isWhite)
            {
                m_Press.color = m_Orange;
            }else
            {
                m_Press.color = m_White;
            }

            m_isWhite = !m_isWhite;

        }


    }




    // Update is called once per frame
    void Update()
    {

        if (Input.anyKey)
        {
            StopAllCoroutines();
            SceneManager.LoadScene("Game");
        }
    }

}
