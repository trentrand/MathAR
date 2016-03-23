using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.Space))
	    {
	        animator.SetInteger("AnimState", 1);
	    }
	    else
	    {
	        animator.SetInteger("AnimState", 0);
	    }
	}
}
