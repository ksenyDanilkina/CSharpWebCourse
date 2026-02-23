using Newtonsoft.Json;
using JSONTask.Models;

var filePath = Path.Combine("..", "..", "..", "countries.json");

var jsonFileData = File.ReadAllText(filePath);

var jsonData = JsonConvert.DeserializeObject<List<Country>>(jsonFileData);

var totalPopulation = jsonData?.Sum(country => country.Population);
Console.WriteLine($"Суммарная численность населения всех стран: {totalPopulation}");

var currencies = jsonData?.SelectMany(country => country.Currencies)
    .DistinctBy(currency => currency.Code)
    .ToList();

Console.WriteLine("Список валют:");

foreach (var currency in currencies!)
{
    Console.WriteLine(currency);
}
