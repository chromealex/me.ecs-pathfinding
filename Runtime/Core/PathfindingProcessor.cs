
#if FIXED_POINT_MATH
using ME.ECS.Mathematics;
using tfloat = sfloat;
#else
using Unity.Mathematics;
using tfloat = System.Single;
#endif

namespace ME.ECS.Pathfinding {
    
    using UnityEngine;
    using ME.ECS.Collections;

    public interface IPathfindingProcessor {

        Path Run<TMod>(LogLevel pathfindingLogLevel, float3 from, float3 to, Constraint constraint, Graph graph, TMod pathModifier, int threadIndex = 0, bool burstEnabled = true, bool cacheEnabled = false) where TMod : struct, IPathModifier;

    }
    
}
