using UnityEngine;
using Unity.Behavior;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Simple Behaviourized Manner", menuName = "Simple Behaviourized Manner")]
public class PE_SimpleBehaviourizedManner : PE_SpawningManner {
    [SerializeField] protected BehaviorGraph _graph;

    public override IDamageable Spawn(Vector3 position) {
        var spawned = Instantiate((MonoBehaviour) _prefab, position, Quaternion.identity);
        var agent = spawned.AddComponent<BehaviorGraphAgent>();
        agent.Graph = _graph;
        agent.SetVariableValue("Self", spawned.gameObject);

        return (IDamageable) spawned;
    }

    public override IDamageable Spawn(Vector3 position, IDamageable target) => Spawn(position);
}
