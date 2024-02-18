using SQLite;

public class DatabaseHelper
{
    readonly SQLiteConnection database;

    public DatabaseHelper(string dbPath)
    {
        database = new SQLiteConnection(dbPath);
        database.CreateTable<User>();
    }

    public int AddUser(User user)
    {
        return database.Insert(user);
    }

    public User GetUserByUsernameAndPassword(string username, string password)
    {
        return database.Table<User>().FirstOrDefault(u => u.Username == username && u.Password == password);
    }
}
