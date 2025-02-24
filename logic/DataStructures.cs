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
}