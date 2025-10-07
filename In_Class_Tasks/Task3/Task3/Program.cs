/*Maddox Madia
In class task 3: Ask users for items and summarize their information
9/18/25
*/


Console.WriteLine("How many items are in this order?");
int intItemCount = int.Parse(Console.ReadLine());

//Define arrays according to item count
string[] strNames = new string[intItemCount];
double[] dblPrices = new double[intItemCount];
double[] dblLineTotals = new double[intItemCount];
double[] dblLineDiscounts = new double[intItemCount];
int[] intQtys = new int[intItemCount];
int[] intStocks = new int[intItemCount];
bool[] boolReorder = new bool[intItemCount];

for (int i = 0; i < intItemCount; i++)
{
    Console.WriteLine("Enter product name:");
    strNames[i] = Console.ReadLine();

    Console.WriteLine("Enter unit price:");
    dblPrices[i] = double.Parse(Console.ReadLine());

    if (dblPrices[i] < 0)
    {
        Console.WriteLine("Price must be a positive number");
    }

    Console.WriteLine("Enter quantity (integer):");
    intQtys[i] = int.Parse(Console.ReadLine());

    if (intQtys[i] <= 0)
    {
        Console.WriteLine("Quantity must be greater than 0.");
    }

    Console.WriteLine("Enter stock on hand (integer):");
    intStocks[i] = int.Parse(Console.ReadLine());

    if (intStocks[i] < 0)
    {
        Console.WriteLine("Stock cannot be negative.");
    }
    //Calculate gross
    double dblGrossCost = dblPrices[i] * intQtys[i];

    //Discount
    if (intQtys[i] >= 10)
    {
        dblLineDiscounts[i] = dblGrossCost * .05;
    }
    else
    {
        dblLineDiscounts[i] = 0;
    }
    //Calculate total
    dblLineTotals[i] = dblGrossCost - dblLineDiscounts[i];

    //Inventory after sale
    int intPostSaleStock = intStocks[i] - intQtys[i];

    if (intPostSaleStock < 5)
    {
        boolReorder[i] = true;
    }

    else
    {
        boolReorder[i] = false;
    }

    //Calculate totals
    double dblSubtotal = 0;
    for (i = 0; i < intItemCount; i++)
    {
        dblSubtotal = dblSubtotal + dblLineTotals[i];
    }
    
    double dblTax = dblSubtotal * .06;
    double dblGrand = dblSubtotal + dblTax;

    //Create table
    Console.WriteLine();
    Console.WriteLine("=== Order Summary ===");
    Console.WriteLine("Name            Price    Qty    Gross      Disc       Line Total  Reorder");
    Console.WriteLine("-----------------------------------------------------------------------");

    for (i = 0; i < intItemCount; i++)
    {
        double gross = dblPrices[i] * intQtys[i];

        if (boolReorder[i] = true)
        {
            Console.WriteLine($"{strNames[i]}\t\t{dblPrices[i]}\t{intQtys[i]}\t{gross}\t\t{dblLineDiscounts[i]}\t\t{dblLineTotals[i]}\t\t", "YES");
        }
        else
        {
            Console.WriteLine($"{strNames[i]}\t\t{dblPrices[i]}\t{intQtys[i]}\t{gross}\t\t{dblLineDiscounts[i]}\t\t{dblLineTotals[i]}\t\t", "NO");
        }

        Console.WriteLine("-----------------------------------------------------------------------");
        Console.WriteLine("Subtotal:\t\t\t\t\t\t\t\t" + dblSubtotal);
        Console.WriteLine("Tax (6%):\t\t\t\t\t\t\t\t" + dblTax);
        Console.WriteLine("GRAND TOTAL:\t\t\t\t\t\t\t\t" + dblGrand);
    }
}
