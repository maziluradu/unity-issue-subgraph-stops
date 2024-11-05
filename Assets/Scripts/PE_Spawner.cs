using UnityEngine;

public class PE_Spawner : MonoBehaviour {
    [SerializeField] protected PE_SpawningManner _manner;

    public void Trigger() {
        _manner.Spawn(transform.position);
    }
}
