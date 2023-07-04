using System.Collections.Generic;
using UnityEngine;

namespace Sources.System
{
    public class Updater : MonoBehaviour
    {
       private List<IUpdate> _updates = new List<IUpdate>();

       public void AddUpdate(IUpdate update)
       {
           _updates.Add(update);
       }
       private void Update()
       {
           for (int i = 0, len = _updates.Count; i < len; ++i)
           {
               _updates[i].Update();
           }
       }
    }

    public interface IUpdate
    {
        public void Update();
    }
}
