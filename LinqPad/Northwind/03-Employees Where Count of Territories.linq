<Query Kind="Expression">
  <Connection>
    <ID>bc7ed8d9-a24a-41d6-a741-4715e0bf2a66</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>NorthwindExtended</Database>
  </Connection>
</Query>

from person in Employees 
where person.EmployeeTerritories.Count >=4
select person.EmployeeTerritories//.count