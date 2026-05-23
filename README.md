# 🤖 Tubes_TinkTank - Robocode Tank Royale

[cite_start]Repository ini berisi kode sumber dan dokumentasi untuk Tugas Besar Mata Kuliah Strategi Algoritma di Institut Teknologi Sumatera (ITERA)[cite: 1, 4]. [cite_start]Proyek ini mengimplementasikan **Algoritma Greedy** dalam membangun *behavior* kecerdasan buatan pada bot pertempuran Robocode Tank Royale[cite: 1, 5].

## 👥 Anggota Kelompok (TinkTank)
* [cite_start]**Nasywa Putri Salsabila** (124140005) 
* [cite_start]**Angelica Putri** (124140131) 
* [cite_start]**Amelinda Simanjuntak** (124140038) 

---

## 🧠 Penjelasan Singkat Algoritma Greedy

[cite_start]Proyek ini mengeksplorasi pembentukan fungsi seleksi (*heuristic*) yang adaptif untuk mengoptimalkan perolehan skor pertempuran (seperti *Bullet Damage* dan *Survival Score*)[cite: 31, 37, 38]. [cite_start]Repository ini memuat 4 variasi bot dengan strategi *greedy* yang berbeda[cite: 34]:

1. [cite_start]**Main Bot (Opportunist Bot - Strategi Terpilih):** Menggunakan strategi *greedy* berbasis informasi global yaitu jumlah musuh yang masih hidup di arena (`aliveEnemies`)[cite: 109, 137]. [cite_start]Bot ini membagi aksinya menjadi 3 fase dinamis[cite: 139, 158]:
   * [cite_start]*Fase Awal (> 5 musuh):* Bermain defensif (`WaitingMode`) untuk menghemat energi[cite: 110].
   * [cite_start]*Fase Transisi (2-5 musuh):* Menjaga jarak ideal (`PositioningMode`)[cite: 111].
   * [cite_start]*Fase Duel Akhir (1 musuh):* Menjadi sangat agresif (`HunterMode`) untuk mengamankan bonus kemenangan[cite: 112].
2. [cite_start]**Alternatif Bot 1 (Cornering Bot):** Menggunakan strategi *greedy* statis, langsung bergerak mengunci koordinat sudut (60, 60) sejak awal laga demi meminimalkan arah datangnya serangan musuh[cite: 115, 116, 141].
3. [cite_start]**Alternatif Bot 2 (Self-Energy Bot):** Mengambil keputusan taktis pergerakan dan daya tembak secara *greedy* dengan mengevaluasi sisa kapasitas energinya sendiri pada setiap putaran[cite: 123].
4. [cite_start]**Alternatif Bot 3 (Flanking & Predictive Shoot Bot):** Berorientasi penuh pada strategi ofensif menggunakan perhitungan fisika peluru untuk memprediksi koordinat masa depan musuh berdasarkan arah dan kecepatannya[cite: 129, 134].

---

## 🛠️ Requirements & Instalasi

[cite_start]Sebelum menjalankan bot ini, pastikan komputer Anda telah memenuhi persyaratan berikut[cite: 367]:

1. [cite_start]**.NET SDK:** Install .NET SDK versi terbaru (direkomendasikan versi yang mendukung C# terbaru)[cite: 36].
2. [cite_start]**Java Runtime Environment (JRE):** Diperlukan untuk mengeksekusi aplikasi GUI Java dari Robocode Tank Royale[cite: 371, 372].
3. [cite_start]**Robocode Tank Royale GUI:** Unduh rilis GUI game engine (dalam proyek ini menggunakan basis referensi package versi `0.30.0`)[cite: 95, 371].

---

## 💻 Panduan Compile & Menjalankan Bot

[cite_start]Ikuti langkah-langkah di bawah ini untuk meng-compile kode sumber dan menerjunkan bot ke arena pertempuran[cite: 367, 371, 372]:

### 1. Compile Proyek Bot via Terminal
[cite_start]Masuk ke direktori folder bot yang ingin Anda gunakan (misalnya `src/main-bot/`), lalu jalankan perintah berikut untuk melakukan *build* proyek C#[cite: 36]:
```bash
dotnet build