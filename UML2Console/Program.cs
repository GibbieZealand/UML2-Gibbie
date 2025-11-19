
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using PizzaLibrary.Services;
using PizzaLibrary.Data;

//Listing each value with an abbreviation follow by a 3-digit code...
// Example: (MenuItem 1 = mI001, MenuItemRepo 1 = mIR001)

//TODO: Test your code here:
ICustomerRepository cR001 = new CustomerRepo();
IMenuItemRepository mIR001 = new MenuItemRepo();

cR001.PrintAllCustomers();
mIR001.PrintAllMenuItems();

Customer c001 = new Customer("June", "16161616", "12 Cruise Avenue");
MenuItem mI001 = new MenuItem("Romana", 98, "Tomat, ost, Pepperoni, Bacon, Gorgonzola", MenuType.PIZZECLASSSICHE);

cR001.AddCustomer(c001);
mIR001.AddMenuItem(mI001);

cR001.PrintAllCustomers();
mIR001.PrintAllMenuItems();

cR001.RemoveCustomer("12121212");
mIR001.RemoveMenuItem(1);

cR001.GetAll();
mIR001.GetAll();

cR001.SearchByCity("Roskilde");
mIR001.GetMenuItemTypeByHighest(MenuType.PIZZECLASSSICHE);
mIR001.GetPizzaByHighest();

