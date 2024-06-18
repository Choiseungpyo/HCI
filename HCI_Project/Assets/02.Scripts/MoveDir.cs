using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class MoveDir : MonoBehaviour
{
    public GameObject Dir;


    private void Start()
    {
        Dir.SetActive(true);

        StartCoroutine(SetDir());
    }

    IEnumerator SetDir()
    {
       for(int i=0; i<6; i++)
        {
            Dir.SetActive(false);

            yield return new WaitForSeconds(0.5f);

            Dir.SetActive(true);

            yield return new WaitForSeconds(0.5f);
        }
    }
}
