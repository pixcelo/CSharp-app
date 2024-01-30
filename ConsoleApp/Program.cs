using ConsoleApp.Classes.Models;

var MyMoney = new Money(1000, "JPY");
var allowance = new Money(3000, "JPY");
var result = MyMoney.Add(allowance);