using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectedBreaking : MonoBehaviour
{
    public float breakRadius = .2f;
    public float breakForce = 100;
    private List<ConnectedFragments> fragments;

    void Start()
    {
        InitFragments();
    }

    //adds the pre-fragmented fragments and their connections to a list
    private void InitFragments()
    {
        fragments = new List<ConnectedFragments>();
        fragments.AddRange(transform.GetComponentsInChildren<ConnectedFragments>());

        //adding adjacent fragment connections for every fragment to the list
        foreach (ConnectedFragments fragment in fragments)
        {
            //since fragments are oddly shaped, the box collider will detect the other fragments directly touching
            BoxCollider col = fragment.gameObject.AddComponent<BoxCollider>();

            //check if other fragments collide with the BoxCollider, then add to ConnectedFragments's connections list
            Collider[] hitColliders = Physics.OverlapBox(fragment.transform.position, col.size / 2, fragment.transform.rotation);
            int i = 0;

            while (i < hitColliders.Length)
            {
                //checking if it is a fragment of this object
                if (hitColliders[i].GetComponent<ConnectedFragments>() && hitColliders[i].transform.root == fragment.transform.root && hitColliders[i].gameObject != fragment.gameObject)
                {
                    fragment.connections.Add(hitColliders[i].GetComponent<ConnectedFragments>());
                    hitColliders[i].GetComponent<ConnectedFragments>().connections.Add(fragment);
                    Debug.Log(fragment.name + "_" + hitColliders[i].name);
                }
                i++;
            }
            Destroy(col); // remove the unnecessary boxCollider
        }
    }

    //fractures the piece by making the fragment kinematic, as well as nearby fragments for realism
    public void Fracture(Vector3 impactPt, Vector3 force)
    {
        foreach (ConnectedFragments fragment in fragments)
        {
            if (Vector3.Distance(fragment.transform.position, impactPt) < breakRadius)
            {
                // If a given fragment is close to the collision, free it.
                fragment.connections = new List<ConnectedFragments>();
                fragment.grounded = false;
                fragment.GetComponent<Rigidbody>().isKinematic = false;
                fragment.GetComponent<Rigidbody>().AddForceAtPosition(force, impactPt, ForceMode.Force);
            }
        }
    }
}

