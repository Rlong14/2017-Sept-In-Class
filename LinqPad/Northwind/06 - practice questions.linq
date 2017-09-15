<Query Kind="Expression">
  <Connection>
    <ID>02bb616b-a52c-4980-b61b-57bf90296a39</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>NorthwindExtended</Database>
  </Connection>
</Query>

//1) Give me a list of all the region names
//2) give me a list of all the territory names
//3) list all of the regions and the number of territories in each region
//4)List all the region and Territory names in a "flat" list
//5) List all the region and territory names as an "object graph" - use a nested query
//6)Group employees by territory and show the results in this format:
//|-------------------------------------------------------|
//|	Territory			|		Employees				  |
//|---------------------|---------------------------------|
//|	Eastern				|	---------------------------	  |
//|						|	| Nancy D.				  |   |
//|						|	|-------------------------|   |
//|           			|   |  Fred Flintsone	      |   |
//|						|	|-------------------------|	  |
//|						|   | Dan Gilleland			  |   |
//|						|	---------------------------	  |
//|---------------------|---------------------------------|
//| ...                 |								  |	


from row in Regions
select
row.RegionDescription


from row in Territories
select row.TerritoryDescription

from row in Regions
select new {
region = row.RegionDescription,
number = row.Territories.Count
}

from row in Territories //heres how to sort the results
orderby row.Region.RegionDescription, row.TerritoryDescription
select new {
region = row.Region.RegionDescription,
territory = row.TerritoryDescription
} // for this question its easier to start on the many side of one to many to get a flat list

from row in Regions
select new {
region = row.RegionDescription,
territories = (from data in row.Territories
				
				select
				data.TerritoryDescription)
}

from data in EmployeeTerritories
group data by data.Territory.Region.RegionDescription into regionGrp
select new
{
	Region = regionGrp.Key,
	Employees = from person in regionGrp
				select person.Employee.FirstName + " " + person.Employee.LastName
				// foreach (var person in regionGrp)
				//{
				//	get the name from the person object
				//}
}