using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Was intended to use this code alond with others to manage various diffrent soundsclips in scene 1
public class AudioManager : MonoBehaviour
{

    //Cannot have multiple sound clips in on one object or parent or in same code otherwise they all play at once
    public AudioSource dial;

    //clamp, rocket;


    //Setting up movement delays with soundclip
    public Transform gatespin;
    public GameObject closedgate, opengate, portal, unusedgate, moveto;
    public Transform leftclamp, rightclamp;


    //set up activation when music is over
    bool activation = false;
    bool declamp = false;






    // Start is called before the first frame update
    void Start()
    {

        
        closedgate.gameObject.SetActive(true);
        opengate.gameObject.SetActive(false);
        portal.gameObject.SetActive(false);
        unusedgate.gameObject.SetActive(false);

        //Play sound and activate function when clip is over. Had a 6 second clip and a minute long clip to test.
        dial = GetComponent<AudioSource>();
        Invoke("audioFinished", dial.clip.length);




    }


    //Runs when activation sound is over
    void audioFinished()
    {
        //swaps the prefabs child of the stargat and makes the portal and activated version visible
        //Could not get a proper meesh or animation to do the portal effect
        closedgate.gameObject.SetActive(false);
        opengate.gameObject.SetActive(true);
        portal.gameObject.SetActive(true);

        // if true the cube clamps detach from the Stargate
        declamp = true;

        //clamp = GetComponent<AudioSource>();

        //Does a delay start before camera of ship moves into the gate
        StartCoroutine(Moving());

        Debug.Log("Audio");
    }

    // Update is called once per frame
    void Update()
    {
        // if sound is playing the ring will spin
        if (dial.isPlaying)
        {
            gatespin.Rotate(new Vector3(0f, 0f, 20f * Time.deltaTime));



        }

        //if activated the clamps will slowly rotate (tried to do the illusion as hopefully the next scene switch would activate before
        // they do a full clockwise spin
        if (declamp == true)
        {

            leftclamp.Rotate(new Vector3(-5f * Time.deltaTime, 0f, 0f));
            rightclamp.Rotate(new Vector3(5f * Time.deltaTime, 0f, 0f));



        }

        //after the second delay yo make sure it all is ok the ship/camera enters the portal
        if (activation == true)
        {

            moveto.transform.position = Vector3.Lerp(moveto.transform.position, portal.transform.position, Time.deltaTime * 0.25f);
            moveto.transform.LookAt(portal.transform);

            //using UnityScreneManagment to switch screens in order
            if (Vector3.Distance(moveto.transform.position, portal.transform.position) < 20f)
            {
                SceneManager.LoadScene(1);

            }


        }

    }


    // delay the movement to show the de-clamping and to simulate final ready checks before launch
        IEnumerator Moving()
        {
            yield return new WaitForSeconds(4);
            //rocket = GetComponent<AudioSource>();


            activation = true;

        }
    
}
