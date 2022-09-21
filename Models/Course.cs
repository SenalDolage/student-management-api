using MongoDB.Bson.Serialization.Attributes;

namespace StudentManagementAPI.Models
{
    public class Course : Entity
    {
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("masterInCharge")]
        public string MasterInCharge { get; set; } = string.Empty;
    }
}
