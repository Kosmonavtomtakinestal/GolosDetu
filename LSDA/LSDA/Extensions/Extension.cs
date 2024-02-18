using System.Collections.ObjectModel;

namespace LSDA.Extensions
{
    static class Extensions
    {
        public static ObservableCollection<T> TakeToObservable<T>(this IEnumerable<T> enumerable)
            => new(enumerable);
    }
}
