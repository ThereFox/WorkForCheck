using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ItemsSorting
{
    [Serializable]
    public class PlayerData : BaseModel
    {
        [SerializeField] protected string _playerName;
        [SerializeField] protected int _score;

        public string PlayerName {
            get { return _playerName; }
            set {
                SetData(ref _playerName, value);
            }
        }

        public int Score
        {
            get { return _score; }
            set {
                if (value >= 0)
                {
                    SetData(ref _score, value);
                }
                else SetData(ref _score, 0); ;
                
            }
        }
    }
}
