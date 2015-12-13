using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Wink : MonoBehaviour {
    
    private Animator m_Animator;

    void Start()
    {
        m_Animator=GetComponent<Animator>();
        StartCoroutine(EWink());
    }


    IEnumerator EWink()
    {
        while (true)
        {
            float _time = Random.Range(3, 10);

            yield return new WaitForSeconds(_time);
            m_Animator.SetTrigger("Wink");

        }
    }

}
