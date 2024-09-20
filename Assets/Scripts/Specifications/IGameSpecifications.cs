using Level.Specification;
using Specification.Scene;
using Specifications.Collection;

namespace Specifications
{
    public interface IGameSpecifications
    {
        ISpecificationsCollection<SceneSpecification> SceneSpecifications { get; }
        ISpecificationsCollection<LevelSpecification> LevelSpecifications { get; }
    }
}