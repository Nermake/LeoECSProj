using UnityEngine;

namespace Follow
{
    public class FollowFixedUpdate : Follower
    {
        private void FixedUpdate() => Follow(Time.fixedDeltaTime);
    }
}