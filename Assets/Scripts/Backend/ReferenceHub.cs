using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ReferenceHub : NetworkBehaviour
{
    private static readonly Dictionary<GameObject, ReferenceHub> Hubs = new Dictionary<GameObject, ReferenceHub>(20, new GameObjectComparer());

    public LocalPlayerSetup localPlayerSetup;

    private void Awake()
    {
        Hubs[gameObject] = this;
    }

    private void OnDestroy()
    {
        Hubs.Remove(gameObject);
    }

    public static ReferenceHub getHub(GameObject player)
    {
        return Hubs.TryGetValue(player, out ReferenceHub hub) ? hub : player.GetComponent<ReferenceHub>();
    }

    public static Dictionary<GameObject, ReferenceHub> getAllHubs()
    {
        return Hubs;
    }

    #region GameObjectComparer
    private class GameObjectComparer : EqualityComparer<GameObject>
    {
        public override bool Equals(GameObject x, GameObject y)
        {
            return x == y;
        }

        public override int GetHashCode(GameObject obj)
        {
            return obj.GetHashCode();
        }
    }
    #endregion
}
