using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioClip goodJob;

    public AudioClip correctPerson;
    public AudioClip correctPlace;
    public AudioClip correctThing;

    public AudioClip wrongPerson;
    public AudioClip wrongPlace;
    public AudioClip wrongThing;
    

    // Object declared as a singleton, can be accessed using SoundManager.Instance from anywhere
    private static SoundManager instance = null;
    public static SoundManager Instance
    {
        get { return instance; }
    }

    // Ensures two copies of the singleton do not exist
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

  /*  public IEnumerator playCorrectAudio(AudioClip word, AnswerBin.AnswerType answerType)
    {
        AudioSource jukebox = this.gameObject.GetComponent<AudioSource>();

        // "Good Job!"
        jukebox.PlayOneShot(goodJob);

        yield return new WaitForSeconds(goodJob.length+0.5f);

        // "<word> "
        jukebox.PlayOneShot(word);

        yield return new WaitForSeconds(word.length);

        // "is a (Person/Place/Thing)."
        if (answerType == AnswerBin.AnswerType.PERSON)
        {
            jukebox.PlayOneShot(correctPerson);
        }
        else if (answerType == AnswerBin.AnswerType.PLACE)
        {
            jukebox.PlayOneShot(correctPlace);
        }
        else if (answerType == AnswerBin.AnswerType.THING)
        {
            jukebox.PlayOneShot(correctThing);
        }
    }

     public IEnumerator playWrongAudio(AudioClip word, AnswerBin.AnswerType answerType)
    {
        AudioSource jukebox = this.gameObject.GetComponent<AudioSource>();

        // "<word>"
        jukebox.PlayOneShot(word);
        
        yield return new WaitForSeconds(word.length);

        // "is not a (Person/Place/Thing)."
        if (answerType == AnswerBin.AnswerType.PERSON)
        {
            jukebox.PlayOneShot(wrongPerson);
        } else if (answerType == AnswerBin.AnswerType.PLACE)
        {
            jukebox.PlayOneShot(wrongPlace);
        } else if (answerType == AnswerBin.AnswerType.THING)
        {
            jukebox.PlayOneShot(wrongThing);
        }
    }*/
}
