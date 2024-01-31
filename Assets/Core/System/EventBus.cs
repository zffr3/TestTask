using System.Collections.Generic;
using UnityEngine.Events;

public static class EventBus
{
    private static Dictionary<EventType, EventContainer> _eventList;

    public static void SubscribeToEvent(EventType type, UnityAction<object> handler)
    {
        if (_eventList == null)
        {
            Initialize();
        }

        EventContainer container = null;
        if (_eventList.TryGetValue(type, out container))
        {
            container.AddHandler(handler);
        }
        else
        {
            container = new EventContainer();
            container.AddHandler(handler);
            _eventList.Add(type, container);
        }
    }

    public static void UnsubscribeFromEvent(EventType type, UnityAction<object> handler)
    {
        if (_eventList == null)
        {
            Initialize();
            return;
        }

        EventContainer container = null;
        if (_eventList.TryGetValue(type, out container))
        {
            container.RemoveHandler(handler);
        }
    }

    public static void Dispatch(EventType type, object param)
    {
        if (_eventList == null)
        {
            Initialize();
            return;
        }

        EventContainer container = null;
        if (_eventList.TryGetValue(type, out container))
        {
            container.Invoke(param);
        }
    }

    private static void Initialize()
    {
        _eventList = new Dictionary<EventType, EventContainer>();
    }

    private class EventContainer
    {
        private List<UnityAction<object>> _handlers { get; set; }

        public void AddHandler(UnityAction<object> handler)
        {
            if (_handlers == null)
            {
                Initialize();
            }
            _handlers.Add(handler);
        }

        public void RemoveHandler(UnityAction<object> handler)
        {
            if (_handlers == null)
            {
                Initialize();
                return;
            }

            _handlers.Remove(handler);
        }

        public void Invoke(object param)
        {
            foreach (UnityAction<object> handler in _handlers)
            {
                handler?.Invoke(param);
            }
        }

        private void Initialize()
        {
            _handlers = new List<UnityAction<object>>();
        }
    }
}

public enum EventType
{
    SPLASH_ATTACK_PLAYER,
    SPLASH_ATTACK_ENEMY,
    SPELL_ATTACK_PLAYER,
    SPELL_ATTACK_ENEMY
}
