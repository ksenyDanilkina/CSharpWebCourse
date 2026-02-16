using Newtonsoft.Json;
using JSONTask.Models;

const string filepath = "../../../countries.json";

var jsonFile = File.ReadAllText(filepath);

var jsonData = JsonConvert.DeserializeObject<List<Country>>(jsonFile);

var population = jsonData?.Sum(country => country.Population);

Console.WriteLine($"Суммарная популяция всех стран: {population}");

var currencies = jsonData?
    .Select(country => country.Currencies)
    .SelectMany(currency => currency)
    .DistinctBy(currency => currency.Code)
    .ToList();

Console.WriteLine("Список валют: ");
foreach (var currency in currencies)
{
    Console.WriteLine(currency);
}