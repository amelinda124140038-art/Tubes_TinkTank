# 🤖 Project Robocode Tank Royale - Greedy Bot Group

Proyek ini dibuat untuk memenuhi tugas mata kuliah dengan mengimplementasikan **Algoritma Greedy** pada bot tank di simulator **Robocode Tank Royale**. Proyek ini berisi **1 Bot Utama Terbaik** yang siap tanding dan **3 Bot Alternatif** sebagai variasi eksperimen strategi.

---

## 👨‍💻 Author (Identitas Pembuat)
* **Nama Lengkap** : [Nama Anda]
* **NIM** : [NIM Anda]
* **Kelas** : [Kelas/Paralel Anda]
* **Prodi/Jurusan**: [Jurusan Anda]

---

## 🎯 Penjelasan Singkat Algoritma Greedy Per Bot

Algoritma Greedy mengambil keputusan terbaik secara lokal pada setiap *tick* (detik) permainan dengan harapan mencapai kemenangan global. Berikut implementasi sifat Greedy pada masing-masing bot:

### 🏆 1. ApexGreedyBot (Bot Utama - Terbaik)
* **Greedy Target & Firepower:** Bot secara serakah selalu mengunci radar dan meriam ke musuh yang memiliki **jarak terdekat** (`Distance` terkecil). Keunggulan utamanya adalah formula daya tembak dinamis berdasarkan jarak:
  $$\text{Firepower} = \min\left(\frac{400}{\text{Distance}}, 3.0\right)$$
  Makin dekat musuh, makin besar daya tembaknya (Greedy Energi).
* **Greedy Movement:** Bot bergerak tegak lurus ($90^\circ$) terhadap posisi musuh untuk menghindari peluru lawan secara instan (*strafing*).

### 🤖 2. ExecutionerBot (Alternatif 1)
* **Greedy Target (HP Terendah):** Bot ini secara serakah memindai seluruh arena dan hanya akan mengunci musuh yang memiliki **sisa HP/Energi paling sedikit**. Tujuannya adalah mengeliminasi musuh yang sekarat secepat mungkin guna mengurangi jumlah kompetitor di arena.

### 🤖 3. ShadowBot (Alternatif 2)
* **Greedy Proximity:** Bot ini bersifat pasif-agresif. Bot akan mengabaikan musuh yang jauh dan baru akan melepaskan tembakan bermuatan penuh (`3.0`) jika ada musuh yang memasuki **radius jarak di bawah 300 unit** dari posisi fisiknya guna menjamin akurasi 100%.

### 🤖 4. CowardlyPredator (Alternatif 3)
* **Greedy State berdasarkan Energi:** Bot mendasarkan keputusannya pada perbandingan HP. Jika energi musuh lebih besar dari energinya, bot akan langsung berbalik arah dan kabur (Greedy Survival). Sebaliknya, jika energi musuh lebih kecil, bot akan memburu, menembak, dan menabrak musuh tersebut.

---

## 🛠️ Requirement Program & Instalasi

Sebelum menjalankan program, pastikan perangkat Anda telah terinstal *tools* berikut:
1. **.NET SDK 8.0** (atau versi di atasnya) sebagai runtime dan compiler C#.
2. **Robocode Tank Royale GUI Application** (Aplikasi simulator game).
3. **Java Runtime Environment (JRE) / JDK 11+** (Hanya diperlukan untuk menjalankan aplikasi master/GUI Robocode Tank Royale itu sendiri).

---

## 💻 Command & Langkah-Langkah Build / Compile

Ikuti langkah-langkah berikut di Terminal / Command Prompt Anda:

### 1. Masuk ke Folder Proyek
```bash
cd folder-proyek-robocode