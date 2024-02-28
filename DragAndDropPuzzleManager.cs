using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragAndDropPuzzleManager : MonoBehaviour
{
    public UnityEvent onPuzzleSolved;
    public bool solved;

    public List<DraggbleScript> draggableItems = new List<DraggbleScript>();
    

    // Update is called once per frame
    void Update()
    {
        if(!solved){
            foreach(var item in draggableItems){
                if(!item.isInARightPlace){
                    return;
                }
            }
            solved= true;
            onPuzzleSolved.Invoke();
        }
    }
}
