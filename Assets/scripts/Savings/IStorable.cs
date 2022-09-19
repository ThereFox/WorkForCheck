using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

namespace ItemsSorting
{
    public interface IStorable
    {
        public Task<bool> Load();
        public Task<bool> Save();
    }
}
