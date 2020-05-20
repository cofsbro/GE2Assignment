using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class follower : MonoBehaviour
{
    //the portal travel follow meathod in which the ship follows along the curve

    [SerializeField]
    private Transform[] routes;

    private int destination;

    private float tParm;

    private Vector3 shipPos;

    private float speed = .5f;

    private bool coroutine;

    float switchTimer = 2000f;
    

    // Start is called before the first frame update
    void Start()
    {
        tParm = 0f;
        destination = 0;
        coroutine = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (coroutine)
        {
            StartCoroutine(GoByRoute(destination));
        }

        switchTimer--;

        if(switchTimer <= 0)
        {
            SceneManager.LoadScene(2);
        }
       
    }

    private IEnumerator GoByRoute(int routenum) 
    {
        coroutine = false;

        //Uses the points that developed the curve as refrences in the array
        Vector3 p0 = routes[routenum].GetChild(0).position;
        Vector3 p1 = routes[routenum].GetChild(1).position;
        Vector3 p2 = routes[routenum].GetChild(2).position;
        Vector3 p3 = routes[routenum].GetChild(3).position;

        // draws and travels down the pathway within the paramaters of the angle
        while(tParm < 1)
        {
            tParm += Time.deltaTime * speed;

            shipPos = Mathf.Pow(1 - tParm, 3) * p0 +
                3 * Mathf.Pow(1 - tParm, 2) * p1 +
                3 * (1 - tParm) * Mathf.Pow(tParm, 2) * p2 +
                Mathf.Pow(tParm, 3) * p3;

            transform.position = shipPos;
            Quaternion rotate = Quaternion.LookRotation(shipPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotate, .5f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        tParm = 0f;

        //going back to starting pos so to do a few loops before new scene and make it look like it traveled down various paths
        // (Could used better skyboxs and meathods to show travel in the game scene
        destination += 1;

        if (destination > routes.Length - 1)
            destination = 0;

        coroutine = true;

    }
}
