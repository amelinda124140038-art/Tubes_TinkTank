# 🤖 Tubes_TinkTank - Robocode Tank Royale

Repository ini berisi kode sumber, dokumentasi, dan panduan lengkap untuk Tugas Besar Mata Kuliah IF25-21013 Strategi Algoritma di Institut Teknologi Sumatera (ITERA) Semester Genap Tahun 2026/2027. Proyek ini mengimplementasikan berbagai variasi **Algoritma Greedy** dalam membangun kecerdasan buatan (*behavior*) pada bot pertempuran simulasi otonom Robocode Tank Royale.

## 👥 Author (Identitas Pembuat)
Kelompok **TinkTank**:
* **Nasywa Putri Salsabila** (124140005)
* **Angelica Putri** (124140131)
* **Amelinda Simanjuntak** (124140038)

---

## 🧠 Penjelasan Singkat Algoritma Greedy Per Bot

Proyek ini mengeksplorasi pembentukan fungsi seleksi (*heuristic*) yang dinamis dan adaptif guna mengoptimalkan perolehan skor pertempuran (*Bullet Damage* dan *Survival Score*). Repository ini memuat 4 variasi bot dengan taktik berbasis algoritma *greedy* yang berbeda:

1. **Main Bot (Opportunist Bot - Strategi Terpilih):** Menggunakan strategi *greedy* berbasis informasi global yaitu jumlah musuh yang masih hidup di arena (`aliveEnemies`). Keputusan transisi aksi dibagi secara *greedy* menjadi 3 fase dinamis:
   * *Fase Awal (> 5 musuh):* Bermain sangat defensif (`WaitingMode`) di area aman untuk menghemat energi.
   * *Fase Transisi (2-5 musuh):* Menjaga jarak ideal (`PositioningMode`) untuk mencuri kesempatan menembak musuh yang sekarat.
   * *Fase Duel Akhir (1 musuh):* Berubah total menjadi sangat agresif (`HunterMode`) untuk mengeleminasi musuh terakhir demi mengamankan bonus kemenangan (*Survival Score*).

2. **Alternatif Bot 1 (Cornering Bot):** Menggunakan strategi *greedy* berbasis posisi spasial statis. Bot secara instan bergerak mengunci koordinat sudut (60, 60) sejak awal laga untuk meminimalkan sudut datangnya serangan musuh, lalu mengeksekusi tembakan beruntun secara *greedy* pada musuh terdekat dari sudut tersebut.

3. **Alternatif Bot 2 (Self-Energy Bot):** Mengambil keputusan taktis pergerakan dan daya tembak secara *greedy* dengan mengevaluasi sisa kapasitas energinya sendiri pada setiap putaran (*turn*). Jika energi tinggi, daya tembak dimaksimalkan; jika energi kritis, bot memprioritaskan pergerakan menghindar (*evading*) untuk bertahan hidup lebih lama.

4. **Alternatif Bot 3 (Flanking & Predictive Shoot Bot):** Berorientasi penuh pada strategi ofensif *greedy*. Bot menggunakan perhitungan fisika peluru untuk memprediksi koordinat masa depan musuh berdasarkan arah (*heading*) dan kecepatan (*speed*) terkini demi menghasilkan *hit-rate* tembakan tertinggi di setiap kesempatan.

---

## 🛠️ Requirement Program & Instalasi

Agar program bot dan game engine dapat berjalan dengan lancar, komputer Anda wajib memenuhi komponen lingkungan eksekusi berikut:

### 1. .NET SDK (C# Runtime)
* **Kegunaan:** Diperlukan untuk mengompilasi (*build*) dan mengeksekusi kode program bot berbasis C#.
* **Versi:** Direkomendasikan .NET SDK versi terbaru (minimal mendukung Target Framework `net8.0` dan `LangVersion 10.0`).
* **Langkah Instalasi:** Unduh berkas instalasi melalui situs resmi [Microsoft .NET](https://dotnet.microsoft.com/en-us/), jalankan installer hingga selesai, dan verifikasi melalui terminal dengan perintah: `dotnet --version`

### 2. Java Runtime Environment (JRE) / JDK
* **Kegunaan:** Diperlukan untuk mengeksekusi aplikasi GUI game engine Robocode Tank Royale yang dikembangkan berbasis Java.
* **Versi:** Minimal Java 11 atau versi di atasnya yang stabil.
* **Langkah Instalasi:** Unduh dan pasang melalui situs resmi Oracle atau OpenJDK, lalu verifikasi keberhasilan instalasi via terminal menggunakan perintah: `java -version`

### 3. Game Engine Robocode Tank Royale GUI
* **Kegunaan:** Sebagai server utama pertandingan sekaligus menampilkan visualisasi arena pertempuran secara otonom.
* **Berkas:** Menggunakan berkas arsip modifikasi asisten praktikum, yaitu `robocode-tankroyale-gui-0.30.0.jar`.

---

## 💻 Panduan Compile & Menjalankan Bot (Step-by-Step)

Ikuti urutan langkah di bawah ini secara tepat agar seluruh bot kelompok TinkTank dapat mendeteksi server dan bertanding di dalam arena:

### Langkah 1: Menjalankan Game Engine (Server Utama)
1. Buka File Explorer dan masuk ke folder utama proyek: `Tubes_TinkTank/`.
2. Pastikan file `robocode-tankroyale-gui-0.30.0.jar` sudah berada di dalam folder tersebut.
3. Klik pada **Address Bar** di bagian atas Windows Explorer, ketik `cmd`, lalu tekan **Enter**.
4. Di jendela Command Prompt yang terbuka, ketik perintah sakral berikut untuk memicu GUI game:
   ```bash
   java -jar robocode-tankroyale-gui-0.30.0.jar