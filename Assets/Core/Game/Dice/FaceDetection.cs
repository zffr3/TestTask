using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDetection : MonoBehaviour
{
    [SerializeField]
    Dice _dice;


    private void OnTriggerStay(Collider other)
    {
        if (_dice != null)
        {
            if (_dice.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                int faceNum = -1;
                if (int.TryParse(other.name, out faceNum))
                {
                    Debug.Log(faceNum);
                }

            }
        }
    }
}
