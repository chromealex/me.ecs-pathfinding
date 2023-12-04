using ME.ECS;
#if FIXED_POINT_MATH
using ME.ECS.Mathematics;
using tfloat = sfloat;
#else
using Unity.Mathematics;
using tfloat = System.Single;
#endif

namespace ME.ECS.Pathfinding.Features.PathfindingNavMesh.Components {

    public struct PathNavMesh : IComponent, IComponentRuntime, IComponentDisposable<PathNavMesh> {

        public byte resultValue;
        public ME.ECS.Pathfinding.PathCompleteState result {
            get => (ME.ECS.Pathfinding.PathCompleteState)this.resultValue;
            set => this.resultValue = (byte)value;
        }
        public ME.ECS.Collections.LowLevel.List<float3> path;

        public void OnDispose(ref ME.ECS.Collections.LowLevel.Unsafe.MemoryAllocator allocator) {
            if (this.path.isCreated == true) this.path.Dispose(ref allocator);
        }

        public void ReplaceWith(ref ME.ECS.Collections.LowLevel.Unsafe.MemoryAllocator allocator, in PathNavMesh other) {
            this.resultValue = other.resultValue;
            this.path.ReplaceWith(ref allocator, in other.path);
        }
        
        public void CopyFrom(ref ME.ECS.Collections.LowLevel.Unsafe.MemoryAllocator allocator, in PathNavMesh other) {
            this.resultValue = other.resultValue;
            this.path.CopyFrom(ref allocator, in other.path);
        }

    }

}