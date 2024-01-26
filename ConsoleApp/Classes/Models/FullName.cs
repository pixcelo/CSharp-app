namespace ConsoleApp.Classes.Models
{
    /// <summary>
    /// C#の典型的な比較の実装方法
    /// 値オブジェクト同士を比較する際には値オブジェクトの属性を取り出して比較するのではなく、
    /// Equalsメソッドを利用して比較する（これにより値オブジェクトは、値と同じように比較できる）
    /// </summary>
    class FullName : IEquatable<FullName>
    {
        public FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }

        public bool Equals(FullName? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(FirstName, other.FirstName)
                   && string.Equals(LastName, other.LastName);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FullName)obj);
        }

        // C#ではEqualsをoverrideする際にGetHashCodeをoverrideするルールがある
        public override int GetHashCode()
        {
            unchecked
            {
                return ((FirstName != null ? FirstName.GetHashCode() : 0) * 397)
                       ^ (LastName != null ? LastName.GetHashCode() : 0);
            }
        }
    }
}
