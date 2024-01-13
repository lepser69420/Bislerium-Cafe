using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Colors = QuestPDF.Helpers.Colors;


namespace CafeCoffee.Components.Data
{
    public class PdfGenerator
    {
        // Montlhy report generation
        public static void GenerateMonthlySalesReport(List<Order> orders, string filePath)
        {
            float totalRev = 0;
            DatabaseContext db = DatabaseContext.getInstance();
            DateTime startDate = DateTime.Now.AddMonths(-1);
            DateTime endDate = DateTime.Now;
            // Find previous month orders
            List<Order> customerOrders = new List<Order>();
            foreach (var ord in db.GetOrders())
            {
                if (ord.Date >= startDate &&
                ord.Date <= endDate)
                {
                    customerOrders.Add(ord);
                    totalRev += ord.TotalPaid;
                }
            }

            // Fetch coffee and addons
            List<string> coffees = new List<string>();
            List<string> addons = new List<string>();
            foreach (var item in customerOrders)
            {
                string[] fields = item.OrderItem.Split("+");
                if (fields.Length > 0)
                {
                    coffees.Add(fields[0]);
                    for (int i = 1; i < fields.Length; i++)
                    {
                        addons.Add(fields[i]);
                    }
                }
            }
            // Counting the quantity of each coffee
            var coffeeQuantities = coffees.GroupBy(coffee => coffee)
                                     .ToDictionary(group => group.Key, group => group.Count());

            // Counting the quantity of each addon
            var addonQuantities = addons.GroupBy(addon => addon)
                                        .ToDictionary(group => group.Key, group => group.Count());


            // Generate pdf
            QuestPDF.Settings.License = LicenseType.Community;
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(16));

                    page.Header()
                        .AlignCenter()
                        .Text($"Monthly Report {startDate.ToString("dd MMM, yyyy")} - {endDate.ToString("dd MMM, yyyy")}" + $"\n\n Total revenue: {totalRev}\n")
                        .SemiBold().FontSize(24).FontColor(Colors.Grey.Darken4);

                    page.Content()
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Text("Coffee");
                                header.Cell().Text("Quantity");
                            });
                            table.Cell().Text("--------------------");
                            table.Cell().Text("--------------------");
                            foreach (var coffeeQuantity in coffeeQuantities.OrderByDescending(kv => kv.Value).Take(5))
                            {
                                table.Cell().Text(coffeeQuantity.Key);
                                table.Cell().Text($"{coffeeQuantity.Value}");
                            }
                            table.Cell().Text("\n");
                            table.Cell().Text("\n");
                            table.Cell().Text("Addons");
                            table.Cell().Text("Quantity");
                            table.Cell().Text("--------------------");
                            table.Cell().Text("--------------------");

                            foreach (var addonQuantity in addonQuantities.OrderByDescending(kv => kv.Value).Take(5))
                            {
                                table.Cell().Text(addonQuantity.Key);
                                table.Cell().Text($"{addonQuantity.Value}");
                            }
                        });


                    page.Footer()
            .AlignCenter()
            .Text("BISLERIUM CAFE");
                });
            }).GeneratePdf(filePath);
        }

        // Generate daily report
        public static void GenerateDailySalesReport(List<Order> orders, string filePath)
        {
            float totalRev = 0;
            DatabaseContext db = DatabaseContext.getInstance();
            DateTime startDate = DateTime.Now.AddDays(-1);
            DateTime endDate = DateTime.Now;
            List<Order> customerOrders = new List<Order>();
            // Find one day orders
            foreach (var ord in db.GetOrders())
            {
                if (ord.Date >= startDate &&
                ord.Date <= endDate)
                {
                    customerOrders.Add(ord);
                    totalRev += ord.TotalPaid;
                }
            }

            // find coffee and addons in the orders
            List<string> coffees = new List<string>();
            List<string> addons = new List<string>();
            foreach (var item in customerOrders)
            {
                string[] fields = item.OrderItem.Split("+");
                if (fields.Length > 0)
                {
                    coffees.Add(fields[0]);
                    for (int i = 1; i < fields.Length; i++)
                    {
                        addons.Add(fields[i]);
                    }
                }
            }

            // Counting the quantity of each coffee
            var coffeeQuantities = coffees.GroupBy(coffee => coffee)
                                     .ToDictionary(group => group.Key, group => group.Count());

            // Counting the quantity of each addon
            var addonQuantities = addons.GroupBy(addon => addon)
                                        .ToDictionary(group => group.Key, group => group.Count());



            QuestPDF.Settings.License = LicenseType.Community;
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(16));

                    page.Header()
                        .AlignCenter()
                        .Text($"Daily Report {startDate.ToString("dd MMM, yyyy")} - {endDate.ToString("dd MMM, yyyy")}" + $"\n\n Total revenue: {totalRev}\n")
                        .SemiBold().FontSize(24).FontColor(Colors.Grey.Darken4);

                    page.Content()
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Text("Coffee");
                                header.Cell().Text("Quantity");
                            });
                            table.Cell().Text("--------------------");
                            table.Cell().Text("--------------------");
                            foreach (var coffeeQuantity in coffeeQuantities.OrderByDescending(kv => kv.Value).Take(5))
                            {
                                table.Cell().Text(coffeeQuantity.Key);
                                table.Cell().Text($"{coffeeQuantity.Value}");
                            }
                            table.Cell().Text("\n");
                            table.Cell().Text("\n");
                            table.Cell().Text("Addons");
                            table.Cell().Text("Quantity");
                            table.Cell().Text("--------------------");
                            table.Cell().Text("--------------------");

                            foreach (var addonQuantity in addonQuantities.OrderByDescending(kv => kv.Value).Take(5))
                            {
                                table.Cell().Text(addonQuantity.Key);
                                table.Cell().Text($"{addonQuantity.Value}");
                            }
                        });


                    page.Footer()
            .AlignCenter()
            .Text("BISLERIUM CAFE");
                });
            }).GeneratePdf(filePath);
        }
    }
}
