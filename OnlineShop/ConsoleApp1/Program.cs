// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using System.Text.Json;

Buyer b2 = new Buyer();

b2.Name = "Ivan12";
b2.Surname = "Popov12";


JsonController<Buyer>.WriteToFile(b2);