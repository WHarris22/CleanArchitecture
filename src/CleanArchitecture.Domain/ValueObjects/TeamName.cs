#nullable enable

using System;

namespace CleanArchitecture.Domain.ValueObjects
{
    public class TeamName : IEquatable<TeamName>
    {
        public string Value { get; }

        private TeamName(string value)
        {
            Value = value;
        }

        public static TeamName Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Team name cannot be null or empty", nameof(value));
            if (value.Length > 100)
                throw new ArgumentException("Team name cannot be longer than 100 characters", nameof(value));

            return new TeamName(value);
        }

        public override bool Equals(object? obj) => obj is TeamName name && Value == name.Value;

        public bool Equals(TeamName? other) => other is not null && Value == other.Value;

        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==(TeamName left, TeamName right) => left.Equals(right);

        public static bool operator !=(TeamName left, TeamName right) => !left.Equals(right);

        public override string ToString() => Value;
    }
}