using System;
using System.Collections.Generic;
using System.Linq;

namespace MyEvent
{
    public static class EventManager
    {
        private static Dictionary<Type, List<Delegate>> actionsDictionary;

        public static void Register<T>(Action<T> callback) where T : CustomEvent
        {
            var type = typeof(T);
            actionsDictionary ??= new Dictionary<Type, List<Delegate>>();

            if (!actionsDictionary.ContainsKey(type))
            {
                actionsDictionary.Add(type, new List<Delegate>());
            }

            if (!actionsDictionary[type].Contains(callback))
            {
                actionsDictionary[type].Add(callback);
            }
        }


        public static void Unregister<T>(Action<T> callback) where T : CustomEvent
        {
            if(actionsDictionary == null) return;

            var type = typeof(T);
            if(!actionsDictionary.ContainsKey(type)) return;
            
            if(actionsDictionary[type].Contains(callback))
            {
                actionsDictionary[type].Remove(callback);
            }
        }


        public static void RaiseEvent<T>(T args) where T : CustomEvent
        {
            if(actionsDictionary == null) return;

            var type = typeof(T);
            if (actionsDictionary.ContainsKey(type))
            {
                var actions = actionsDictionary[type];
                foreach (var action in actions.Cast<Action<T>>().ToList())
                {
                    action(args);
                }
            }
        }


        public static void Clear()
        {
            if(actionsDictionary == null) return;
            
            actionsDictionary.Clear();
            actionsDictionary = null;
        }
    }
    
    
    public abstract class CustomEvent {}
}