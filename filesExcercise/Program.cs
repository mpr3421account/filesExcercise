/*Fazer um programa para ler o caminho de um arquivo .csv
contendo os dados de itens vendidos. Cada item possui um
nome, preço unitário e quantidade, separados por vírgula. Você
deve gerar um novo arquivo chamado "summary.csv", localizado
em uma subpasta chamada "out" a partir da pasta original do
arquivo de origem, contendo apenas o nome e o valor total para
aquele item (preço unitário multiplicado pela quantidade),
conforme exemplo.
*/
using filesExcercise.Entitites;
using System.Globalization;

Console.Write("Enter file full path: ");
string sourceFilePath = Console.ReadLine();

try
{
    string[] lines = File.ReadAllLines(sourceFilePath);
    string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
    string targeFolderPath = sourceFolderPath + @"\out";
    string targetFilePath = sourceFolderPath + @"\summary.csv";

    Directory.CreateDirectory(targeFolderPath);

    using (StreamWriter sw = File.AppendText(targetFilePath))
    {
        foreach(string line in lines)
        {
            string[] fields = line.Split(',');
            string name = fields[0];
            double price = double.Parse(fields[1],CultureInfo.InvariantCulture);
            int quantity = int.Parse(fields[2]);

            Product prod = new Product(name,price,quantity);

            sw.WriteLine(prod.Name + "," + prod.TotalValue().ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
catch(IOException e)
{
    Console.WriteLine("an error occurred: " + e.Message);
}