namespace PhoneBook.EndPoints.Models.AAA
{
    public class CreateRoleViewModel
    {
        public string Name { get; set; }
    }
    public class UpdateRoleViewModel: CreateRoleViewModel
    {
        public int Id { get; set; }
    }
}
