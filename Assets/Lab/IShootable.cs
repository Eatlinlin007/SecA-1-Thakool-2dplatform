using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootable 
{
      GameObject Bullet { get; set; }
      Transform SpawnPoint { get; set; }

      float WaitTime { get; set; }
      float ReloadTimer { get; set; }

    void Shoot();
}
