# 🤖 Project Robocode Tank Royale - Greedy Bot Group

Proyek ini dibuat untuk memenuhi tugas besar/praktikum mata kuliah dengan mengimplementasikan **Algoritma Greedy** pada komponen kecerdasan buatan (*AI*) dari bot tank di simulator **Robocode Tank Royale**. 

Repositori ini memuat **1 Bot Utama Terbaik** yang paling optimal dan siap tanding, serta **3 Bot Alternatif** yang dikembangkan sebagai bentuk eksperimen variasi strategi.

---

## 👨‍💻 Author (Identitas Pembuat)
* **Nama Lengkap** : [Nama Anda]
* **NIM** : [NIM Anda]
* **Kelas / Paralel** : [Kelas Anda, misal: RC / A]
* **Program Studi** : [Jurusan Anda, misal: Teknik Informatika]

---

## 🎯 Penjelasan Singkat Algoritma Greedy Per Bot

Secara umum, algoritma *Greedy* mengambil keputusan terbaik secara lokal pada setiap *tick* (detik) permainan tanpa memikirkan dampak jangka panjang, dengan harapan kombinasi keputusan lokal ini membawa pada kondisi optimal global (kemenangan). 

Berikut adalah detail bagaimana sifat *Greedy* diterapkan pada masing-masing bot yang dibuat:

### 🏆 1. ApexGreedyBot (Bot Utama - Terbaik)
Bot ini dipilih sebagai versi terbaik karena menggabungkan efisiensi pergerakan dan efisiensi energi (*Energy Economy*).
* **Greedy Target Acquisition:** Radar mendeteksi semua musuh di arena, namun sistem secara serakah memilih dan mengunci musuh yang memiliki **jarak terdekat** (`Distance` terkecil) untuk memastikan akurasi tembakan yang maksimal.
* **Greedy Firepower (Daya Tembak Dinamis):** Bot menerapkan prinsip ketamakan energi. Besar daya tembak disesuaikan secara otomatis dengan rumus matematika berbasis jarak ($D$):
  $$\text{Firepower} = \min\left(\frac{400}{D}, 3.0\right)$$
  Jika musuh sangat dekat, bot melepaskan tembakan maksimal (`3.0`). Jika musuh menjauh, daya tembak diturunkan secara serakah agar energi bot tidak terbuang sia-sia apabila peluru meleset.
* **Greedy Evasion:** Bot selalu bergerak tegak lurus ($90^\circ$) terhadap posisi target terdekat untuk melakukan teknik kecohan berkendara (*strafing*) demi menghindari peluru lawan secara instan.

### 🤖 2. ExecutionerBot (Alternatif 1)
* **Greedy Target (HP Terendah):** Berbeda dengan bot utama, bot ini mendasarkan sifat ketamakannya pada darah lawan. Radar akan memindai seluruh arena, lalu secara serakah mengunci dan mengejar musuh yang memiliki **sisa HP/Energy paling sedikit**. Strategi lokalnya adalah mengeliminasi musuh yang sekarat terlebih dahulu agar jumlah kompetitor di dalam arena berkurang secepat mungkin.

### 🤖 3. ShadowBot (Alternatif 2)
* **Greedy Proximity Zone:** Bot ini bersifat pasif-agresif dan sangat serakah terhadap ruang aman. Bot akan mengabaikan seluruh musuh yang berada di jarak jauh. Namun, begitu ada musuh yang melanggar batas zona aman fisik bot (radius di bawah 300 unit), bot akan langsung mengarahkan meriam dan menembak dengan daya penuh (`3.0`) secara agresif demi mengusir ancaman terdekat.

### 🤖 4. CowardlyPredator (Alternatif 3)
* **Greedy State berdasarkan Kalkulasi Energi:** Bot ini mengambil keputusan instan berdasarkan perbandingan status HP. Jika energi musuh terpindai lebih besar dari energinya sendiri, bot akan langsung berbalik arah $180^\circ$ dan kabur menjauh (Greedy Survival). Sebaliknya, jika energi musuh lebih kecil, bot akan berubah menjadi predator yang memburu, menembak, dan menabrak tank tersebut secara brutal.

---

## 🛠️ Requirement Program & Instalasi

Agar program ini dapat berjalan dengan lancar tanpa kendala *library*, pastikan perangkat penguji telah menginstal spesifikasi berikut:
1. **.NET SDK 8.0** (atau versi di atasnya) sebagai compiler dan runtime bahasa C#.
2. **Robocode Tank Royale GUI Application** (Aplikasi simulator grafis utama game Robocode).
3. **Java Runtime Environment (JRE) atau JDK 11+** (Hanya diperlukan sebagai syarat utama untuk menjalankan aplikasi master/GUI Robocode Tank Royale itu sendiri).

---

## 💻 Cara Melakukan Compile dan Menjalankan Program

Robocode Tank Royale menggunakan arsitektur **Client-Server**. Aplikasi GUI bertindak sebagai *Server* (lapangan), sedangkan kode C# bertindak sebagai *Client* (otak bot). Oleh karena itu, urutan langkah di bawah ini **harus dilakukan secara berurutan**:

### Langkah 1: Jalankan Game Simulator (Server)
1. Buka aplikasi **Robocode Tank Royale GUI** di komputer Anda.
2. Pastikan server lokal aplikasi telah berjalan (secara default menggunakan port `localhost:7654`). Biarkan aplikasi ini tetap terbuka di latar belakang.

### Langkah 2: Masuk ke Folder dan Lakukan Kompilasi (*Build*)
1. Buka Terminal, Command Prompt, atau PowerShell di komputer Anda.
2. Arahkan direktori kerja ke dalam folder `src` tempat kode sumber berada:
   ```bash
   cd src