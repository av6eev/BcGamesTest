using Reactive.Field;
using Utilities.Model;

namespace Level
{
    public class LevelModel : IModel
    {
        public readonly ReactiveField<int> Index = new();
    }
}