using System;
using System.Collections;

// Bizim bir aptekimiz var. Aptekdə dərmanlar var və onlar müxtəlif tipdə olan xəstəliklər üçün istifadə olunur.
// Aptekdə dərmanların siyahısını göstərən bir metodumuz olsun. Aptekə yeni dərmanlar gəldikdə əlavə eləmək olsun.
// Aptekdə dərman üçün satış metodu icra olunsun.

class Medicine // Derman
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string DiseaseType { get; set; }
    public decimal Price { get; set; }
    public int StockAmount { get; set; }
}

class Pharmacy // Aptek
{

    private ArrayList Medicinelist = new ArrayList();

    // Yeni derman elave etmek
    public void MedicineAdd(Medicine medicine)
    {
        Medicinelist.Add(medicine);
    }

    // Derman alisi.
    public void MedicineBuy(int medicineId, int amount)
    {
        //Medicine medicine = Medicinelist.Find(i => i.Id == medicineId);
        foreach (Medicine medicine in Medicinelist)
        {
            if (medicine.Id == medicineId && medicine.StockAmount >= amount)
            {
                medicine.StockAmount += amount;
                Console.WriteLine($"Adi {medicine.Name} olan dermandan {amount} eded alindi.");
            }
        }
    }

    // Derman satisi.
    public void MedicineSales(string diseaseType, int amount)
    {
        foreach (Medicine medicine in Medicinelist)
        {
            if (medicine.DiseaseType == diseaseType && medicine.StockAmount >= amount)
            {
                medicine.StockAmount -= amount;
                Console.WriteLine($"{amount} edet {diseaseType} xesteliyine qarsi derman satildi.");
                return;
            }
        }
        Console.WriteLine("Müvafiq xəstəlik növü üçün dərmanlar tapılmadı.");
    }

    public void PharmacyMedicineList() // Dermanlari sadalamaq.
    {
        Console.WriteLine("Aptek derman listi: ");
        foreach (Medicine medicine in Medicinelist)
        {
            Console.WriteLine($"ID: {medicine.Id}, Ad: {medicine.Name}, Xestelik tipi: {medicine.DiseaseType}, Qiymeti: {medicine.Price}, Stock miqdari: {medicine.StockAmount}");
        }
    }

     public void MedicineStockUpdate()
    {
        // Console.WriteLine("Aptek derman listi: ");
        foreach (Medicine medicine in Medicinelist)
        {
            medicine.StockAmount += 50; // Məsələn, hər bir məhsulu 50 eded yenilə.
        }
        Console.WriteLine("Stok yenilendi");
    }


}

class Program
{
    static void Main(string[] args)
    {
        Pharmacy pharmacy = new Pharmacy();

        // Numune dermanlar yaradilir.
        Medicine medicine1 = new Medicine { Id = 1, Name = "Derman 1", DiseaseType = "Xestelik tipi 1", Price = 10.0m, StockAmount = 50 };
        Medicine medicine2 = new Medicine { Id = 2, Name = "Derman 2", DiseaseType = "Xestelik tipi 2", Price = 15.0m, StockAmount = 30 };

        // Dermanlar apteke elave edilir.
        pharmacy.MedicineAdd(medicine1);
        pharmacy.MedicineAdd(medicine2);

        // Dermanlari sadalamaq.
        pharmacy.PharmacyMedicineList();

        // Derman alisi.
        pharmacy.MedicineBuy(1,10);

        // Dermanlari sadalamaq.
        pharmacy.PharmacyMedicineList();

        // Derman satisi. // Musteri xestelik tipine gore derman alir.
        pharmacy.MedicineSales("Xestelik tipi 1", 5);

        // Dermanlari sadalamaq.
        pharmacy.PharmacyMedicineList();

        // 50 eded yeni mehsul elave edildi. // Yeni dermanlar gelende stoku yenile.
        pharmacy.MedicineStockUpdate();

        // Dermanlari sadalamaq.
        pharmacy.PharmacyMedicineList();
    }
}