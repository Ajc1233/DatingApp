namespace API.Entities
{
    //This is the base of the table. When queried, it will take the Id and UserName and set them to a SQL table
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }


    }
}