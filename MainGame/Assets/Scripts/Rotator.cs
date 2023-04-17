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
        if (direction_ == Direction.Left)
        {
            PaddleUp(KeyCode.F);
        }
        else
        {
            PaddleUp(KeyCode.J);
        }
        
    }

    public void PaddleUp(KeyCode key)
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrength_;
        spring.damper = flipperDamper_;
        if (Input.GetKey(key))
        {
            spring.targetPosition = pressedPosition_;
        }
        else
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