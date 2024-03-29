﻿using ME.ECS;
#if FIXED_POINT_MATH
using ME.ECS.Mathematics;
using tfloat = sfloat;
#else
using Unity.Mathematics;
using tfloat = System.Single;
#endif

namespace ME.ECS.Pathfinding.Features.PathfindingAstar.Components {

    public struct Path : IComponent, IComponentRuntime, IComponentDisposable<Path> {

        public byte resultValue;
        public ME.ECS.Pathfinding.PathCompleteState result {
            get => (ME.ECS.Pathfinding.PathCompleteState)this.resultValue;
            set => this.resultValue = (byte)value;
        }
        public ME.ECS.Collections.LowLevel.MemArrayAllocator<float3> path;
        public ME.ECS.Collections.LowLevel.MemArrayAllocator<int> nodes;

        public void OnDispose(ref ME.ECS.Collections.LowLevel.Unsafe.MemoryAllocator allocator) {
            if (this.path.isCreated == false) this.path.Dispose(ref allocator);
            if (this.nodes.isCreated == false) this.nodes.Dispose(ref allocator);
        }

        public void ReplaceWith(ref ME.ECS.Collections.LowLevel.Unsafe.MemoryAllocator allocator, in Path other) {
            this.path.ReplaceWith(ref allocator, other.path);
            this.nodes.ReplaceWith(ref allocator, other.nodes);
        }
        
        public void CopyFrom(ref ME.ECS.Collections.LowLevel.Unsafe.MemoryAllocator allocator, in Path other) {
            this.path.CopyFrom(ref allocator, other.path);
            this.nodes.CopyFrom(ref allocator, other.nodes);
        }

    }

}