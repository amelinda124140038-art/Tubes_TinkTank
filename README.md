# 🤖 Tubes_TinkTank - Robocode Tank Royale

Repository ini berisi kode sumber dan dokumentasi untuk Tugas Besar Mata Kuliah Strategi Algoritma di Institut Teknologi Sumatera (ITERA). Proyek ini mengimplementasikan **Algoritma Greedy** dalam membangun *behavior* kecerdasan buatan pada bot pertempuran Robocode Tank Royale.

## 👥 Anggota Kelompok (TinkTank)
* **Nasywa Putri Salsabila** (124140005)
* **Angelica Putri** (124140131)
* **Amelinda Simanjuntak** (124140038)

---

## 🧠 Penjelasan Singkat Algoritma Greedy

Proyek ini mengeksplorasi pembentukan fungsi seleksi (*heuristic*) yang adaptif untuk mengoptimalkan perolehan skor pertempuran (seperti *Bullet Damage* dan *Survival Score*). Repository ini memuat 4 variasi bot dengan strategi *greedy* yang berbeda:

1. **Main Bot (Opportunist Bot - Strategi Terpilih):** Menggunakan strategi *greedy* berbasis informasi global yaitu jumlah musuh yang masih hidup di arena (`aliveEnemies`). Bot ini membagi aksinya menjadi 3 fase dinamis:
   * *Fase Awal (> 5 musuh):* Bermain defensif (`WaitingMode`) untuk menghemat energi.
   * *Fase Transisi (2-5 musuh):* Menjaga jarak ideal (`PositioningMode`).
   * *Fase Duel Akhir (1 musuh):* Menjadi sangat agresif (`HunterMode`) untuk mengamankan bonus kemenangan.
2. **Alternatif Bot 1 (Cornering Bot):** Menggunakan strategi *greedy* statis, langsung bergerak mengunci koordinat sudut (60, 60) sejak awal laga demi meminimalkan arah datangnya serangan musuh.
3. **Alternatif Bot 2 (Self-Energy Bot):** Mengambil keputusan taktis pergerakan dan daya tembak secara *greedy* dengan mengevaluasi sisa kapasitas energinya sendiri pada setiap putaran.
4. **Alternatif Bot 3 (Flanking & Predictive Shoot Bot):** Berorientasi penuh pada strategi ofensif menggunakan perhitungan fisika peluru untuk memprediksi koordinat masa depan musuh berdasarkan arah dan kecepatannya.

---

## 🛠️ Requirements & Instalasi

Sebelum menjalankan bot ini, pastikan komputer Anda telah memenuhi persyaratan berikut:

1. **.NET SDK:** Install .NET SDK versi terbaru (direkomendasikan versi yang mendukung C# terbaru).
2. **Java Runtime Environment (JRE):** Diperlukan untuk mengeksekusi aplikasi GUI Java dari Robocode Tank Royale.
3. **Robocode Tank Royale GUI:** Unduh rilis GUI game engine (dalam proyek ini menggunakan basis referensi package versi 0.30.0).

---

## 💻 Panduan Compile & Menjalankan Bot

Ikuti langkah-langkah di bawah ini untuk meng-compile kode sumber dan menerjunkan bot ke arena pertempuran:

### 1. Compile Proyek Bot via Terminal
Masuk ke direktori folder bot yang ingin Anda gunakan (misalnya `src/main-bot/`), lalu jalankan perintah berikut untuk melakukan *build* proyek C#:
```bash
dotnet build