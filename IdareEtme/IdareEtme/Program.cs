using IdareEtme.Repositories;

namespace IdareEtme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var productRepo = new ProductRepository();
            var categoryRepo = new CategoryRepository();

            while (true)
            {
                Console.WriteLine("------MENU------");
                Console.WriteLine("1.Product elave et");
                Console.WriteLine("2.Product update et");
                Console.WriteLine("3.Product sil");
                Console.WriteLine("4.Bütün Product-ları göster");
                Console.WriteLine("5.Product-u Id-e göre tap");
                Console.WriteLine("6.Category elave et ");
                Console.WriteLine("7.Category update et");
                Console.WriteLine("8.Category sil");
                Console.WriteLine("9.Bütün Category-leri göster");
                Console.WriteLine("10.Category-ni Id-e göre tap");
                Console.WriteLine("0.Çıxış");
                Console.Write("Seçimim:");

                string choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Mehsulun adi: ");
                            var name = Console.ReadLine();
                            Console.Write("Qiymet: ");
                            var price = decimal.Parse(Console.ReadLine());
                            Console.Write("Kateqoriya id-sini daxil edin: ");
                            var categoryId = int.Parse(Console.ReadLine());
                            productRepo.Add(name, price, categoryId);
                            Console.WriteLine("Product elave olundu.");
                            break;

                        case "2":
                            Console.Write("Yenilenecek mehsulun id-si: ");
                            var updateId = int.Parse(Console.ReadLine());
                            Console.Write("Yeni ad: ");
                            var updateName = Console.ReadLine();
                            Console.Write("Yeni qiymet: ");
                            var updatePrice = decimal.Parse(Console.ReadLine());
                            Console.Write("Yeni kateqoriya: ");
                            var updateCategoryId = int.Parse(Console.ReadLine());
                            productRepo.Update(updateId, updateName, updatePrice, updateCategoryId);
                            Console.WriteLine("Mehsul yeniləndi.");
                            break;

                        case "3":
                            Console.Write("Mehsulun id-si: ");
                            var deleteId = int.Parse(Console.ReadLine());
                            productRepo.Delete(deleteId);
                            Console.WriteLine("Product silindi.");
                            break;

                        case "4":
                            var products = productRepo.GetAll();
                            foreach (var prod in products)
                            {
                                Console.WriteLine($"{prod.Id} - {prod.Name} - {prod.Price} - CategoryId: {prod.CategoryId}");
                            }
                            break;

                        case "5":
                            Console.Write("Product Id: ");
                            var getId = int.Parse(Console.ReadLine());
                            var product = productRepo.GetById(getId);
                            if (product != null)
                                Console.WriteLine($"{product.Id} - {product.Name} - {product.Price} - CategoryId: {product.CategoryId}");
                            else
                                Console.WriteLine("Product tapılmadı.");
                            break;

                        case "6":
                            Console.Write("Yeni kateqoriya adi: ");
                            var catName = Console.ReadLine();
                            categoryRepo.Add(catName);
                            Console.WriteLine("Kateqoriya əlavə olundu.");
                            break;

                        case "7":
                            Console.Write("Yenilenecek kateqoriyani id-si: ");
                            var catUpdateId = int.Parse(Console.ReadLine());
                            Console.Write("Yeni ad: ");
                            var catNewName = Console.ReadLine();
                            categoryRepo.Update(catUpdateId, catNewName);
                            Console.WriteLine("Kateqoriya yeniləndi.");
                            break;

                        case "8":
                            Console.Write("Silinecek kateqoriyanin id-si: ");
                            var catDeleteId = int.Parse(Console.ReadLine());
                            categoryRepo.Delete(catDeleteId);
                            Console.WriteLine("Kateqoriya silindi.");
                            break;

                        case "9":
                            var categories = categoryRepo.GetAll();
                            foreach (var cat in categories)
                            {
                                Console.WriteLine($"{cat.Id} - {cat.Name}");
                            }
                            break;

                        case "10":
                            Console.Write("Axtarilan kateqoriyanin id-si: ");
                            var catGetId = int.Parse(Console.ReadLine());
                            var category = categoryRepo.GetById(catGetId);
                            if (category != null)
                                Console.WriteLine($"{category.Id} - {category.Name}");
                            else
                                Console.WriteLine("Kateqoriya tapılmadı.");
                            break;

                        case "0":
                            Console.WriteLine("Çıxıs");
                            return;
                        default:
                            Console.WriteLine("Yanlış seçim etdiniz!");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"Xeta baş verdi.");
                }
            }
        }
    }
}
