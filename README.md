***

```markdown
# 🤖 Tubes_TinkTank - Robocode Tank Royale

Repository ini berisi kode sumber, dokumentasi, dan panduan lengkap untuk Tugas Besar Mata Kuliah IF25-21013 Strategi Algoritma di Institut Teknologi Sumatera (ITERA) Semester Genap Tahun 2026/2027. Proyek ini mengimplementasikan berbagai variasi **Algoritma Greedy** dalam membangun kecerdasan buatan (*behavior*) pada bot pertempuran simulasi otonom Robocode Tank Royale.

## 👥 Author (Identitas Pembuat)
Kelompok **TinkTank**:
* **Nasywa Putri Salsabila** (124140005)
* **Angelica Putri** (124140131)
* **Amelinda Simanjuntak** (124140038)

---

## 🧠 Penjelasan Singkat Algoritma Greedy Per Bot

Proyek ini mengeksplorasi pembentukan fungsi seleksi (*heuristic*) yang dinamis dan adaptif guna mengoptimalkan perolehan skor pertempuran (*Bullet Damage* dan *Survival Score*). Repository ini memuat 4 variasi bot dengan taktik berbasis algoritma *greedy* sebagai berikut:

1. **Main Bot (Opportunist Bot - Strategi Terpilih):** Menggunakan strategi *greedy* berbasis informasi global jumlah musuh yang masih hidup di arena (`aliveEnemies`). Keputusan transisi aksi dibagi secara *greedy* menjadi 3 fase dinamis: *Waiting Mode* (saat musuh ramai untuk hemat energi), *Positioning Mode* (menjaga jarak aman), dan *Hunter Mode* (agresif berburu saat sisa 1 musuh untuk mengunci bonus kemenangan).

2. **Alternatif Bot 1 (Alt 1 - Survival Bot):** Menggunakan strategi *greedy* yang berorientasi penuh pada ketahanan hidup (*survival rate*). Elemen *greedy* diterapkan dengan mencari koordinat sudut terdekat dari posisi awal bot secara instan, lalu mengunci posisi di sudut tersebut. Hal ini dilakukan demi membatasi sudut serang musuh (hanya dari arah depan), sehingga bot bisa bertahan hidup lebih lama sambil menembak musuh secara konstan.

3. **Alternatif Bot 2 (Alt 2 - Adaptive Bot):** Menggunakan strategi *greedy* berbasis kondisi internal, di mana bot secara adaptif mengevaluasi sisa kapasitas energinya sendiri (*Self-Energy*) pada setiap *turn*. Pilihan aksi diambil secara *greedy*: jika energi melimpah, bot akan meningkatkan daya tembak maksimal (*ofensif*); namun jika energi berada di batas kritis, bot langsung mengubah prioritas aksinya untuk fokus menghindar dan menjauh (*defensif*).

4. **Alternatif Bot 3 (Alt 3 - Flanker Bot):** Menggunakan strategi *greedy* berbasis manuver spasial bergerak (*flanking*). Bot ini secara *greedy* akan selalu mencari celah kelengahan musuh dengan bergerak memutari sisi terluar radar lawan (*flanking trajectory*). Dipadukan dengan *Predictive Shooting*, bot ini akan mengeksekusi tembakan di titik prediksi masa depan musuh demi menghasilkan daya rusak (*bullet damage*) yang maksimal.

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