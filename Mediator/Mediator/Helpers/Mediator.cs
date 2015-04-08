using System;
using System.Collections.Generic;

namespace Mediator.Helpers
{
    public static class Mediator
    {
        private static readonly IDictionary<string, List<Action<object>>> Dict = new Dictionary<string, List<Action<object>>>();

        public static void Register(string token, Action<object> callback)
        {
            if (!Dict.ContainsKey(token))
            {
                var list = new List<Action<object>> {callback};
                Dict.Add(token, list);
            }
            else
            {
                bool hasFound = false;
                foreach (var item in Dict[token])
                {
                    if (item.Method.ToString() == callback.Method.ToString())
                    {
                        hasFound = true;
                    }
                }
                if (!hasFound)
                {
                    Dict[token].Add(callback);
                }
            }
        }

        public static void Unregister(string token, Action<object> callback)
        {
            if (Dict.ContainsKey(token))
            {
                Dict[token].Remove(callback);
            }
        }

        public static void NotifyColleagues(string token, object args)
        {
            if (Dict.ContainsKey(token))
            {
                foreach (var callback in Dict[token])
                {
                    callback(args);
                }
            }
        }
    }
}