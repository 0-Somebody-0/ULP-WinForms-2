namespace lab11_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string dataFilePath = "C:\\Users\\luciu\\OneDrive\\Рабочий стол\\Предметы\\Основы программирования\\2 семестр\\lab11_1\\lab11_1\\bin\\Debug\\labawin.txt";

        public class PRICE
        {
            public string ProductName;
            public string ShopName;
            public double Cost;
        }

        private List<PRICE> prices = new List<PRICE>();
        private void Form1_Load(object sender, EventArgs e)
        {
            buttonLoad.Text = "Загрузить данные из файла";
            buttonGenerate.Text = "Сгенерировать данные";
            buttonLoad.Text = "Показать (загрузить) все товары";
            buttonSearch.Text = "Найти товары в магазине";
            textBoxProductName.PlaceholderText = "Введите название магазина";

        }
        private void buttonLoad_Click(object sender, EventArgs e) // кнопка "Загрузить данные"
        {
            if (!File.Exists(dataFilePath))
            {
                MessageBox.Show("Файл не найден!");
                return;
            }

            prices.Clear();
            listBoxPrices.Items.Clear();

            int lines_count = 0;
            using (StreamReader reader = new StreamReader(dataFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length == 3)
                    {
                        prices.Add(new PRICE
                        {
                            ProductName = parts[0],
                            ShopName = parts[1],
                            Cost = double.Parse(parts[2])
                        });
                    }
                    lines_count += 1;
                }
            }
            if (lines_count == 0)
            {
                MessageBox.Show("В файле нет данных");
                goto CodeEnd;
            }


            foreach (var item in prices)
            {
                listBoxPrices.Items.Add($"{item.ProductName} | {item.ShopName} | {item.Cost} руб.");
            }
            MessageBox.Show("Данные успешно загружены!");

        CodeEnd:;


        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            prices.Clear();
            Random rnd = new Random();
            string[] products = { "Молоко", "Хлеб", "Яблоки", "Мясо", "Рыба", "Сок", "Сыр", "Чай", "Кофе", "Шоколад" };
            string[] shops = { "Пятерочка", "Магнит", "Лента", "Ашан", "Метро", "Дикси" };

            for (int i = 0; i < 10; i++)
            {
                prices.Add(new PRICE
                {
                    ProductName = products[rnd.Next(products.Length)],
                    ShopName = shops[rnd.Next(shops.Length)],
                    Cost = rnd.Next(50, 500)
                });
            }
            prices = prices.OrderBy(p => p.ProductName, StringComparer.OrdinalIgnoreCase).ToList();

            // Сохранение в файл
            using (StreamWriter writer = new StreamWriter(dataFilePath))
            {
                foreach (var item in prices)
                {
                    writer.WriteLine($"{item.ProductName};{item.ShopName};{item.Cost}");
                }
            }

            MessageBox.Show("Данные успешно сгенерированы и сохранены!");
        }

        private void buttonSearch_Click(object sender, EventArgs e) // Поиск по товару
        {
            string productName = textBoxProductName.Text.Trim();
            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Введите наименование продукта!");
                return;
            }

            var foundProducts = prices.FindAll(p => p.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase));

            listBoxPrices.Items.Clear();
            if (foundProducts.Count == 0)
            {
                listBoxPrices.Items.Add($"Товар под названием '{productName}' не найден.");
            }
            else
            {
                foreach (var item in foundProducts)
                {
                    listBoxPrices.Items.Add($"{item.ShopName} | {item.Cost} руб.");
                }
            }
        }


    }

}