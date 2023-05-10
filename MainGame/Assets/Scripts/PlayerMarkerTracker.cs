//using PlasticGui.WorkspaceWindow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarkerTracker : MonoBehaviour
{    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MainGameController.Instance.PlayerObject!=null)
        {
            this.transform.position = get2DVector3(MainGameController.Instance.PlayerObject.transform.position);
        }
    }
    private Vector3 get2DVector3(Vector3 target)
    {
        var result = new Vector3(target.x, 0.73f, target.z);
        return result;
    }    
}
