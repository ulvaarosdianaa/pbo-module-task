
using System;
using System.Collections.Generic;

class Item
{
    public string Judul { get; set; }
    public int Tahun { get; set; }

    public Item(string judul, int tahun)
    {
        Judul = judul;
        Tahun = tahun;
    }

    public virtual void Deskripsi()
    {
        Console.WriteLine($"Item: {Judul}, Tahun: {Tahun}");
    }

    public void InfoItem()
    {
        Console.WriteLine($"Judul: {Judul}, Tahun: {Tahun}");
    }
}

class Buku : Item
{
    public string Penulis { get; set; }

    public Buku(string judul, int tahun, string penulis) : base(judul, tahun)
    {
        Penulis = penulis;
    }

    public override void Deskripsi()
    {
        Console.WriteLine($"Buku: {Judul}, Penulis: {Penulis}, Tahun: {Tahun}");
    }

    public void CekPenulis()
    {
        Console.WriteLine($"Penulis buku ini adalah {Penulis}");
    }
}

class Majalah : Item
{
    public int Edisi { get; set; }

    public Majalah(string judul, int tahun, int edisi) : base(judul, tahun)
    {
        Edisi = edisi;
    }

    public override void Deskripsi()
    {
        Console.WriteLine($"Majalah: {Judul}, Edisi {Edisi}, Tahun: {Tahun}");
    }

    public void InfoEdisi()
    {
        Console.WriteLine($"Majalah edisi ke-{Edisi}");
    }
}

class Novel : Buku
{
    public Novel(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

    public override void Deskripsi()
    {
        Console.WriteLine($"Novel: {Judul}, Penulis: {Penulis}, Tahun: {Tahun}");
    }

    public void BacaSinopsis()
    {
        Console.WriteLine($"Sinopsis novel {Judul} sedang dibaca...");
    }
}

class Komik : Buku
{
    public Komik(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

    public override void Deskripsi()
    {
        Console.WriteLine($"Komik: {Judul}, Penulis: {Penulis}, Tahun: {Tahun}");
    }

    public void TampilkanIlustrasi()
    {
        Console.WriteLine($"Menampilkan ilustrasi komik {Judul}...");
    }
}

class MajalahAnak : Majalah
{
    public MajalahAnak(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

    public override void Deskripsi()
    {
        Console.WriteLine($"Majalah Anak: {Judul}, Edisi {Edisi}, Tahun: {Tahun}");
    }

    public void KategoriAnak()
    {
        Console.WriteLine($"Majalah {Judul} termasuk kategori anak-anak.");
    }
}

class MajalahTeknologi : Majalah
{
    public MajalahTeknologi(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

    public override void Deskripsi()
    {
        Console.WriteLine($"Majalah Teknologi: {Judul}, Edisi {Edisi}, Tahun: {Tahun}");
    }

    public void TopikTeknologi()
    {
        Console.WriteLine($"Majalah {Judul} membahas topik teknologi terbaru.");
    }
}

class Perpustakaan
{
    private List<Item> koleksi = new List<Item>();

    public void TambahItem(Item item)
    {
        koleksi.Add(item);
    }

    public void DaftarItem()
    {
        Console.WriteLine("\n=== Daftar Koleksi Perpustakaan ===");
        foreach (var item in koleksi)
        {
            item.Deskripsi(); 
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Perpustakaan perpustakaan = new Perpustakaan();

        // Buat objek
        Novel novel = new Novel("Laskar Pelangi", 2005, "Andrea Hirata");
        Komik komik = new Komik("Naruto", 1999, "Masashi Kishimoto");
        MajalahAnak majalahAnak = new MajalahAnak("Bobo", 2020, 15);
        MajalahTeknologi majalahTek = new MajalahTeknologi("Tech Today", 2021, 7);

        // Tambahkan ke perpustakaan
        perpustakaan.TambahItem(novel);
        perpustakaan.TambahItem(komik);
        perpustakaan.TambahItem(majalahAnak);
        perpustakaan.TambahItem(majalahTek);

        // Tampilkan semua data
        perpustakaan.DaftarItem();

        Console.WriteLine("\n=== Demonstrasi Polymorphism & Method Khusus ===");
        novel.CekPenulis();
        novel.BacaSinopsis();

        komik.CekPenulis();
        komik.TampilkanIlustrasi();

        majalahAnak.InfoEdisi();
        majalahAnak.KategoriAnak();

        majalahTek.InfoEdisi();
        majalahTek.TopikTeknologi();
    }
}
