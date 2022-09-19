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
        public string Id { get; protected set; }

        /// <summary>
        /// Gets the created date of the document.
        /// </summary>
        public DateTime? CreatedDate { get; internal set; }

        /// <summary>
        /// Gets the changed date of the document.
        /// </summary>
        public DateTime? ChangedDate { get; internal set; }
    }
}