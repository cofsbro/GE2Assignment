using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Testing other meathods to simulate being in the emptiness of space, rather than using the cubric built in unity skybox
// letting one to paste a repeating image on all side;


public class ReverseSphere : MonoBehaviour
{

    public Transform mainship;

    // Start is called before the first frame update
    void Start()
    {
        //rather then seeing the angles of the sky box using a sphrere instead as the trinagles are easier to hide and make it look like global
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;

        Vector3[] normals = mesh.normals;

        for(int i = 0; i < normals.Length; i++)
        {
            normals[i] = -1 * normals[i];
        }

        mesh.normals = normals;

        //Paste it in reverse order like a mirror as you are turning the meesh inside out so to speak to avoid pattern errors on the polygon trianles

        for(int i = 0; i<mesh.subMeshCount;i++)
        {
            int[] tris = mesh.GetTriangles(i);

            for(int j = 0; j< tris.Length;j+=3)
            {
                int temp = tris[j];
                tris[j] = tris[j + 1];
                tris[j + 1] = temp;
            }

            mesh.SetTriangles(tris, i);

        }
            
        

        
    }

    //Follow the main ship so that it will never leave the skybox and
    // only issues is add more light sources as you are within a dark object and black space patterns make it harder to see

    // Update is called once per frame
    void Update()
    {
        transform.position = mainship.position;
        
    }
}
