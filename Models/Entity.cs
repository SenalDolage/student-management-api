using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudentManagementAPI.Models
{
    public class Entity
    {
        /// <summary>
        /// Gets or sets the document id.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Gets the created date of the document.
        /// </summary>
        [BsonElement("createdDate")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets the changed date of the document.
        /// </summary>
        [BsonElement("changedDate")]
        public DateTime? ChangedDate { get; set; }
    }
}