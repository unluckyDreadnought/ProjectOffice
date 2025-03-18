namespace ProjectOffice.logic
{
    public static class Symbols
    {
        public static string ru_alp { get { return "абвгдеёжзийклмнопрстуфхцчшщъыьэюя"; } }
        public static string en_alp { get { return "abcdefghijklmnopqrstuvwxyz"; } }
        public static string spec { get { return "!_+=~$#%^:&?*(){}[]-<>"; } }
    }

    public enum ChooseMode
    {
        Client = 0,
        Employee = 1,
        Stages = 2
    }

    public enum UserRole
    {
        Admin = 1,
        Manager = 2,
        Employee = 3
    }

    public enum Dictionaries
    {
        Specializations = 0,
        Status = 1,
        Stages = 2,
        OrganizationTypes = 3,
        Subtasks = 4
    }

    public enum Connection
    {
        OK = 0,
        HostUnreachable = 1,
        UserError = 2,
        DatabaseNotExist = 3
    }

    public enum Status
    {
        New = 1,
        Work = 2,
        Agreement = 3,
        PreparingToEnd = 4,
        Finish = 5,
        Rejected = 6
    }

    public enum ProjectField
    {
        Id = 0,
        Status = 1,
        CLient = 2,
        Creator = 3, 
        Title = 4,
        StartDate = 5,
        PlanEnd = 6,
        FactEnd = 7,
        Coefficient = 8,
        Cost = 9
    }
}