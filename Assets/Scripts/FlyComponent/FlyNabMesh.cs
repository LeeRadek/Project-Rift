using System.Collections.Generic;
using UnityEngine;


public class FlyNabMesh : MonoBehaviour
{

    public struct ColliderStruct
    {
        public Collider coll;
        public int index;
    }



    public int boxAmount = 5;

    public float boxSize = 1;
    public int gridWith = 1;
    public int gridHeight = 1;
    public int gridDepth = 1;
    public bool showBoxes = false;
    private Vector3 boxSizeVector;



    public List<Collider> colliders = new List<Collider>();
    public List<Collider> collidersTriggered = new List<Collider>();

    private RaycastHit hit;

    void Start()
    {
        boxSizeVector = new Vector3(boxSize, boxSize, boxSize);
        CreateCollisionGrid();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateCollisionGrid()
    {

        for (int i = 0; i < boxAmount; i++)
        {
            for (int j = 0; j < boxAmount; j++)
            {
                for (int k = 0; k < boxAmount; k++)
                {
                    CreateBoxCollision(i * boxSize, j * boxSize, k * boxSize, i);
                }
            }
        }
    }

    void CreateBoxCollision(float x, float y, float z, int index)
    {


        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z);
        cube.transform.localScale = new Vector3(gridWith, gridHeight, gridDepth);
        cube.transform.SetParent(transform, true);

        colliders.Add(cube.GetComponent<Collider>());

        Destroy(cube.GetComponent<MeshRenderer>());

    }

    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Collider childCollider = child.GetComponent<Collider>();

            foreach (ContactPoint contact in collision.contacts)
            {
                collidersTriggered.Add(childCollider);
            }

        }
    }


    [ExecuteInEditMode]
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        if (showBoxes)
        {
            for (int i = 0; i < boxAmount; i++)
            {
                for (int j = 0; j < boxAmount; j++)
                {
                    for (int k = 0; k < boxAmount; k++)
                    {
                        Vector3 center = transform.position + new Vector3(i * boxSize, j * boxSize, k * boxSize);
                        Vector3 size = new Vector3(gridWith, gridHeight, gridDepth);


                        Gizmos.DrawWireCube(center, size);

                        foreach (Collider collider in collidersTriggered)
                        {
                            if (colliders.Contains(collider))
                            {
                                Gizmos.color = Color.red;

                                break;
                            }
                            else
                            {
                                Gizmos.color = Color.yellow;
                            }
                        }
                    }
                }
            }
        }

    }

}
