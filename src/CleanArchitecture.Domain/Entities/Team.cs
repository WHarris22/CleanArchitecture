#nullable enable

using System;
using CleanArchitecture.Utilities.Results;

namespace CleanArchitecture.Domain.Entities
{
    public class Team
    {
        public int ID { get; private set; }

        public string Name { get; private set; }

        public string NickName { get; private set; }

        private Team() { } // For EF or serialization

        public Team(int id, string name, string nickName)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty", nameof(name));
            if (string.IsNullOrWhiteSpace(nickName))
                throw new ArgumentException("NickName cannot be null or empty", nameof(nickName));

            ID = id;
            Name = name;
            NickName = nickName;
        }

        public Result UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                return Result.Invalid("Name cannot be null or empty");

            Name = newName;
            return Result.Success();
        }

        public Result UpdateNickName(string newNickName)
        {
            if (string.IsNullOrWhiteSpace(newNickName))
                return Result.Invalid("NickName cannot be null or empty");

            NickName = newNickName;
            return Result.Success();
        }
    }
}