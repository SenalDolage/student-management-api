namespace StudentManagementAPI.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class TableAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MBTableAttribute"/> class.
        /// </summary>
        /// <param name="tableName">Table name.</param>
        public TableAttribute(string tableName)
        {
            this.Name = tableName;
        }

        /// <summary>
        /// Gets the table name.
        /// </summary>
        public string Name { get; }
    }
}