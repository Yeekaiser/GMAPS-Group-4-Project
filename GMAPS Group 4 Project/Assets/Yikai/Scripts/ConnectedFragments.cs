using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectedFragments : MonoBehaviour
{
    public bool grounded;   //this is a bool that should be manually checked in the inspector, 
    public bool connected;  //this is a bool that determines if a fragment is connected to any other fragments

    public List<ConnectedFragments> connections;

    private ConnectedBreaking parent;

    private void Start()
    {
        parent = transform.root.GetComponent<ConnectedBreaking>();  //gets the highest GameObject in the hierarchy 
        GetComponent<Rigidbody>().isKinematic = true;   //ensures that the components have a rigidbody, but are not affected by forces yet
    }

    void Update()
    {
        //make sure it is connected to another fragment
        for (int i = 0; i < connections.Count; i++) 
        {
            if (!connections[i].grounded && !connections[i].connected)
            {
                connections.Remove(connections[i]);
            }
        }
        //check if its connected to a ground piece or a piece that is connected to a ground piece
        bool notFloating = false;

        for (int i = 0; i < connections.Count; i++)
        {
            if (connections[i].grounded)
            {
                notFloating = true;
                break;
            }

            //check if one more layer is connected to a ground piece
            for (int j = 0; j < connections[i].connections.Count; j++)
            {
                if (connections[i].connections[j].grounded)
                {
                    notFloating = true;
                    break;
                }
            }
        }

        connected = notFloating && connections.Count >= 1 || grounded;

        GetComponent<Rigidbody>().isKinematic = connected;  //if not connected, the piece will be affected by forces and be fragmented
    }

    //when collided with, if the force received was higher than the strength of the material
    void OnCollisionEnter(Collision collision)
    {
        if (collision.impulse.magnitude > parent.breakForce)
        {
            // remove the connection between the hit fragment and other fragments
            connections = new List<ConnectedFragments>();
            grounded = false;

            parent.Fracture(collision.contacts[0].point, collision.impulse);
        }
    }

    //draws a line between the fragment and the adjacent fragments, for visualisation
    void OnDrawGizmosSelected()
    {
        for (int i = 0; i < connections.Count; i++)
        {
            Gizmos.DrawLine(transform.position, connections[i].transform.position);
        }
    }
}
