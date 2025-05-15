using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyStateDemo
{
    void UpdateState();
    void OnTriggerEnter(Collider col);
    void OnTriggerStay(Collider col);
    void OnTriggerExit(Collider col);
}

