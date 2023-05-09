using ME.ECS;
#if FIXED_POINT_MATH
using ME.ECS.Mathematics;
using tfloat = sfloat;
#else
using Unity.Mathematics;
using tfloat = System.Single;
#endif

namespace ME.ECS.Pathfinding.Features.PathfindingFlowField.Components {

    public struct PathFlowField : IComponent, IComponentRuntime {

        public ME.ECS.Collections.LowLevel.MemArrayAllocator<byte> flowField;
        public float3 from;
        public float3 to;
        public bool cacheEnabled;

    }
    
}