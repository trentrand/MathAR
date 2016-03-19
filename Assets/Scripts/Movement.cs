using UnityEngine;
using System.Collections;
using System.Linq;

public class Movement : MonoBehaviour
{
    private GameObject camera;
    private bool hundredsDone = false;
    private bool tensDone = false;
    private bool onesDone = false;

   public GameObject hundred;
    public GameObject ten;
    public GameObject one;


	// Use this for initialization
	void Start ()
	{
        camera = GameObject.Find("ARCamera");
        
        iTween.MoveTo(hundred, iTween.Hash("path", iTweenPath.GetPath("WalkingPathHundreds"),
      "orienttopath", true, "time", 7, "easetype", "linear", "onComplete", "finishedHundredsPath"));

    }

    void finishedHundredsPath()
    {
        Debug.Log("done 100s");
        hundred.GetComponent<Animator>().Play("Idle");
        hundredsDone = true;

        iTween.MoveTo(ten, iTween.Hash("path", iTweenPath.GetPath("WalkingPathTens"),
     "orienttopath", true, "time", 7, "easetype", "linear", "onComplete", "finishedTensPath"));
    }

    void finishedTensPath()
    {
        Debug.Log("done 10s");
        ten.GetComponent<Animator>().Play("Idle");
        tensDone = true;
        iTween.MoveTo(one, iTween.Hash("path", iTweenPath.GetPath("WalkingPathOnes"),
     "orienttopath", true, "time", 7, "easetype", "linear", "onComplete", "finishedOnesPath"));
    }

    void finishedOnesPatsh()
    {
        Debug.Log("done 1s");
        one.GetComponent<Animator>().Play("Idle");
        onesDone = true;
    }

    // Update is called once per frame
    void Update ()
	{
       if (onesDone)
       iTween.LookTo(gameObject, iTween.Hash("time", 1, "looktarget", camera));
	}
}
