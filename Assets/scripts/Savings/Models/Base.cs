using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace ItemsSorting
{
    [Serializable]
    public abstract class BaseModel
    {
        [SerializeField] protected string _name;

        public UnityEvent OnValueChange = new UnityEvent();

        public bool SetData<T>(ref T  field, T value)
        {
            if(EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }
            field = value;
            OnValueChange.Invoke();
            return true;
        }
    }
}
