using UnityEngine;

namespace Follow
{
    public class FollowUpdate : Follower
    {
        private void Update() => Follow(Time.deltaTime);
    }
}