using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using StudentManagementAPI.Enums;

namespace StudentManagementAPI.Models
{
    public class Student : Entity
    {
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("graduated")]
        public bool IsGraduated { get; set; }

        [BsonElement("courses")]
        public string[]? Courses { get; set; }

        [BsonElement("gender")]
        public Gender Gender { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }
    }
}
