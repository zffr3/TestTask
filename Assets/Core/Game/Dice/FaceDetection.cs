using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FaceDetection : MonoBehaviour
{
    [SerializeField]
    private Dice _dice;

    private UnityAction<int> _onFaceDetected;

    private void OnTriggerStay(Collider other)
    {
        if (_dice != null)
        {
            if (_dice.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                int faceNum = -1;
                if (int.TryParse(other.name, out faceNum))
                {
                    _onFaceDetected?.Invoke(faceNum);
                }

            }
        }
    }

    public void SubscribeToEvent(UnityAction<int> handler)
    {
        _onFaceDetected += handler;
    }

    public void UnsubscribeFromEvent(UnityAction<int> handler)
    {
        _onFaceDetected += handler;
    }
}
