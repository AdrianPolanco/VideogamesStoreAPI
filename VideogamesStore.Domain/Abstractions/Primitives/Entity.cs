using VideogamesStore.Domain.Shared.Utils;

namespace VideogamesStore.Domain.Abstractions.Primitives
{
    public abstract class Entity : IEquatable<Entity>
    {

        protected Entity(Guid Id)
        {
            Check.GuidIsNotEmpty(Id, "The id must not be empty.", nameof(Id));
            this.Id = Id;
        }

        public Guid Id { get; private set; }

        public static bool operator ==(Entity first, Entity second)
        {
            if (first is null && second is null) return true;

            if (first is null || second is null) return false;

            return first.Equals(second);
        }

        public static bool operator !=(Entity first, Entity second)
        {
            return !(first == second);
        }

        /// <summary>
        /// Comparing the reference and the id of both entities, returns true if at least one comparison returns true
        /// </summary>
        /// <param name="other">Another entity</param>
        /// <returns>bool</returns>
        public bool Equals(Entity? other)
        {
            if (other is null) return false;

            return ReferenceEquals(this, other) || Id == other.Id;
        }

        /// <summary>
        /// Returns if a given object is equal to the current entity
        /// </summary>
        /// <param name="obj">The object to be compared</param>
        /// <returns>bool</returns>
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;

            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != GetType()) return false;

            if (!(obj is Entity other)) return false;

            if (Id == Guid.Empty || other.Id == Guid.Empty) return false;

            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() * 41;
        }
    }
}
