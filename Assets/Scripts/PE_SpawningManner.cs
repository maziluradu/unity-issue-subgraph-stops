using UnityEngine;
using UnityEditor;

public abstract class PE_SpawningManner : ScriptableObject {
    [SerializeField] private MonoBehaviour _damageableRef;
    protected IDamageable _prefab
        => _damageableRef is IDamageable damageable ? damageable : null;

    public abstract IDamageable Spawn(Vector3 position);
    public abstract IDamageable Spawn(Vector3 position, IDamageable target);

    protected virtual void OnValidate() {
        if (_damageableRef != null) {
            if (PrefabUtility.GetPrefabAssetType(_damageableRef.gameObject) == PrefabAssetType.NotAPrefab) {
                _damageableRef = null;
                return;
            }

            if (_damageableRef is not IDamageable) {
                if (_damageableRef.TryGetComponent(out IDamageable damageable)) {
                    _damageableRef = (MonoBehaviour) damageable;
                    return;
                }

                _damageableRef = null;
                return;
            }
        }
    }
}