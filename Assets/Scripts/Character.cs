using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    /*
     * AnimState 0 = idle (manually apply root motion for sway effect)
     * AnimState 1 = walking
    */
    private Animator animator;

    /*
    * CharacterType.Hundreds = 100
    * CharacterType.Tens = 10
    * CharacterType.One = 1
    */
    public LevelManager.CharacterType characterType;

    // Constructor to set character type and initial variables
    public Character(LevelManager.CharacterType characterType)
    {
        this.characterType = characterType;
    }

    void Awake()
    {
        // Get reference to Animator
        animator = GetComponent<Animator>();
        StartIdleAnimation();
    }

    void Start()
    {
        // TODO: remove after state macine is implemented
        TraversePath();
    }

    void Update()
    {

    }

    // Traverse iTween path
    void TraversePath()
    {
        StartWalkAnimation();

        // (int)characterType returns 100/10/1, depending on enum value
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Path" + (int)characterType),
       "orienttopath", true, "time", 7, "easetype", "linear", "onComplete", "FinishedTraversingPath"));
    }

    // Called when iTween.MoveTo() path traversal is complete
    void FinishedTraversingPath()
    {
        iTween.LookTo(gameObject, iTween.Hash("looktarget", transform.position + new Vector3(0,0,0.1f), "axis", "y"));
        StartIdleAnimation();
        DropPlaceValues();
    }

    // Instantiate 00 or 0 prefabs and drop next to Character gameObject
    void DropPlaceValues()
    {
        switch (characterType)
        {
            case LevelManager.CharacterType.Hundreds:
                GameObject hundredsPlaceHolder = Instantiate(LevelManager.Instance.hundredsPlaceHolderPrefab);
                hundredsPlaceHolder.transform.parent = transform.FindChild("PlaceHolder").transform;

                hundredsPlaceHolder.transform.rotation = transform.rotation;
                hundredsPlaceHolder.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                hundredsPlaceHolder.transform.localScale = Vector3.one;

                break;
            case LevelManager.CharacterType.Tens:
                GameObject tensPlaceHolder = Instantiate(LevelManager.Instance.tensPlaceHolderPrefab);
                tensPlaceHolder.transform.parent = transform.FindChild("PlaceHolder").transform;

                tensPlaceHolder.transform.rotation = transform.rotation;
                tensPlaceHolder.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                tensPlaceHolder.transform.localScale = Vector3.one;

                break;
        }
    }

    // Switch Animator active state to Idle and apply root motion (for sway effect)
    void StartIdleAnimation()
    {
        animator.applyRootMotion = true;
        animator.SetInteger("AnimState", 0);
    }

    // Switch Animator active state to Walk and disable root motion (since iTween takes care of movement)
    void StartWalkAnimation()
    {
        animator.applyRootMotion = false;
        animator.SetInteger("AnimState", 1);
    }

}
