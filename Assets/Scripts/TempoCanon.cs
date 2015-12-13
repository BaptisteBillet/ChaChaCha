using UnityEngine;
using System.Collections;

public class TempoCanon : MonoBehaviour {

    public GameObject m_MarqueurTemps;
    private GameObject m_Cube;

    public GameManager m_GameManager;

    private int a = 0;

    public void Send(MouvementName _move, bool _instruction=false)
    {
        m_Cube=Instantiate(m_MarqueurTemps, transform.position, transform.rotation)as GameObject;

        m_Cube.GetComponent<Tempo>().SetMouvement(_move, m_GameManager, _instruction);

        a++;
        if(a==8)
        {
            m_Cube.GetComponent<Renderer>().material.color = Color.red;
            a = 0;
        }
    }
    public void Send()
    {
        m_Cube = Instantiate(m_MarqueurTemps, transform.position, transform.rotation) as GameObject;
        a++;
        if (a == 8)
        {
            m_Cube.GetComponent<Renderer>().material.color = Color.red;
            a = 0;
        }
    }


}
