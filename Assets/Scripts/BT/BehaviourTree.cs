using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BehaviourTree : MonoBehaviour
{
    private Node root;


    void Start()
    {
        root = new Selector();
        var newSequence = new Sequence();
        
        

        root.AddChild(newSequence);
    }

    // Update is called once per frame
    void Update()
    {
        root.Execute();
    }

    bool v()
    {
        return true;
    }
}
