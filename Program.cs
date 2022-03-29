using System.Linq;
using ClosedXML.Excel;
using ValidaçãoPrecoPlanilhaHub2b.Database;
using ValidaçãoPrecoPlanilhaHub2b.Models;
using System.Text.Json;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Context context;

var xlsx = new XLWorkbook(@"C:\planilha\planilha.xlsx");
var planilha = xlsx.Worksheets.First(w => w.Name == "planilha");
var totalLinhas = planilha.Rows().Count();
IEnumerable<ProductPrice>? list;

var index = 2; // primeira linha é o cabecalho

foreach (var row in planilha.Rows())
{
    var codigo = planilha.Cell($"A{index}").Value.ToString();
    var priceBy = double.Parse(planilha.Cell($"B{index}").Value.ToString());
    var priceTo = double.Parse(planilha.Cell($"C{index}").Value.ToString());

    using (context = new Context())
    {
        var productDb = context.product?.Where(x => x.idTenant == 3146 && x.sourceSKU == codigo).ToList();
        list = productDb?.Where(x => x.DestinationPriceSale != priceTo || x.DestinationPriceBase != priceBy);               
    }

    if(list?.Count() > 0)
        Console.WriteLine($"{codigo} not updated idSystem: {JsonSerializer.Serialize(list.Select(x=> x.idSystemDestination))}");
    //else
        //Console.WriteLine($"SKU: {codigo} updated with success.");

    index++;
}

for (int l = 2; l <= totalLinhas; l++)
{
    
}
