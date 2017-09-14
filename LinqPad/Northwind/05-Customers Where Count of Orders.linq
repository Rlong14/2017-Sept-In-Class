<Query Kind="Expression">
  <Connection>
    <ID>bc7ed8d9-a24a-41d6-a741-4715e0bf2a66</ID>
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
	Item = from item in row.OrderDetails
		select new
	{
		ProductName = item.Product.ProductName,
		item.UnitPrice,
		item.Quantity,
		item.Discount
		Total = item.UnitPrice * item.Quantity //todo: apply a discount
	}
}