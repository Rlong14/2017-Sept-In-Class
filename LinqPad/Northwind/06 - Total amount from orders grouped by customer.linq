<Query Kind="Expression">
  <Connection>
    <ID>02bb616b-a52c-4980-b61b-57bf90296a39</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>NorthwindExtended</Database>
  </Connection>
</Query>

// Get the total amount from all orders grouped by customer
from row in Orders
group row by new {row.Customer.CompanyName, row.Customer.ContactName}  // this is now the key
				into customerOrders // this is a group of orders
//orderby row.Customer.CompanyName
select new
//Initialization List - google this
{
	Company = customerOrders.Key.CompanyName,
	Contact = customerOrders.Key.ContactName,
	OrderTotal = (from order in customerOrders
					from item in order.OrderDetails 
					select item.UnitPrice * item.Quantity).Sum()
}

// The result of every query is a collection