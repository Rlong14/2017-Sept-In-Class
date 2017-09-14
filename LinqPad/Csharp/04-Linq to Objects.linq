<Query Kind="Statements" />

//from char letter in "Dan Gilleland"
//select letter
string[] names = {"Dan","don","sam"};
names.Dump();
var result = from item in names
select item;
result.Dump();