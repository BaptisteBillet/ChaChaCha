using UnityEngine;
using System.Collections;

public class RoomManager : MonoBehaviour {

    public GameObject Sol;
    public GameObject MurGauche;
    public GameObject MurDroit;
    public GameObject Plafond;
    public GameObject Fond;

    public Material m_PlaneMaterial;

    private bool m_Pair = false;

    // Use this for initialization
    void Start () {
	
	}
	
    public void Pulse()
    {
        if(m_Pair)
        {
            m_PlaneMaterial.SetFloat("_MultiplyValue", 0.5f);
        }
        else
        {
            m_PlaneMaterial.SetFloat("_MultiplyValue", 0.6f);
        }
        
        m_Pair =! m_Pair;


    }
   

	// Update is called once per frame
	void Update () {
	
	}
}
