namespace lab11_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string dataFilePath = "C:\\Users\\luciu\\OneDrive\\������� ����\\��������\\������ ����������������\\2 �������\\lab11_1\\lab11_1\\bin\\Debug\\labawin.txt";

        public class PRICE
        {
            public string ProductName;
            public string ShopName;
            public double Cost;
        }

        private List<PRICE> prices = new List<PRICE>();
        private void Form1_Load(object sender, EventArgs e)
        {
            buttonLoad.Text = "��������� ������ �� �����";
            buttonGenerate.Text = "������������� ������";
            buttonLoad.Text = "�������� (���������) ��� ������";
            buttonSearch.Text = "����� ������ � ��������";
            textBoxProductName.PlaceholderText = "������� �������� ��������";

        }
        private void buttonLoad_Click(object sender, EventArgs e) // ������ "��������� ������"
        {
            if (!File.Exists(dataFilePath))
            {
                MessageBox.Show("���� �� ������!");
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
                MessageBox.Show("� ����� ��� ������");
                goto CodeEnd;
            }


            foreach (var item in prices)
            {
                listBoxPrices.Items.Add($"{item.ProductName} | {item.ShopName} | {item.Cost} ���.");
            }
            MessageBox.Show("������ ������� ���������!");

        CodeEnd:;


        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            prices.Clear();
            Random rnd = new Random();
            string[] products = { "������", "����", "������", "����", "����", "���", "���", "���", "����", "�������" };
            string[] shops = { "���������", "������", "�����", "����", "�����", "�����" };

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

            // ���������� � ����
            using (StreamWriter writer = new StreamWriter(dataFilePath))
            {
                foreach (var item in prices)
                {
                    writer.WriteLine($"{item.ProductName};{item.ShopName};{item.Cost}");
                }
            }

            MessageBox.Show("������ ������� ������������� � ���������!");
        }

        private void buttonSearch_Click(object sender, EventArgs e) // ����� �� ������
        {
            string productName = textBoxProductName.Text.Trim();
            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("������� ������������ ��������!");
                return;
            }

            var foundProducts = prices.FindAll(p => p.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase));

            listBoxPrices.Items.Clear();
            if (foundProducts.Count == 0)
            {
                listBoxPrices.Items.Add($"����� ��� ��������� '{productName}' �� ������.");
            }
            else
            {
                foreach (var item in foundProducts)
                {
                    listBoxPrices.Items.Add($"{item.ShopName} | {item.Cost} ���.");
                }
            }
        }


    }

}