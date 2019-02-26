namespace Arch.Domain.Core.Events {
    public interface IEventStore {
        void Save<T>(T aEvent) where T : AbstractEvent;
    }
}