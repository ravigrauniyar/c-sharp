using System;
using System.Collections.Generic;

namespace Internship
{
    public interface DatabaseActions<T>
    {
        void AddData(T entry);
        void UpdateData(T oldEntry, T updatedEntry);
        void DeleteData(T entry);
    }
    public class Database<T> : DatabaseActions<T>
    {
        private LinkedList<T> database = new LinkedList<T>();
        public LinkedList<T> GetDatabase()
        {
            return database;
        }
        public void AddData(T entry)
        {
            database.AddLast(entry);
        }
        public void UpdateData(T oldEntry, T updatedEntry)
        {
            LinkedListNode<T> oldNode = database.Find(oldEntry);
            database.AddAfter(oldNode, updatedEntry);
            database.Remove(oldNode);
        }
        public void DeleteData(T entry)
        {
            database.Remove(entry);
        }
    }
    class User
    {
        private int id;
        private string username;
        private int age;
        private string address;

        public User(int id, string username, int age, string address)
        {
            this.id = id;
            this.username = username;
            this.age = age;
            this.address = address;
        }
        public void showData()
        {
            Console.WriteLine("\nID: " + id + "\nUsername: " + username + "\nAge: " + age + "\nAddress: " + address + "\n");
        }
    }
    class Generics
    {
        public void showDatabase(Database<User> userDb)
        {
            var users = userDb.GetDatabase();
            foreach (var user in users)
            {
                user.showData();
            }
        }
        public void genericsDemo()
        {
            Database<User> userDb = new Database<User>();

            User ravi = new User(1, "Ravi", 21, "Hetauda-10");
            User abhisekh = new User(2, "Abhisekh", 22, "Hetauda-5");
            User sujar = new User(3, "Sujar", 22, "Hetauda");

            userDb.AddData(ravi);
            userDb.AddData(abhisekh);
            userDb.AddData(sujar);

            Console.WriteLine("\nInitial Database:\n");
            showDatabase(userDb);

            Console.WriteLine("\nDatabase after deleting user 'Abhisekh':\n");
            userDb.DeleteData(abhisekh);
            showDatabase(userDb);

            User manish = new User(3, "Manish", 22, "Basamadi");
            Console.WriteLine("\nDatabase after updating user with ID = 3:\n");
            userDb.UpdateData(sujar, manish);
            showDatabase(userDb);
        }
    }
}