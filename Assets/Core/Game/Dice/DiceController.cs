using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    [SerializeField]
    private FaceDetection _faceDetection;

    private Dictionary<DeckActivationStates, EventType> _deckStates = new Dictionary<DeckActivationStates, EventType>();
    private DeckActivationStates _currentState;

    private void OnEnable()
    {
        _faceDetection.SubscribeToEvent(OnDiceValueSelected);
    }

    private void OnDisable()
    {
        _faceDetection.UnsubscribeFromEvent(OnDiceValueSelected);
    }

    public void ActivateDiceDeck(DeckActivationStates state)
    {
        _currentState = state;
        gameObject.SetActive(true);
    }

    private void OnDiceValueSelected(int diceValue)
    {
        if (_deckStates.Count == 0)
        {
            _deckStates.Add(DeckActivationStates.ByPlayer, EventType.DICE_VALUE_SETTED_PLAYER);
            _deckStates.Add(DeckActivationStates.ByEnemy, EventType.DICE_VALUE_SETTED_ENEMY);
        }

        if (diceValue != -1)
        {
            EventBus.Dispatch(_deckStates[_currentState], diceValue);
            gameObject.SetActive(false);
        }
    }
}

public enum DeckActivationStates
{
    ByPlayer,
    ByEnemy
}
