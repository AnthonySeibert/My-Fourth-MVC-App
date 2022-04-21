using System;
using System.Collections.Generic;
class Program {
  public static void Main (string[] args) {
    string choice = "";
    while (choice != "q"){
      Console.WriteLine("Enter 1 to PRINT the menu");
      Console.WriteLine("Enter 2 to ADD an item to the menu");
      Console.WriteLine("Enter 3 to REMOVE an item from the menu");
      Console.WriteLine("Enter q to QUIT: ");
      choice = Console.ReadLine();

      if (choice == "1"){
        Menu.PrintMenu();
      }
      if (choice == "2"){
        Menu.AddMenuItem();
      }
      if(choice == "3"){
        Menu.RemoveMenuItem();
      }
    }
  }
}

class MenuItem {
  public string Name {get; set;}
  public string Description {get; set;}
  public string Category {get; set;}
  public double Price {get; set;}
  public DateTime DateAdded {get; set;}

  public MenuItem(string name, string description, string category, double price){
    Name = name;
		Description = description;
	  Category = category;
    Price = price;
	  DateAdded = DateTime.Now;
  }

}
class Menu{
  public static List<MenuItem> Items = new List<MenuItem>();
  public static List<string> Categories = new List<string>(){"Appetizer", "Main Course", "Dessert"};

  public static void AddMenuItem(){
    Console.WriteLine("Enter Name: ");
    string name = Console.ReadLine();
    Console.WriteLine("Enter Description: ");
    string description = Console.ReadLine();
    Console.WriteLine("Enter Price: ");
    double price = Convert.ToDouble(Console.ReadLine());

    bool validation = false;
    string category = "";

    while(validation == false){
    Console.WriteLine("Enter Category(Appetizer, Main Course, or Dessert):");
    category = Console.ReadLine();
      foreach(string categories in Categories){
        if(category == categories){
          validation = true;
          break;
        }
      }
    }

    Items.Add(new MenuItem(name, description, category, price));
    
  }
  public static void RemoveMenuItem(){
    Console.WriteLine("Enter Item to be Deleted: ");
    string item = Console.ReadLine();
    var remove = Items.Find(num => num.Name == item);
    Items.Remove(remove);
  }
    public static void PrintMenu()
        {
          Console.WriteLine("Menu");
          Console.WriteLine();
            
            foreach(string category in Categories)
            {
              Console.WriteLine(category);
              Console.WriteLine("");
              Console.WriteLine("");
              foreach(MenuItem item in Items){
                if(item.Category == category){
                  Console.WriteLine("Name: " + item.Name);
                  Console.WriteLine("Description: " + item.Description);
                  Console.WriteLine("Added: " + item.DateAdded);
                  Console.WriteLine("Price: $" + item.Price);
                  Console.WriteLine();
                }
              }
              Console.WriteLine();
              Console.WriteLine();
            }
        }
  
}
