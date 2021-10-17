using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackalgorithm : MonoBehaviour
{
    [SerializeField] float movespeed = 0f;
    private float deletion = -100f;
    [SerializeField] GameObject trackprefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(-Vector3.forward * Time.deltaTime * movespeed);
        if (gameObject.transform.position.z<= deletion)
        {

            Destroy(gameObject.transform.GetChild(0).gameObject);
            deletion = deletion - 100;
            GameObject temp = Instantiate(trackprefab, Vector3.zero, Quaternion.identity);
            gameObject.transform.GetChild(gameObject.transform.childCount - 1);
            temp.transform.position = new Vector3(0, 0, gameObject.transform.GetChild(gameObject.transform.childCount - 1).transform.position.z+100f);
            temp.transform.parent = gameObject.transform;
        }
    }
}
