namespace StudentManagementAPI.Interfaces
{
    public interface IDatabaseSettings
    {
        public string CoursesCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
