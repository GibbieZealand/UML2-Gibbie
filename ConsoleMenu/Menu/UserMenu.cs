using ConsoleMenu.Controllers.Customers;
using ConsoleMenu.Menu.MenuItems;
using PizzaLibrary.Exceptions;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using PizzaLibrary.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Menu
{
    public class UserMenu
    {
        private static string mainMenuChoices = "\t----------------" +
            "\n\t1.Vis Pizzamenu" +
            "\n\t2.Vis Kunder" +
            "\n\t3.Add Customer" +
            "\n\t4.Add Menu Item" +
            "\n\tQ.Afslut" +
            "\n\n\tIndtast valg:";

        private ICustomerRepository _customerRepository = new CustomerRepo();
        private IMenuItemRepository menuItemRepository = new MenuItemRepo();
        private MenuItemRepo _menuItemRepository = new MenuItemRepo();

        private static string ReadChoice(string choices)
        {
            Console.Clear();
            Console.Write(choices);
            string choice = Console.ReadLine();
            Console.Clear();
            return choice.ToLower();
        }
        public void ShowMenu()
        {
            string theChoice = ReadChoice(mainMenuChoices);
            while (theChoice != "q")
            {
                switch (theChoice)
                {
                    case "1":
                        Console.WriteLine("Valg 1");
                        ShowMenuItemController showMenuItemController = new ShowMenuItemController(_menuItemRepository);
                        showMenuItemController.ShowAllMenuItems();
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Valg 2");
                        _customerRepository.PrintAllCustomers();
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Valg 3");
                        Console.WriteLine("Indlæs navn:");
                        string name = Console.ReadLine();
                        //try
                        //{
                        Console.WriteLine("Indlæs mobil nr:");
                        string mobile = Console.ReadLine();
                        //CheckExistingMobile(_customerRepository.Mobile);
                        //}
                        //catch (CustomerMobileExists cMex)
                        //{
                        //    Console.WriteLine(cMex.Message);
                        //}
                        Console.WriteLine("Indlæs adresse:");
                        string address = Console.ReadLine();
                        Console.WriteLine("Vil du være clubmember y/n");
                        string clubMemberString = Console.ReadLine().ToLower();
                        bool isClubMember = (clubMemberString[0] == 'y') ? true : false;
                        Console.WriteLine("Vil du være VIP? y/n");
                        string vipCustomerString = Console.ReadLine().ToLower();
                        bool isVIPCustomer = (vipCustomerString[0] == 'y') ? true : false;
                        int discount = 0;
                        if (isVIPCustomer == true)
                        {
                            try
                            {
                                Console.WriteLine("VIP Discount? (0-25(%)");
                                discount = Convert.ToInt32(Console.ReadLine());
                                CheckLowDiscount(discount);
                                CheckHighDiscount(discount);
                                
                            }
                            catch (TooHighDiscountException iHDex)
                            {
                                discount = 25;
                                Console.WriteLine($"{iHDex.Message} press any button to continue");
                                Console.ReadLine();
                            }
                            catch (TooLowDiscountException iLDex)
                            {
                                discount = 0;
                                Console.WriteLine($"{iLDex.Message} press any button to continue");
                                Console.ReadLine();
                            }
                            catch (ArgumentException aex)
                            {
                                Console.WriteLine(aex.Message);
                                Console.ReadLine();
                            }
                            //For some reason, calling this method adds 2 indexes to the list, but only registers one object. Unsure how to fix.
                                //But it does work. So I'm leaving it there, I got more important things to do.
                                    //I guess I'm somewhat in awe that I now can make code that works with bugs?? idk???
                            AddCustomerController addVIPCustomerController = new AddVIPCustomerController(name, mobile, address, isClubMember, discount, _customerRepository);
                            addVIPCustomerController.AddCustomer();
                            break;
                        }
                        //Pre-exception method:
                        //    Console.WriteLine("VIP Discount? (0-25(%)");
                        //    discount = Convert.ToInt32(Console.ReadLine());
                        //    if (discount > 25)
                        //    {
                        //        discount = 25;
                        //    }
                        //    else if (discount < 0)
                        //    {
                        //        discount = 0;
                        //    }
                        //    AddCustomerController addVIPCustomerController = new AddVIPCustomerController(name, mobile, address, isClubMember, discount, _customerRepository);
                        //    addVIPCustomerController.AddCustomer();
                        //    break;
                        //}
                        else
                        {
                            AddCustomerController addCustomerController = new AddCustomerController(name, mobile, address, isClubMember, discount, _customerRepository);
                            addCustomerController.AddCustomer();
                            break;
                        }
                    case "4":
                        Console.WriteLine("Valg 4");
                        Console.WriteLine("Indlæs navn:");
                        string menuName = Console.ReadLine();
                        Console.WriteLine("Indlæs pris");
                        double price = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Indlæs beskrivelse");
                        string description = Console.ReadLine();
                        Console.WriteLine("Menu Typer:" +
                            "\nSANDWICHES" +
                            "\nBRUCHETTA_CROSTINO" +
                            "\nSALATER" +
                            "\nPIZZECLASSSICHE" +
                            "\nPIZZESPECIALI" +
                            "\nPASTAALFORNO" +
                            "\nTILBEHØR" +
                            "\n\nIndlæs Type:");
                        string type = Console.ReadLine().ToUpper();
                        MenuType menuType;
                        //while (menuType = null)
                        //{
                        //    if (Enum.TryParse<MenuType>(Console.ReadLine(), out MenuType output))
                        //    {
                        //        menuType = output;
                        //    }
                        //}
                        if (type == "SANDWICHES") //I feel so bad writing this..
                        {
                            menuType = MenuType.SANDWICHES;
                        }
                        else if (type == "BRUCHETTA_CROSTINO")
                        {
                            menuType = MenuType.BRUCHETTA_CROSTINO;
                        }
                        else if (type == "SALATER")
                        {
                            menuType = MenuType.SALATER;
                        }
                        else if (type == "PIZZECLASSICHE")
                        {
                            menuType = MenuType.PIZZECLASSSICHE;
                        }
                        else if (type == "PIZZESPECIALI")
                        {
                            menuType = MenuType.PIZZESPECIALI;
                        }
                        else if (type == "PASTAALFORNO")
                        {
                            menuType = MenuType.PASTAALFORNO;
                        }
                        else if (type == "TILBEHØR")
                        {
                            menuType = MenuType.TILBEHØR;
                        }
                        else //Error Detected
                        {
                            Console.WriteLine("Invalid Menu Type: Press Enter to Return to Menu");
                            Console.ReadLine();
                            break;
                            //try
                            //{
                            //throw new ApplicationException(message: "Invalid Menu Type");
                            //}
                            //catch (ApplicationException Err)
                            //{
                            //    Console.WriteLine($"{Err.Message}: Item must match the list, CAPS sensitive");
                            //}
                        }
                        AddMenuItemController addMenuItemController = new AddMenuItemController(menuName, price, description, menuType, menuItemRepository);
                        addMenuItemController.AddMenuItem();
                        break;
                    default:
                        Console.WriteLine("Angiv et tal fra 1..4 eller q for afslut");
                        break;
                }
                theChoice = ReadChoice(mainMenuChoices);
            }
        }
        void CheckLowDiscount(int discount)
        {
            if (discount < 0)
            {
                throw new TooLowDiscountException("Discount is too low - Value was defaulted to 0 -");
            }
        }
        void CheckHighDiscount(int discount)
        {
            if (discount > 25)
            {
                throw new TooHighDiscountException("Discount is too high - Value was defaulted to 25 -");
            }
        }
    }
    //void CheckExistingMobile(string mobile, ICustomerRepository customerRepository)
    //{
    //    _customerRepository.GetAll();
    //    foreach (var customer in customerRepository)
    //    {
    //        if (customer.Value.Mobile.Equals(mobile))
    //        {
    //            throw new CustomerMobileExists("Dette nummer er allerede registreret.");
    //        }
    //    }
    //}


}
