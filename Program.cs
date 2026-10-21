using System;
using System.Numerics;

namespace KerangkaGame
{
    class Karakter
    {
        public int totalSenjata, kekuatan;

        public string nama { get; private set; }
        public int kesehatan { get; private set; }
        public int senjata { get; private set; }
        public int posisi { get; private set; } = 0;

        public Karakter(string nama, int kesehatan, int senjata)   //membuat constructor
        {
            this.nama = nama;
            this.kesehatan = kesehatan;
            this.senjata = senjata;
            this.posisi = 0;
        }

        public void Serang(Karakter target)
        {
            Console.WriteLine("===> Mulai Serangan");
            target.TerimaSerangan(this.senjata);     //Panggil method di bawahnya
        }

        public void TerimaSerangan(int jumlahSerangan) // objek menerima serangan
        {
            kesehatan -= jumlahSerangan;
            Console.WriteLine($"{nama} diserang dengan {jumlahSerangan}. Sisa kesehatan {kesehatan}");
        }

        // Method healing (menambah kesehatan +20)
        public void Healing()
        {
            if (kesehatan <= 0)
            {
                Console.WriteLine($"Karakter {nama} mati! Tidak bisa melakukan healing.");
            }
            else if (kesehatan >= 1)
            {
                Console.Write($"Apakah {nama} ingin melakukan healing? (Y/N): ");
                string pilihan = Console.ReadLine()?.Trim().ToUpper();

                if (pilihan == "Y")
                {
                    kesehatan += 20;
                    Console.WriteLine($"\n--> {nama} melakukan healing!");
                    Console.WriteLine($"{nama} memulihkan 20 HP. Total kesehatan sekarang: {kesehatan}");
                }
                else if (pilihan == "N")
                {
                    Console.WriteLine($"\n--> {nama} memilih untuk tidak melakukan healing.");
                }
                else
                {
                    Console.WriteLine("\n--> Pilihan tidak ada!");
      
                }
            }
        }

        // Method PindahPosisi interaktif menggunakan tombol D, A, dan Esc
        public void PindahPosisi()
        {
            while (true)
            {
                // Membaca tombol keyboard tanpa harus menekan Enter
                ConsoleKeyInfo tombol = Console.ReadKey(true);

                if (tombol.Key == ConsoleKey.D)
                {
                    posisi += 2; // Bertambah
                    Console.WriteLine($"Posisi saat ini: {posisi}");
                }
                else if (tombol.Key == ConsoleKey.A)
                {
                    if (posisi > 0)
                    {
                        posisi -= 1; // Berkurang 1
                        Console.WriteLine($"Posisi saat ini: {posisi}");
                    }
                    else
                    {
                        Console.WriteLine("Sudah tidak dapat berpindah (Posisi sudah 0).");
                    }
                }
                else if (tombol.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Permainan dihentikan.");
                    break; // Keluar dari perulangan
                }
            }
        }

        public void getData()
        {
            Console.WriteLine($"Karakter {nama}, HP: {kesehatan}, Posisi: {posisi}");
        }
    }

    class MainProgram
    {
        static void Main(string[] args)
        {
            Karakter player1 = new Karakter("Yazid", 100, 100);   //Main player
            Karakter musuh = new Karakter("Aditya", 100, 70);

            //interaksi
            musuh.Serang(player1);

            player1.getData();

            // Memanggil method healing
            player1.Healing();

            // Cek data setelah healing
            player1.getData();

            // Memanggil method PindahPosisi interaktif dengan keyboard
            player1.PindahPosisi();
        }
    }
}