using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Direction direction_;
    [SerializeField] private HingeJoint hingeJoint_;
    [SerializeField] private float restPosition_ = 0f;
    [SerializeField] private float pressedPosition_ = 45f;
    [SerializeField] private float hitStrength_ = 10000f;
    [SerializeField] private float flipperDamper_ = 150f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var keycode = direction_ == Direction.Left ? KeyCode.F : KeyCode.J;
        paddleUp(keycode);                
    }

    private void paddleUp(KeyCode key)
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrength_;
        spring.damper = flipperDamper_;
        if (Input.GetKey(key))
        {
            spring.targetPosition = pressedPosition_;
        }
        else if(Input.GetKeyUp(key))
        {
            spring.targetPosition = restPosition_;
        }
        hingeJoint_.spring = spring;
    }

}
[System.Serializable]
public enum Direction
{
    Left,
    Right,
}