namespace VideogamesStore.Domain.Abstractions.Primitives
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {

        public static bool operator ==(ValueObject a, ValueObject b)
        {
            if (a is null && b is null) return true;

            if (a is null || b is null) return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject a, ValueObject b)
        {
            return !(a == b);
        }
        /// <summary>
        /// Checks if two value objects are equal comparing their values rather than their Id
        /// </summary>
        /// <param name="other">Another value object</param>
        /// <returns>bool</returns>
        public bool Equals(ValueObject? other)
        {
            if (other is null) return false;

            if (GetType() != other.GetType()) return false;

            if (!(other is ValueObject valueObject)) return false;

            return GetAtomicValues().SequenceEqual(valueObject.GetAtomicValues());
        }

        /// <summary>
        /// Overrides the GetHashCode method so it generates a hash code based on all the values inside of the properties of the value object
        /// </summary>
        /// <returns>A hash code as int</returns>
        public override int GetHashCode()
        {
            HashCode hashCode = default;

            foreach (object obj in GetAtomicValues()) hashCode.Add(obj);

            return hashCode.ToHashCode();
        }
        public abstract IEnumerable<object> GetAtomicValues();
    }
}
