using CyberCAT.Core.Classes.Mapping;
using CyberCAT.Core.Classes.NodeRepresentations;

namespace CyberCAT.Core.Classes.DumpedClasses
{
    [RealName("physicsSimulationFilter")]
    public class PhysicsSimulationFilter : GenericUnknownStruct.BaseClassEntry
    {
        [RealName("mask1")]
        public ulong Mask1 { get; set; }
        
        [RealName("mask2")]
        public ulong Mask2 { get; set; }
    }
}
