<Query Kind="Expression">
  <Connection>
    <ID>02bb616b-a52c-4980-b61b-57bf90296a39</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>NorthwindExtended</Database>
  </Connection>
</Query>

//Mine
/*
from person in Customers
where person.Orders.Count >5
select new //Person
{
	
	FormalName = person.ContactName,
	OrderCount = person.Orders.Count
	
}
*/
//Teachers
// Get the order totals and basic customer information for each order
from row in Orders
select new
//Initialization List - google this
{
	Company = row.Customer.CompanyName,
	Contact = row.Customer.ContactName,
	OrderTotal = (from item in row.OrderDetails select item.UnitPrice * item.Quantity).Sum()//,
//	Item = from item in row.OrderDetails
//		select new
//	{
//		ProductName = item.Product.ProductName,
//		item.UnitPrice,
//		item.Quantity,
//		item.Discount,
//		Total = item.UnitPrice * item.Quantity //todo: apply a discount
//	}
}