using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Trigger Spawn List", story: "Trigger [SpawnerList]", category: "Action", id: "6ce27c7eca1778a9b564141989d9811c")]
public partial class TriggerSpawnListAction : Action
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> SpawnerList;

    protected override Status OnStart() {
        foreach (var spawnerGO in SpawnerList.Value) {
            // TODO: Remove this TryGetComponent once we find out how we can have custom property types
            if (spawnerGO.TryGetComponent<PE_Spawner>(out var spawner)) {
                spawner.Trigger();
            } else {
                Debug.LogWarning($"A TriggerSpawnersAction's SpawnerList contained a gameObject {spawnerGO} which did not have a PE_Spawner placed on it. This spawner will be ignored.");
            }
        }

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

