using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeCoffee.Components.Data
{
    public class DatabaseContext
    {
        private static DatabaseContext instance;
        // Change this path according to your own system
        private string rootFolder = "D:\\Application Development CW\\21049948 Tekraj Dhimal\\Bislerium Cafe\\Resources\\Raw";
        private string usersFile = "users.csv"; // Users Database
        private string coffeeFile = "coffee.csv"; // Coffee Database
        private string addonsFile = "addons.csv"; // Addons Database
        private string ordersFile = "orders.csv"; // Orders Database
        private string membersFile = "members.csv"; // Members Database

        private int currentUser; // Current Logged in user type

        private List<User> users; // all users list (Admin and Staff)
        private List<Item> coffees; // Coffee list
        private List<Item> addons; // Addons List
        private List<Order> orders; // Orders List
        private List<Member> members; // Members List

        private DatabaseContext()
        {
            currentUser = -1;
            loadUsers(); // Load Users from Database
            loadCoffee(); // Load Coffee from Database
            loadAddons(); // Load Addons from Database
            loadOrders(); // Load Orders from Database
            loadMembers(); // Load Members from Database
        }

        public static DatabaseContext getInstance()
        {
            if (instance == null)
                instance = new DatabaseContext();
            return instance;
        }

        public void loadUsers()
        {
            users = new List<User>();
            string fulluserpath = Path.Combine(rootFolder, usersFile);
            if (File.Exists(fulluserpath))
            {
                using (TextFieldParser parser = new TextFieldParser(fulluserpath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields() ?? new string[1];
                        if (fields.Length == 3)
                            users.Add(new User(int.Parse(fields[0]), fields[1], fields[2]));
                    }
                }

            }
            else
            {
                string data = "0, admin, adminpass\r\n1, staff, staffpass"; // Default Users info
                File.WriteAllText(fulluserpath, data);
                loadUsers();
            }
        }

        public void loadCoffee()
        {
            coffees = new List<Item>();
            string fulluserpath = Path.Combine(rootFolder, coffeeFile);
            if (File.Exists(fulluserpath))
            {
                using (TextFieldParser parser = new TextFieldParser(fulluserpath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields() ?? new string[1];
                        if (fields.Length == 3)
                            coffees.Add(new Item(int.Parse(fields[0]), fields[1], float.Parse(fields[2])));
                    }
                }

            }
            else
            {
                // Default Coffee
                string data = "1, Espresso, 2.50\r\n2, Americano, 3.00\r\n3, Latte, 4.00\r\n4, Cappuccino, 4.50\r\n5, Mocha, 5.00\r\n6, Flat White, 4.50\r\n7, Cold Brew, 3.50\r\n8, Iced Latte, 4.50\r\n9, Macchiato, 3.00\r\n10, Affogato, 5.50\r\n";
                File.WriteAllText(fulluserpath, data);
                loadCoffee();
            }
        }

        public void loadAddons()
        {
            addons = new List<Item>();
            string fulluserpath = Path.Combine(rootFolder, addonsFile);
            if (File.Exists(fulluserpath))
            {
                using (TextFieldParser parser = new TextFieldParser(fulluserpath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields() ?? new string[1];
                        if (fields.Length == 3)
                            addons.Add(new Item(int.Parse(fields[0]), fields[1], float.Parse(fields[2])));
                    }
                }

            }
            else
            {
                // Default Addons
                string data = "1, Vanilla Syrup, 0.50\r\n2, Caramel Drizzle, 0.75\r\n3, Hazelnut Creamer, 0.60\r\n4, Chocolate Powder, 0.50\r\n5, Whipped Cream, 0.80\r\n6, Mint Extract, 0.70\r\n7, Almond Milk, 0.75\r\n8, Pumpkin Spice, 0.60\r\n9, Irish Cream, 0.80\r\n10, Coconut Flakes, 0.65\r\n11, Honey, 0.50\r\n12, Cardamom Sprinkle, 0.60\r\n13, Maple Syrup, 0.75\r\n14, Ginger Syrup, 0.70\r\n15, Lavender Infusion, 0.80\r\n16, Chai Spice Blend, 0.60\r\n17, Whiskey Shot, 1.50\r\n18, Orange Zest, 0.50\r\n19, Cinnamon Stick, 0.50\r\n20, Nutmeg Grating, 0.55\r\n";
                File.WriteAllText(fulluserpath, data);
                loadAddons();
            }
        }

        public void loadOrders()
        {
            // Load Orders data from File
            orders = new List<Order>();
            string fulluserpath = Path.Combine(rootFolder, ordersFile);
            if (File.Exists(fulluserpath))
            {
                using (TextFieldParser parser = new TextFieldParser(fulluserpath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields() ?? new string[1];
                        if (fields.Length == 8)
                            orders.Add(new Order(int.Parse(fields[0]), fields[1], fields[2], fields[3], DateTime.Parse(fields[4]), float.Parse(fields[5]), float.Parse(fields[6]), float.Parse(fields[7])));
                    }
                }

            }
        }

        public void loadMembers()
        {
            members = new List<Member>();
            string fullmemberpath = Path.Combine(rootFolder, membersFile);
            if (File.Exists(fullmemberpath))
            {
                using (TextFieldParser parser = new TextFieldParser(fullmemberpath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields() ?? new string[1];
                        if (fields.Length == 2)
                            members.Add(new Member(int.Parse(fields[0]), fields[1]));
                    }
                }

            }
        }

        public void addMember(Member member)
        {
            members.Add(member); // Add a new member to the list
            saveMembers(); // Write the updated members to the File
        }

        public void addOrder(Order order)
        {
            orders.Add(order); // Add a new Order to the list
            saveOrders(); // Write the updated orders to the File
        }
        public void addAddon(Item addn)
        {
            addons.Add(addn); // Add a new addon to the list
            saveAddons(); // Write the updated addons to the File
        }

        public void saveOrders()
        {
            string fullorderspath = Path.Combine(rootFolder, ordersFile);
            if (orders != null && orders.Count > 0)
            {
                string data = "";
                foreach (var order in orders)
                {
                    data += order.Id + ", ";
                    data += order.CustomerName + ", ";
                    data += order.PhoneNumber + ", ";
                    data += order.OrderItem + ", ";
                    data += order.Date.ToString("yyyy-MM-dd") + ", ";
                    data += order.TotalBill + ", ";
                    data += order.Discount + ", ";
                    data += order.TotalPaid + "\r\n";
                }
                File.WriteAllText(fullorderspath, data);
            }
        }

        public void saveMembers()
        {
            string fullmemberpath = Path.Combine(rootFolder, membersFile);
            if (members != null && members.Count > 0)
            {
                string data = "";
                foreach (var mem in members)
                {
                    data += mem.Id + ", ";
                    data += mem.PhoneNumber + "\r\n";
                }
                File.WriteAllText(fullmemberpath, data);
            }
        }

        public void saveAddons()
        {
            string fulladdonspath = Path.Combine(rootFolder, addonsFile);
            if (addons != null && addons.Count > 0)
            {
                string data = "";
                foreach (var itm in addons)
                {
                    data += itm.Id + ", ";
                    data += itm.ItemName + ", ";
                    data += itm.ItemPrice + "\r\n";
                }
                File.WriteAllText(fulladdonspath, data);
            }
        }

        // Delete an addon from list
        public bool deleteAddon(int id)
        {
            for (int i = 0; i < addons.Count; i++)
            {
                if (addons[i].Id == id)
                {
                    addons.RemoveAt(i);
                    saveAddons();
                    return true;
                }
            }
            return false;
        }

        public List<User> GetUsers() { return users; }

        public List<Item> GetCoffee() { return coffees; }

        public List<Item> GetAddons() { return addons; }

        public List<Order> GetOrders() { return orders; }

        public List<Member> GetMembers() { return members; }


        // Search for a Coffee
        public Item GetCoffee(int id)
        {
            foreach (Item item in coffees)
            {
                if (item.Id == id) return item;
            }
            return null;
        }

        // Search for an addon
        public Item GetAddon(int id)
        {
            foreach (Item item in addons)
            {
                if (item.Id == id) return item;
            }
            return null;
        }

        public void SetCurrentUser(int user)
        {
            currentUser = user;
        }

        public int GetCurrentUser()
        {
            return currentUser;
        }

        // Update user info
        public void UpdateUsers(string aname, string apass, string sname, string spass)
        {
            users[0].UserName = aname;
            users[0].UserPassword = apass;
            users[1].UserName = sname;
            users[1].UserPassword = spass;
            string fulluserspath = Path.Combine(rootFolder, usersFile);
            if (users != null && users.Count > 0)
            {
                string data = "";
                foreach (var usr in users)
                {
                    data += usr.UserType + ", ";
                    data += usr.UserName + ", ";
                    data += usr.UserPassword + "\r\n";
                }
                File.WriteAllText(fulluserspath, data);
            }
        }

    }
}
